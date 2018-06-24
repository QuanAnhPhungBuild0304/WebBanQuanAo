using KucKuStore.Models.Entities;
using KucKuStore.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace KucKuStore.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        private const string CartSession = "CartSession";
        public ActionResult Shop(string id)
        {
            var item = new DANHMUCF().FindEntity(id);
            // ViewBag.DANHMUC = new DANHMUCF().DanhMUcs.ToList();
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();
            ViewBag.SANPHAM1 = new SANPHAMF().DSSanPham.Where(x => x.MADM.Contains(id)).ToList();
            
            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                ViewBag.Count = cart.Lines.Count();
            }
            else ViewBag.Count = 0;
                

            return View(item);
        }
        public ActionResult SPMoi(int? page)
        {
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();
            var model = new SANPHAMF().DSSanPham.ToList();


            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                ViewBag.Count = cart.Lines.Count();
            }
            else ViewBag.Count = 0;

            //Phân trang
            int pageSize = 9;
            int pageNum = (page ?? 1);
            return View(model.OrderBy(n=>n.GIA).ToPagedList(pageNum, pageSize));
        }
        public ActionResult ChiTietSP(int id)
        {
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();
            var model = new SANPHAMF().FindEntity(id);


            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                ViewBag.Count = cart.Lines.Count();
            }
            else ViewBag.Count = 0;

            return View(model);
        }
        
    }
}