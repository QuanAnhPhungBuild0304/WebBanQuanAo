using KucKuStore.Models.Entities;
using KucKuStore.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KucKuStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();
            var model = new SANPHAMF().DSSanPham.ToList();
            ViewBag.DANHMUC = new DANHMUCF().DanhMUcs.ToList();
            return View(model);
        }

    
    }
}