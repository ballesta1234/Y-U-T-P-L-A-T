namespace YUTPLAT.Migrations
{
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Linq;
    using Models;
    using System.IO;
    using System;
    using Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<YUTPLAT.Context.YutplatDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "YUTPLAT.Context.YutplatDbContext";
        }

        protected override void Seed(YUTPLAT.Context.YutplatDbContext context)
        {
            //if (!System.Diagnostics.Debugger.IsAttached) System.Diagnostics.Debugger.Launch();

            CargarRoles(context);
            CargarUsuarios(context);
            CargarFrecuenciasMedicionIndicadores(context);
            EjecutarArchivosSQL(context);

            base.Seed(context);
        }

        private void EjecutarArchivosSQL(YUTPLAT.Context.YutplatDbContext context)
        {
            string dirName = AppDomain.CurrentDomain.BaseDirectory;
            FileInfo fileInfo = new FileInfo(dirName);
            DirectoryInfo parentDir = fileInfo.Directory.Parent;
            string parentDirName = parentDir.FullName;

            var archivosSql = Directory.GetFiles(parentDirName + "\\SQL", "*.sql").OrderBy(x => x);

            foreach (string archivo in archivosSql)
            {
                if (!context.ArchivosSQL.Any(r => r.NombreArchivo == archivo.Replace(parentDirName + "\\SQL\\", "")))
                {
                    context.Database.ExecuteSqlCommand(File.ReadAllText(archivo));
                    context.ArchivosSQL.AddOrUpdate(new YUTPLAT.Models.ArchivoSQL { NombreArchivo = archivo.Replace(parentDirName + "\\SQL\\", "") });
                    context.SaveChanges();
                }
            }            
        }

        private void CargarRoles(YUTPLAT.Context.YutplatDbContext context)
        {
            string rolAdmin = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Admin);
            string rolUsuario = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Usuario);
            string rolOperador = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Operador);

            if (!context.Roles.Any(r => r.Name == rolAdmin))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = rolAdmin };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == rolUsuario))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = rolUsuario };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == rolOperador))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = rolOperador };

                manager.Create(role);
            }
        }

        private void CargarUsuarios(YUTPLAT.Context.YutplatDbContext context)
        {
            string rolAdmin = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Admin);
            string rolUsuario = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Usuario);
            string rolOperador = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Operador);

            string email = "@cys.com.ar";
            email += "TEST";
            
            if (!context.Users.Any(u => u.UserName == "amolinari"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);

                var user = new Persona { UserName = "amolinari", Email = "amolinari" + email, EmailConfirmed = true, Nombre = "Alejandro", Apellido = "Molinari", Rol = rolAdmin };
                
                manager.Create(user, "i08oyy");
                manager.AddToRole(user.Id, rolAdmin);
            }

            if (!context.Users.Any(u => u.UserName == "jbarbosa"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "jbarbosa", Email= "jbarbosa" + email, EmailConfirmed = true, Nombre = "Jorge", Apellido = "Barbosa", Rol = rolAdmin };
                
                manager.Create(user, "pjdjiz");
                manager.AddToRole(user.Id, rolAdmin);
            }

            if (!context.Users.Any(u => u.UserName == "elara"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "elara", Email = "elara" + email, EmailConfirmed = true, Nombre = "Enrique", Apellido = "Lara", Rol = rolAdmin };

                manager.Create(user, "bhz6cw");
                manager.AddToRole(user.Id, rolAdmin);
            }

            if (!context.Users.Any(u => u.UserName == "lbertuzzi"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "lbertuzzi", Email = "lbertuzzi" + email, EmailConfirmed = true, Nombre = "Liliana", Apellido = "Bertuzzi", Rol = rolAdmin };

                manager.Create(user, "6dpqmz");
                manager.AddToRole(user.Id, rolAdmin);
            }

            if (!context.Users.Any(u => u.UserName == "ncaniggia"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "ncaniggia", Email = "norberto" + email, EmailConfirmed = true, Nombre = "Norberto", Apellido = "Caniggia", Rol = rolAdmin };

                manager.Create(user, "widqru");
                manager.AddToRole(user.Id, rolAdmin);
            }

            if (!context.Users.Any(u => u.UserName == "cfontela"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "cfontela", Email = "cfontela" + email, EmailConfirmed = true, Nombre = "Carlos", Apellido = "Fontela", Rol = rolUsuario };
               
                manager.Create(user, "bh283d");
                manager.AddToRole(user.Id, rolUsuario);
            }
            
            if (!context.Users.Any(u => u.UserName == "econtreras"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "econtreras", Email = "econtreras" + email, EmailConfirmed = true, Nombre = "Eduardo", Apellido = "Contreras", Rol = rolUsuario };
               
                manager.Create(user, "kpccjk");
                manager.AddToRole(user.Id, rolUsuario);
            }

            if (!context.Users.Any(u => u.UserName == "aromero"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "aromero", Email = "aromero" + email, EmailConfirmed = true, Nombre = "Alexandra", Apellido = "Romero", Rol = rolUsuario };
                
                manager.Create(user, "b1kjb9");
                manager.AddToRole(user.Id, rolUsuario);
            }

            if (!context.Users.Any(u => u.UserName == "jdelvalle"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "jdelvalle", Email = "jdv" + email, EmailConfirmed = true, Nombre = "Javier", Apellido = "del Valle", Rol = rolUsuario };
                
                manager.Create(user, "4kd6tk");
                manager.AddToRole(user.Id, rolUsuario);
            }
        }

        private void CargarFrecuenciasMedicionIndicadores(YUTPLAT.Context.YutplatDbContext context)
        {
            if (!context.FrecuenciasMedicionIndicadores.Any(f => f.Descripcion == "Mensual"))
            {
                context.FrecuenciasMedicionIndicadores.AddOrUpdate(new FrecuenciaMedicionIndicador { Descripcion = "Mensual" });
            }

            /*
            if (!context.FrecuenciasMedicionIndicadores.Any(f => f.Descripcion == "Al final de cada proyecto de capacitación"))
            {
                context.FrecuenciasMedicionIndicadores.AddOrUpdate(new FrecuenciaMedicionIndicador { Descripcion = "Al final de cada proyecto de capacitación" });
            }
            
            if (!context.FrecuenciasMedicionIndicadores.Any(f => f.Descripcion == "Trimestral"))
            {
                context.FrecuenciasMedicionIndicadores.AddOrUpdate(new FrecuenciaMedicionIndicador { Descripcion = "Trimestral" });
            }

            if (!context.FrecuenciasMedicionIndicadores.Any(f => f.Descripcion == "Cuatrimestral"))
            {
                context.FrecuenciasMedicionIndicadores.AddOrUpdate(new FrecuenciaMedicionIndicador { Descripcion = "Cuatrimestral" });
            }
            */

            context.SaveChanges();
        }
    }
}
