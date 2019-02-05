using LibDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibDB.Controllers
{
    public class ContactController : Controller
    {
        IRepository<Organization> repository;

        public ContactController(IRepository<Organization> repo)
        {
            repository = repo;
        }

        // GET: Contact
        public ActionResult Index()
        {
            return View(repository.GetAll().First());
        }

        [Authorize(Roles = "admin")]
        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        [Authorize(Roles = "admin")]
        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Organization organization)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(organization);
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