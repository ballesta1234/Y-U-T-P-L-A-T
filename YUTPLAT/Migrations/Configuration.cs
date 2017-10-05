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
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "matias"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "matias", Nombre = "Matias", Apellido = "Ballestero" };

                manager.Create(user, "123qwe");
                manager.AddToRole(user.Id, "admin");
            }

            if (!context.Users.Any(u => u.UserName == "pepe"))
            {
                var store = new UserStore<Persona>(context);
                var manager = new UserManager<Persona>(store);
                var user = new Persona { UserName = "pepe", Nombre = "Juan", Apellido = "Perez" };

                manager.Create(user, "123qwe");
                manager.AddToRole(user.Id, "admin");
            }
        }
    }
}
