namespace YUTPLAT.Migrations
{
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<YUTPLAT.Context.YutplatDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "YUTPLAT.Context.YutplatDbContext";
        }

        protected override void Seed(YUTPLAT.Context.YutplatDbContext context)
        {
            CargarRoles(context);
            CargarUsuarios(context);
            CargarFrecuenciasMedicionIndicadores(context);
        }

        private void CargarRoles(YUTPLAT.Context.YutplatDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }
        }

        private void CargarUsuarios(YUTPLAT.Context.YutplatDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "mballestero"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "mballestero", Nombre = "Matias", Apellido = "Ballestero" };

                manager.Create(user, "123qwe");
                manager.AddToRole(user.Id, "admin");
            }

            if (!context.Users.Any(u => u.UserName == "amolinari"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "amolinari", Nombre = "Alejandro", Apellido = "Molinari" };

                manager.Create(user, "123qwe");
                manager.AddToRole(user.Id, "admin");
            }

            if (!context.Users.Any(u => u.UserName == "jbarbosa"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "jbarbosa", Nombre = "Jorge", Apellido = "Barbosa" };

                manager.Create(user, "123qwe");
                manager.AddToRole(user.Id, "admin");
            }

            if (!context.Users.Any(u => u.UserName == "cfontela"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "cfontela", Nombre = "Carlos", Apellido = "Fontela" };

                manager.Create(user, "123qwe");
                manager.AddToRole(user.Id, "admin");
            }

            if (!context.Users.Any(u => u.UserName == "elara"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "elara", Nombre = "Enrique", Apellido = "Lara" };

                manager.Create(user, "123qwe");
                manager.AddToRole(user.Id, "admin");
            }

            if (!context.Users.Any(u => u.UserName == "ncaniggia"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "ncaniggia", Nombre = "Norberto", Apellido = "Caniggia" };

                manager.Create(user, "123qwe");
                manager.AddToRole(user.Id, "admin");
            }

            if (!context.Users.Any(u => u.UserName == "lbertuzzi"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "lbertuzzi", Nombre = "Liliana", Apellido = "Bertuzzi" };

                manager.Create(user, "123qwe");
                manager.AddToRole(user.Id, "admin");
            }
        }

        private void CargarFrecuenciasMedicionIndicadores(YUTPLAT.Context.YutplatDbContext context)
        {
            if (!context.FrecuenciasMedicionIndicadores.Any(f => f.Descripcion == "Al final de cada proyecto de capacitación"))
            {
                context.FrecuenciasMedicionIndicadores.AddOrUpdate(new FrecuenciaMedicionIndicador { Descripcion = "Al final de cada proyecto de capacitación" });
            }

            if (!context.FrecuenciasMedicionIndicadores.Any(f => f.Descripcion == "Mensual"))
            {
                context.FrecuenciasMedicionIndicadores.AddOrUpdate(new FrecuenciaMedicionIndicador { Descripcion = "Mensual" });
            }

            if (!context.FrecuenciasMedicionIndicadores.Any(f => f.Descripcion == "Trimestral"))
            {
                context.FrecuenciasMedicionIndicadores.AddOrUpdate(new FrecuenciaMedicionIndicador { Descripcion = "Trimestral" });
            }

            if (!context.FrecuenciasMedicionIndicadores.Any(f => f.Descripcion == "Cuatrimestral"))
            {
                context.FrecuenciasMedicionIndicadores.AddOrUpdate(new FrecuenciaMedicionIndicador { Descripcion = "Cuatrimestral" });
            }

            context.SaveChanges();
        }
    }
}
