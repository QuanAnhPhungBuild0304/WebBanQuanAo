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
            var model = new SANPHAMF().DSSanPham.ToList();
            ViewBag.DANHMUC = new DANHMUCF().DanhMUcs.ToList();
            return View(model);
        }

    
    }
}