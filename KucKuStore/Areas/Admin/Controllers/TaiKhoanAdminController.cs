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
    public class TaiKhoanAdminController : Controller
    {
        // GET: Admin/TaiKhoanAdmin
   
        DbContent db = new DbContent();
        public ActionResult Index(int? pageTemp)
        {
            int pageSize = 5;
            int pageNumb = pageTemp ?? 1;

            return View(db.NGUOIDUNGs.ToList().OrderBy(a => a.TENDN).ToPagedList(pageNumb, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult Create(NGUOIDUNG acc)
        {
            if (ModelState.IsValid)
            {
                // chèn dũ liệu vào bảng nguoidung trong model
                db.NGUOIDUNGs.Add(acc);
                // lưu vào csdl
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DangNhap(FormCollection f)
        {
            string sUsername = f["username"].ToString();
            string sMK = f.Get("pass").ToString();
            NGUOIDUNG ng = db.NGUOIDUNGs.SingleOrDefault(n => n.TENDN == sUsername && n.MATKHAU == sMK);

            if(ng != null)
            {
               
                Session["taikhoan"] = ng; // gán session là cẩ đối tượng ng
                //return View("Index","SanPhamAdmin");
                return RedirectToAction("Index");
            }
            ViewBag.ThongBao = "Đăng nhập sai! Vui lòng kiểm tra lại.";
            return View("DangNhap");
            
        }
    }
}