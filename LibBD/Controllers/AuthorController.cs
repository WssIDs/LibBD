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
        IRepository<Author> repository;
        int pageSize = 3;

        public AuthorController(IRepository<Author> repo)
        {
            repository = repo;
        }

        // GET: Author
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string group, int page = 1)
        {
            var lst = repository.GetAll().Where(d => group == null
                             || d.CardYear.Equals(group))
                     .OrderBy(d => d.CardYear);
            var model = PageListViewModel<Author>.CreatePage(lst, page, pageSize);

            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }


            return View(model);
        }
    }
}