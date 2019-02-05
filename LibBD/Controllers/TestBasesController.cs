using LibDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibDB.Controllers
{
    public class TestBasesController : Controller
    {
        IRepository<TestBase> repository;

        public TestBasesController(IRepository<TestBase> repo)
        {
            repository = repo;
        }

        // GET: TestAuths/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.Get(id));
        }

        // GET: TestAuths/Create
        public ActionResult Create()
        {
            var mbase = new TestBase();
            return View(mbase);
        }

        // POST: TestAuths/Create
        [HttpPost]
        public ActionResult Create(TestBase mbase)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Create(mbase);
                    return RedirectToAction("Index","Home");
                }
                catch
                {
                    return View();
                }
            }
            else return View(mbase);
        }

        // GET: TestAuths/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: TestAuths/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TestBase mbase)
        {
            try
            {
                // TODO: Add update logic here
                repository.Update(mbase);
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestAuths/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        // POST: TestAuths/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repository.Delete(id);
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
