using LibDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibBD.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Organization> repository;

        public HomeController(IRepository<Organization> repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            var model = repository.GetAll().First();

            return View(model);
        }
    }
}