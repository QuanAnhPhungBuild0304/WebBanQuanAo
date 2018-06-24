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
    public class DanhMucAdminController : Controller
    {
        // GET: Admin/DanhMucAdmin
        DbContent db = new DbContent();
        public ActionResult Index(int? pageTemp)
        {
            int pageSize = 5;
            int pageNumb = pageTemp ?? 1;

            return View(db.DANHMUCs.ToList().OrderBy(a => a.TENDM).ToPagedList(pageNumb, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DANHMUC dm)
        {
            if (ModelState.IsValid)
            {
                // chèn dũ liệu vào bảng nguoidung trong model
                db.DANHMUCs.Add(dm);
                // lưu vào csdl
                db.SaveChanges();
            }
            return View();
        }
    }
}