using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using KucKuStore.Models.Entities;
namespace KucKuStore.Areas.Admin.Controllers
{
    public class NhaCCAdminController : Controller
    {
        // GET: Admin/NhaCCAdmin
        DbContent db = new DbContent();
        public ActionResult Index(int? pageTemp)
        {
            int pageSize = 5;
            int pageNumb = pageTemp ?? 1;

            return View(db.NHACCs.ToList().OrderBy(a => a.TENNCC).ToPagedList(pageNumb, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NHACC ncc)
        {
            if (ModelState.IsValid)
            {
                db.NHACCs.Add(ncc);

                db.SaveChanges();
            }
            return View();
        }

    }
}