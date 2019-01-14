using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDB.DAL
{
    public partial class ApplicationDbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public void Populate()
        {
            if (!Roles.Any())
            {
                // Создаем менеджеры ролей и пользователей
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));

                // Создаем роли "admin" и "user"
                roleManager.Create(new IdentityRole("admin"));
                roleManager.Create(new IdentityRole("user"));

                // Создаем пользователя
                var userAdmin = new ApplicationUser
                {
                    Email = "admin@wssids.by",
                    UserName = "admin@wssids.by",
                    NickName = "WssIDs"
                };

                userManager.CreateAsync(userAdmin, "123456").Wait();

                // Добавляем созданного пользователя в администраторы 
                userManager.AddToRole(userAdmin.Id, "admin");
            }

            //if (!Authors.Any())
            //{
            //    List<Author> authors = new List<Author>
            //    {
            //        new Author { AuthorId = 1, AuthorName = "Иван Доминикович Луцевич", NickName = "Янка Купала", Genre = "Поэт"},
            //    };

            //    Authors.AddRange(authors);
            //}

            if(!Organizations.Any())
            {
                List<Organization> organizations = new List<Organization>
                {
                    new Organization { OrganizationId = 1, FullOrganizationName = "Государственное учреждение \"Клецкая районная центральная библиотека\"", ShortOrganizationName = "Клецкая районная центральная библиотека", Director = "Козловский Сергей Казимирович", Phone = "80179368018", Email = "klecklib@tut.by"}
                };

                Organizations.AddRange(organizations);
            }

            SaveChanges();
        }
    }
}
