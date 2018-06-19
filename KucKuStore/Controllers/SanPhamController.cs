using KucKuStore.Models.Entities;
using KucKuStore.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KucKuStore.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Shop()
        {
            ViewBag.DANHMUC = new DANHMUCF().DanhMUcs.ToList();
            return View();
        }
        public ActionResult Ao()
        {
            return View();
        }
        public ActionResult Quan()
        {
            return View();
        }
        public ActionResult Vay()
        {
            return View();
        }
        public ActionResult PhuKien()
        {
            return View();
        }
        public ActionResult ChiTietSP(string id)
        {
            return View();
        }
        public ActionResult ThanhToan()
        {
            return View();
        }
    }
}