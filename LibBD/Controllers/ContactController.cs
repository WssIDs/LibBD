using LibDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibBD.Controllers
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
        public ActionResult Edit(Organization organization, HttpPostedFileBase imageUploadHeritage = null, HttpPostedFileBase imageUploadCulture = null, HttpPostedFileBase imageUploadHistory = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUploadHeritage != null)
                {
                    var count = imageUploadHeritage.ContentLength;
                    organization.ImageHeritage = new byte[count];
                    imageUploadHeritage.InputStream.Read(organization.ImageHeritage, 0, (int)count);
                    organization.MimeTypeHeritage = imageUploadHeritage.ContentType;
                }
                if (imageUploadCulture != null)
                {
                    var count = imageUploadCulture.ContentLength;
                    organization.ImageCulture = new byte[count];
                    imageUploadCulture.InputStream.Read(organization.ImageCulture, 0, (int)count);
                    organization.MimeTypeCulture = imageUploadCulture.ContentType;
                }
                if (imageUploadHistory != null)
                {
                    var count = imageUploadHistory.ContentLength;
                    organization.ImageHistory = new byte[count];
                    imageUploadHistory.InputStream.Read(organization.ImageHistory, 0, (int)count);
                    organization.MimeTypeHistory = imageUploadHistory.ContentType;
                }
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

        public async Task<FileResult> GetImage(int id, int type)
        {
            var org = await repository.GetAsync(id);
            if (org != null)
            {
                if (type == 1)
                {
                    return new FileContentResult(org.ImageHeritage, org.MimeTypeHeritage);
                }
                else if (type == 2)
                {
                    return new FileContentResult(org.ImageCulture, org.MimeTypeCulture);
                }
                else if (type == 3)
                {
                    return new FileContentResult(org.ImageHistory, org.MimeTypeHistory);
                }
                else
                {
                    return null;
                }
            }
            else return null;
        }
    }
}