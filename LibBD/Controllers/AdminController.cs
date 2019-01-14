using LibDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibBD.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IRepository<Author> repository;
        IRepository<Organization> repositoryOrg;

        public AdminController(IRepository<Author> repo, IRepository<Organization> repo1)
        {
            repository = repo;
            repositoryOrg = repo1;
        }


        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            var author = new Author();
            author.CardYear = DateTime.Now.Year;
            return View(author);
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Create(author);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else return View(author);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(author);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else return View(author);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Details(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Details(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repository.Get(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public PartialViewResult Organization()
        {
            return PartialView(repositoryOrg.GetAll().First());
        }


        public ActionResult OrganizationEdit(int id)
        {
            return View(repositoryOrg.Get(id));
        }

        // POST: Admin/OrganizationEdit/5
        [HttpPost]
        public ActionResult OrganizationEdit(Organization organization)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repositoryOrg.Update(organization);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else return View(organization);
        }
    }
}