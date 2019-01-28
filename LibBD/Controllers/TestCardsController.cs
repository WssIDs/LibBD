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

        public ActionResult List(int group)
        {
            var lst = repository.GetAll().Where(a => a.AuthId == group);
            return View(lst);
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
                    return RedirectToAction("Index");
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
                    return RedirectToAction("Index");
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
    }
}
