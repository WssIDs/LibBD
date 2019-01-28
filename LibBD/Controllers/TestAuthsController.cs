using LibDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibBD.Controllers
{
    public class TestAuthsController : Controller
    {
        IRepository<TestAuth> repository;

        public TestAuthsController(IRepository<TestAuth> repo)
        {
            repository = repo;
        }

        // GET: TestAuths
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: TestAuths/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.Get(id));
        }

        // GET: TestAuths/Create
        public ActionResult Create()
        {
            var auth = new TestAuth();
            return View(auth);
        }

        // POST: TestAuths/Create
        [HttpPost]
        public ActionResult Create(TestAuth auth)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Create(auth);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else return View(auth);
        }

        // GET: TestAuths/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestAuths/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestAuths/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestAuths/Delete/5
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
