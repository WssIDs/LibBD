﻿using LibBD.Models;
using LibDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibBD.Controllers
{
    public class MenuController : Controller
    {
        List<MenuItem> items;

        IRepository<Organization> repository;

        public MenuController(IRepository<Organization> repo)
        {
            items = new List<MenuItem>
            {
                new MenuItem{Name="Домой", Controller="Home", Action="Index", Active=string.Empty},
                new MenuItem{Name="Авторы", Controller="Author", Action="List", Active=string.Empty},
                new MenuItem{Name = "Администрирование",Controller = "Admin",  Action = "Index", Active = string.Empty}
            };

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

        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            var item = items.Where(m => m.Controller == c);
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