using LibBD.Models;
using LibDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibBD.Controllers
{
    public class TestCardsController : Controller
    {
        IRepository<TestCard> repository;
        IRepository<TestAuth> repositoryAuths;

        int pageSize = 3;

        public TestCardsController(IRepository<TestCard> repo, IRepository<TestAuth> repoAuth)
        {
            repository = repo;
            repositoryAuths = repoAuth;
        }

        // GET: TestCards
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        public ActionResult List(string maingroup, string group,string searchtext, int page = 1)
        {
            ViewBag.ListItem = repositoryAuths.GetAll();

            PageListViewModel<TestCard> model;

            if (!String.IsNullOrEmpty(maingroup))
            {
                if (!String.IsNullOrEmpty(searchtext))
                {
                    var nlst = repository.GetAll().Where(a => a.AuthId == Convert.ToInt32(maingroup) && group == null
                                                            || a.Year == Convert.ToInt32(group))
                                                            .OrderBy(d => d.Title)
                                                            .OrderByDescending(d => d.Year);

                    var lstnew = nlst.Where(s => s.Title.Contains(searchtext)
                    //|| !String.IsNullOrEmpty(s.) && s.LastName.Contains(searchString)
                    //|| !String.IsNullOrEmpty(s.FirstName) && s.FirstName.Contains(searchString)
                    //|| !String.IsNullOrEmpty(s.MiddleName) && s.MiddleName.Contains(searchString)
                    //|| !String.IsNullOrEmpty(s.Body) && s.Body.Contains(searchString)
                    //|| !String.IsNullOrEmpty(s.Description) && s.Description.Contains(searchString)
                    //|| !String.IsNullOrEmpty(s.Collaborators) && s.Collaborators.Contains(searchString)
                    );

                    model = PageListViewModel<TestCard>.CreatePage(lstnew, page, pageSize);

                }
                else
                {
                    var nlst = repository.GetAll().Where(a => a.AuthId == Convert.ToInt32(maingroup) && group == null
                                                            || a.Year == Convert.ToInt32(group))
                                                            .OrderBy(d => d.Title)
                                                            .OrderByDescending(d => d.Year);
                    //var lst = repository.GetAll();
                    model = PageListViewModel<TestCard>.CreatePage(nlst, page, pageSize);
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(searchtext))
                {
                    var nlst = repository.GetAll().Where(a => group == null
                                        || a.Year == Convert.ToInt32(group))
                                        .OrderBy(d => d.Title)
                                        .OrderByDescending(d => d.Year);

                    var lstnew = nlst.Where(s => s.Title.Contains(searchtext)
                    //|| !String.IsNullOrEmpty(s.) && s.LastName.Contains(searchString)
                    //|| !String.IsNullOrEmpty(s.FirstName) && s.FirstName.Contains(searchString)
                    //|| !String.IsNullOrEmpty(s.MiddleName) && s.MiddleName.Contains(searchString)
                    //|| !String.IsNullOrEmpty(s.Body) && s.Body.Contains(searchString)
                    //|| !String.IsNullOrEmpty(s.Description) && s.Description.Contains(searchString)
                    //|| !String.IsNullOrEmpty(s.Collaborators) && s.Collaborators.Contains(searchString)
                    );

                    model = PageListViewModel<TestCard>.CreatePage(lstnew, page, pageSize);

                }
                else
                {
                    var nlst = repository.GetAll().Where(a => group == null
                                        || a.Year == Convert.ToInt32(group))
                                        .OrderBy(d => d.Title)
                                        .OrderByDescending(d => d.Year);
                    //var lst = repository.GetAll();
                    model = PageListViewModel<TestCard>.CreatePage(nlst, page, pageSize);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }


            return View(model);
        }

        // GET: TestCards/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestCards/Create
        public ActionResult Create()
        {
            var testcard = new TestCard();
            ViewBag.ListItem = repositoryAuths.GetAll();

            return View(testcard);
        }

        // POST: TestCards/Create
        [HttpPost]
        public ActionResult Create(TestCard card)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Create(card);
                    return RedirectToAction("List");
                }
                catch
                {
                    return View();
                }
            }
            else return View(card);
        }

        // GET: TestCards/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListItem = repositoryAuths.GetAll();
            return View(repository.Get(id));
        }

        // POST: TestCards/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TestCard card)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(card);
                    return RedirectToAction("List");
                }
                catch
                {
                    return View();
                }
            }
            else return View(card);
        }

        // GET: TestCards/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestCards/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public PartialViewResult Side()
        {
            var databases = repositoryAuths
                .GetAll();

            return PartialView(databases);
        }
    }
}
