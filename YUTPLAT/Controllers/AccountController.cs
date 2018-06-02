using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using YUTPLAT.ViewModel;
using YUTPLAT.Services.Interface;
using YUTPLAT.Helpers;

namespace YUTPLAT.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public IAnioTableroService AnioTableroService { get; set; }
        public IPersonaService PersonaService { get; set; }
        public IAuditoriaService AuditoriaService { get; set; }

        public AccountController(IPersonaService personaService,
                                 IAnioTableroService anioTableroService,
                                 IAuditoriaService auditoriaService)
        {
            this.PersonaService = personaService;
            this.AnioTableroService = anioTableroService;
            this.AuditoriaService = auditoriaService;
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            LogOff();

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
                
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
                        
            // No cuenta los errores de inicio de sesión para el bloqueo de la cuenta
            // Para permitir que los errores de contraseña desencadenen el bloqueo de la cuenta, cambie a shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.User, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    PersonaViewModel persona = await PersonaService.GetByUserName(model.User);
                    Session["Persona"] = persona;
                    AuditarIngreso(persona);
                    return await RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");               
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                    return View(model);
            }
        }

        private void AuditarIngreso(PersonaViewModel persona)
        {
            AuditoriaViewModel auditoria = new AuditoriaViewModel();
            auditoria.Descripcion = "Ingreso de " + persona.NombreUsuario;
            auditoria.FechaCreacion = DateTimeHelper.OntenerFechaActual();
            auditoria.TipoAuditoria = Enums.Enum.TipoAuditoria.LoginUsuario;
            auditoria.UsuarioViewModel = persona;

            AuditoriaService.Guardar(auditoria);
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Aplicaciones auxiliares
        // Se usa para la protección XSRF al agregar inicios de sesión externos
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private async Task<ActionResult> RedirectToLocal(string returnUrl)
        {            
            string decodedUrl = "";

            if (!string.IsNullOrEmpty(returnUrl) && !returnUrl.Equals("/") && !returnUrl.Contains("LogOff"))
            {
                decodedUrl = Server.UrlDecode(returnUrl);
            }

            if (Url.IsLocalUrl(decodedUrl))
            {
                return Redirect(decodedUrl);
            }
            else
            {
                Session["IdAnioTablero"] = (await AnioTableroService.GetActual()).AnioTableroID.ToString();
                
                PersonaViewModel personaViewModel = (PersonaViewModel)Session["Persona"];

                Session["IdAreaTablero"] = null;

                if (!personaViewModel.EsAdmin)
                {
                    Session["IdAreaTablero"] = personaViewModel.AreaViewModel.Id.ToString();
                }

                return RedirectToAction("Ver", "Tablero");
            }            
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}