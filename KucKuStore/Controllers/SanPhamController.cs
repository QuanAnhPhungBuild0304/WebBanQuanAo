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
        public ActionResult Ao(string id)
        {
            var model = new SANPHAMF().DSSanPham.Where(x => x.MADM.Contains("A")).ToList();
            return View(model);
        }
        public ActionResult Quan(string id)
        {
            var model = new SANPHAMF().DSSanPham.Where(x => x.MADM.Contains("Q")).ToList();
            return View(model);
        }
        public ActionResult Vay(string id)
        {
            var model = new SANPHAMF().DSSanPham.Where(x => x.MADM.Contains("V")).ToList();
            return View(model);
        }
        public ActionResult PhuKien()
        {
            var model = new SANPHAMF().DSSanPham.Where(x => x.MADM.Contains("PK")).ToList();
            return View(model);
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