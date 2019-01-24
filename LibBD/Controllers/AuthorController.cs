using LibBD.Models;
using LibDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibBD.Controllers
{
    public class AuthorController : Controller
    {
        IRepository<Card> repository;
        int pageSize = 5;

        public AuthorController(IRepository<Card> repo)
        {
            repository = repo;
        }

        // GET: Author
        public ActionResult Index(string group, int page = 1)
        {
            var lst = repository.GetAll().Where(d => group == null
                             || d.Year == Convert.ToInt32(group))
                     .OrderBy(d => d.Title)
                     .OrderByDescending(d => d.Year);
            var model = PageListViewModel<Card>.CreatePage(lst, page, pageSize);

            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }


            return View(model);
        }

        public PartialViewResult Side()
        {
            var group = repository
                .GetAll()
                .Select(d => d.Year)
                .Distinct();

            return PartialView(group);
        }
    }
}