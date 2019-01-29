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
        private int pageSize = 5;

        public AuthorController(IRepository<Card> repo)
        {
            repository = repo;
        }

        // GET: Author
        public ActionResult List(string group, string searchString, int page = 1)
        {
            var lst = repository.GetAll().Where(d => group == null
                             || d.Year == Convert.ToInt32(group))
                     .OrderBy(d => d.Title)
                     .OrderByDescending(d => d.Year);

            PageListViewModel<Card> model;

            if (!String.IsNullOrEmpty(searchString))
            {
                var lstnew = lst.Where(s => s.Title.Contains(searchString)
                || !String.IsNullOrEmpty(s.LastName) && s.LastName.Contains(searchString)
                || !String.IsNullOrEmpty(s.FirstName) && s.FirstName.Contains(searchString)
                || !String.IsNullOrEmpty(s.MiddleName) && s.MiddleName.Contains(searchString)
                || !String.IsNullOrEmpty(s.Body) && s.Body.Contains(searchString)
                || !String.IsNullOrEmpty(s.Description) && s.Description.Contains(searchString)
                || !String.IsNullOrEmpty(s.Collaborators) && s.Collaborators.Contains(searchString)
                );

                model = PageListViewModel<Card>.CreatePage(lstnew, page, pageSize);
            }
            else
            {
                model = PageListViewModel<Card>.CreatePage(lst, page, pageSize);
            }


            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }


            return View(model);
        }

        // GET: Admin/HeritageCreate
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            var author = new Card();
            author.Year = DateTime.Now.Year;

            return View(author);
        }

        // POST: Admin/HeritageCreate
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Card author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Create(author);
                    return RedirectToAction("List");
                }
                catch
                {
                    return View();
                }
            }
            else return View(author);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Card author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(author);
                    return RedirectToAction("List");
                }
                catch
                {
                    return View();
                }
            }
            else return View(author);
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repository.Delete(id);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Details(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repository.Get(id);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        public PartialViewResult Side()
        {
            var group = repository
                .GetAll()
                .OrderByDescending(d => d.Year)
                .Select(d => d.Year)
                .Distinct();

            return PartialView(group);
        }
    }
}