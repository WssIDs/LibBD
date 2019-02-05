using LibDB.Models;
using LibDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibDB.Controllers
{
    public class MenuController : Controller
    {
        List<MenuItem> items;

        IRepository<Organization> repository;
        IRepository<TestBase> repositoryA;

        public MenuController(IRepository<Organization> repo, IRepository<TestBase> repoA)
        {
            repositoryA = repoA;

            items = new List<MenuItem>
            {
                new MenuItem{Name="Главная", Controller="Home", Action="Index", Active=string.Empty},
                //new MenuItem{Name="Писатели Клетчины", Controller="Author", Action="List", Active=string.Empty},
                //new MenuItem{Name="Культура", Controller="Author", Action="Index", Active=string.Empty},
                //new MenuItem{Name="История", Controller="Author", Action="Index", Active=string.Empty},
                //new MenuItem{Name="Контакты", Controller="Contact", Action="Index", Active=string.Empty},
            };

            var model = repositoryA.GetAll();

            foreach (var it in model)
            {
                var menu = new MenuItem();
                menu.Name = it.Title;
                menu.Controller = "TestCards";
                menu.Action = "List";
                menu.Group = it.Id.ToString();
                menu.Active = string.Empty;
                items.Add(menu);
            }


            //items.Add(new MenuItem { Name = "Все карточки (для администраторов)", Controller = "TestCards", Action = "List", Active = string.Empty });

            repository = repo;
        }

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Brand()
        {
            return PartialView(repository.GetAll().First());
        }

        public PartialViewResult Main(string maingroup, string a = "Index", string c = "Home")
        {
            var item = items.Where(m => m.Controller == c && maingroup == null || m.Group == maingroup);
            if (item.Count() != 0)
            {
                item.First().Active = "active";
            }

            return PartialView(items);
        }

        public PartialViewResult Footer()
        {
            return PartialView(repository.GetAll().First());
        }
    }
}