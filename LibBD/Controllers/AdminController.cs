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
        IRepository<Card> repositoryHeritage;
        IRepository<Card> repository;
        //IRepository<Author> repository;

        public AdminController(IRepository<Card> repo)
        {
            repository = repo;
            repositoryHeritage = repo;
        }


        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        public ActionResult Heritage()
        {
            return View(repositoryHeritage.GetAll());
        }

        // GET: Admin/HeritageCreate
        public ActionResult HeritageCreate()
        {
            var author = new Card();
            author.Year = DateTime.Now.Year;
            author.Title = RandomString(7);
            author.Description = RandomString(30);
            author.FirstName = RandomString(8);
            author.LastName = RandomString(10);

            return View(author);
        }

        // POST: Admin/HeritageCreate
        [HttpPost]
        public ActionResult HeritageCreate(Card author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repositoryHeritage.Create(author);
                    return RedirectToAction("Heritage");
                }
                catch
                {
                    return View();
                }
            }
            else return View(author);
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // GET: Admin/Edit/5
        public ActionResult HeritageEdit(int id)
        {
            return View(repositoryHeritage.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult HeritageEdit(Card author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repositoryHeritage.Update(author);
                    return RedirectToAction("Heritage");
                }
                catch
                {
                    return View();
                }
            }
            else return View(author);
        }

        // GET: Admin/Delete/5
        public ActionResult HeritageDelete(int id)
        {
            return View(repositoryHeritage.Get(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult HeritageDelete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repositoryHeritage.Delete(id);
                return RedirectToAction("Heritage");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult HeritageDetails(int id)
        {
            return View(repositoryHeritage.Get(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult HeritageDetails(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repositoryHeritage.Get(id);
                return RedirectToAction("Heritage");
            }
            catch
            {
                return View();
            }
        }

        /**************************************************/

        // GET: Admin/Create
        public ActionResult Create()
        {
            var author = new Card();
            author.Year = DateTime.Now.Year;
            return View(author);
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Card author)
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
        public ActionResult Edit(Card author)
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
    }
}