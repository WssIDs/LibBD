using LibDB.Models;
using LibDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibDB.Controllers
{
    public class TestCardsController : Controller
    {
        IRepository<TestCard> repositoryCards;
        IRepository<TestBase> repositoryBases;

        int pageSize = 7;

        public TestCardsController(IRepository<TestCard> repoCard, IRepository<TestBase> repoBase)
        {
            repositoryCards = repoCard;
            repositoryBases = repoBase;
        }

        public ActionResult List(string maingroup, string group,string searchtext, int page = 1)
        {
            ViewBag.ListItem = repositoryBases.GetAll();

            PageListViewModel<TestCard> model;

            if (!string.IsNullOrEmpty(maingroup))
            {
                if (!string.IsNullOrEmpty(searchtext))
                {
                    var nlst = repositoryCards.GetAll().Where(a => a.BaseId == Convert.ToInt32(maingroup) && group == null
                                                            || a.Year == Convert.ToInt32(group))
                                                            .OrderBy(d => d.Title)
                                                            .OrderByDescending(d => d.Year);

                    var lstnew = nlst.Where(s => s.Title.Contains(searchtext)
                    || !string.IsNullOrEmpty(s.Header) && s.Header.Contains(searchtext)
                    || !string.IsNullOrEmpty(s.Body) && s.Body.Contains(searchtext)
                    || !string.IsNullOrEmpty(s.Description) && s.Description.Contains(searchtext)
                    );

                    model = PageListViewModel<TestCard>.CreatePage(lstnew, page, pageSize);

                }
                else
                {
                    var nlst = repositoryCards.GetAll().Where(a => a.BaseId == Convert.ToInt32(maingroup) && group == null
                                                            || a.BaseId == Convert.ToInt32(maingroup) && a.Year == Convert.ToInt32(group))
                                                            .OrderBy(d => d.Title)
                                                            .OrderByDescending(d => d.Year);

                    model = PageListViewModel<TestCard>.CreatePage(nlst, page, pageSize);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(searchtext))
                {
                    var nlst = repositoryCards.GetAll().Where(a => group == null
                                        || a.Year == Convert.ToInt32(group))
                                        .OrderBy(d => d.Title)
                                        .OrderByDescending(d => d.Year);

                    var lstnew = nlst.Where(s => s.Title.Contains(searchtext)
                    || !string.IsNullOrEmpty(s.Header) && s.Header.Contains(searchtext)
                    || !string.IsNullOrEmpty(s.Body) && s.Body.Contains(searchtext)
                    || !string.IsNullOrEmpty(s.Description) && s.Description.Contains(searchtext)
                    );

                    model = PageListViewModel<TestCard>.CreatePage(lstnew, page, pageSize);

                }
                else
                {
                    var nlst = repositoryCards.GetAll().Where(a => group == null
                                        || a.Year == Convert.ToInt32(group))
                                        .OrderBy(d => d.Title)
                                        .OrderByDescending(d => d.Year);

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
            var card = new TestCard();
            card.Year = DateTime.Now.Year;
            ViewBag.ListItem = repositoryBases.GetAll();
            return View(card);
        }

        // POST: TestCards/Create
        [HttpPost]
        public ActionResult Create(TestCard card)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repositoryCards.Create(card);
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
            ViewBag.ListItem = repositoryBases.GetAll();
            return View(repositoryCards.Get(id));
        }

        // POST: TestCards/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TestCard card)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repositoryCards.Update(card);
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
            return View(repositoryCards.Get(id));
        }

        // POST: TestCards/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repositoryCards.Delete(id);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        public PartialViewResult Side(string maingroup)
        {
            var databases = repositoryBases
                .GetAll();

            var group = repositoryCards
                        .GetAll()
                        .Where(a => maingroup == null || maingroup == "Все"
                        || a.BaseId == Convert.ToInt32(maingroup))
                        .OrderByDescending(d => d.Year)
                        .Select(d => d.Year)
                        .Distinct();

            ViewBag.Years = group;

            return PartialView(databases);
        }
    }
}
