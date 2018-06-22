using KucKuStore.Models.Entities;
using KucKuStore.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace KucKuStore.Controllers
{
    public class CartController : Controller
    {// GET: Cart
        private const string CartSession = "CartSession";
        DbContent db = new DbContent();
        public ActionResult GioHang()
        {
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();

            var cart = (Cart)Session[CartSession];

            var list = new List<CartItem>();

            if (cart != null)
            {
                ViewBag.list = cart.Lines.ToList();
                ViewBag.Count = cart.Lines.Count();
                TempData["CountBag"] = ViewBag.Count;
                TempData.Keep("CountBag");
                ViewBag.TongTien = cart.ComputeTotalValue();
            }

            return View(list);
        }
        public ActionResult AddItem(string Id, string returnURL)
        {

            var product = new SANPHAMF().FindEntity(Id);

            var cart = (Cart)Session[CartSession];

            if (cart != null)
            {
                cart.AddItem(product, 1);
                //Gán vào session
                Session[CartSession] = cart;
                //return Redirect(returnURL);
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1);
                //Gán vào session
                Session[CartSession] = cart;
                //return Redirect(returnURL);
            }

            if (string.IsNullOrEmpty(returnURL))
            {
                return RedirectToAction("GioHang");
            }

            return Redirect(returnURL);
        } 
        public ActionResult ThanhToan()
        {
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();
            return View();
        }
    }
}