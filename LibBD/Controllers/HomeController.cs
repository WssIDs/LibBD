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
        IRepository<TestAuth> repositoryAuths;

        public HomeController(IRepository<Organization> repo, IRepository<TestAuth> repoA)
        {
            repository = repo;
            repositoryAuths = repoA;
        }

        public ActionResult Index()
        {
            var model = repository.GetAll().First();
            ViewBag.Organization = model;

            var modelA = repositoryAuths.GetAll();

            return View(modelA);
        }
    }
}