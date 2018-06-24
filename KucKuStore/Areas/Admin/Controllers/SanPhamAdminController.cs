using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using KucKuStore.Models.Entities;
using System.IO;

namespace KucKuStore.Areas.Admin.Controllers
{
    public class SanPhamAdminController : Controller
    {
        // GET: Admin/SanPhamAdmin
        DbContent db = new DbContent();
        public ActionResult Index(int? pageTemp)
        {
            int pageSize = 5;
            int pageNumb = pageTemp ?? 1;

            return View(db.SANPHAMs.ToList().OrderBy(a => a.TENSP).ToPagedList(pageNumb, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            //Đưa dữ liệu vào dropdownlisst
            ViewBag.MADM = new SelectList(db.DANHMUCs.ToList().OrderBy(n => n.TENDM), "MADM", "TENDM");
            ViewBag.MANCC = new SelectList(db.NHACCs.ToList().OrderBy(n => n.TENNCC), "MANCC", "TENNCC");
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SANPHAM sp, HttpPostedFileBase fileanh, HttpPostedFileBase fileanhkhac)
        {

            ViewBag.MADM = new SelectList(db.DANHMUCs.ToList().OrderBy(n => n.TENDM), "MADM", "TENDM");
            ViewBag.MANCC = new SelectList(db.NHACCs.ToList().OrderBy(n => n.TENNCC), "MANCC", "TENNCC");

            if (fileanh == null || fileanhkhac == null)
            {
                ViewBag.ThongBao = "Chọn ảnh!";
                return View();
            }
            if (ModelState.IsValid)
            {
                //lưu tên file
                var filename = Path.GetFileName(fileanh.FileName);
                var filenamekhac = Path.GetFileName(fileanhkhac.FileName);
                //lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/Content/img/product-img"), filename);
                var pathkhac = Path.Combine(Server.MapPath("~/Content/img/product-img"), filenamekhac);
                //kiểm tra hình ảnh dã tồn tại chưa
                if (System.IO.File.Exists(path) || System.IO.File.Exists(pathkhac))
                {
                    ViewBag.ThongBao = "Đã tồn tại hình ảnh";
                }
                else
                {
                    fileanh.SaveAs(path);
                    fileanh.SaveAs(pathkhac);
                }
                sp.HINHANH = fileanh.FileName;
                sp.HINHANHKHAC = fileanhkhac.FileName;
                db.SANPHAMs.Add(sp);
                db.SaveChanges();
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int MASP)
        {
            // lấy ra đt sp theo mã
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == MASP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MADM = new SelectList(db.DANHMUCs.ToList().OrderBy(n => n.TENDM), "MADM", "TENDM", sp.MADM);
            ViewBag.MANCC = new SelectList(db.NHACCs.ToList().OrderBy(n => n.TENNCC), "MANCC", "TENNCC", sp.MANCC);

            return View(sp);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SANPHAM sp, HttpPostedFileBase fileanh, HttpPostedFileBase fileanhkhac)
        {

            if (fileanh == null || fileanhkhac == null)
            {
                ViewBag.ThongBao = "Chọn ảnh!";
                return View();
            }
            if (ModelState.IsValid)
            {
                //lưu tên file
                var filename = Path.GetFileName(fileanh.FileName);
                var filenamekhac = Path.GetFileName(fileanhkhac.FileName);
                //lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/Content/img/product-img"), filename);
                var pathkhac = Path.Combine(Server.MapPath("~/Content/img/product-img"), filenamekhac);
                //kiểm tra hình ảnh dã tồn tại chưa
                if (System.IO.File.Exists(path) || System.IO.File.Exists(pathkhac))
                {
                    ViewBag.ThongBao = "Đã tồn tại hình ảnh";
                }
                else
                {
                    fileanh.SaveAs(path);
                    fileanh.SaveAs(pathkhac);
                }
                sp.HINHANH = fileanh.FileName;
                sp.HINHANHKHAC = fileanhkhac.FileName;
                // cập nhật thay đổi vào model
                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            ViewBag.MADM = new SelectList(db.DANHMUCs.ToList().OrderBy(n => n.TENDM), "MADM", "TENDM", sp.MADM);
            ViewBag.MANCC = new SelectList(db.NHACCs.ToList().OrderBy(n => n.TENNCC), "MANCC", "TENNCC", sp.MANCC);

            return RedirectToAction("Index");
        }

        public ActionResult HienThi(int MASP)
        {
            // lấy ra đt sp theo mã
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == MASP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(sp);
        }

        [HttpGet]
        public ActionResult Xoa(int MASP)
        {
            // lấy ra đt sp theo mã
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == MASP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(sp);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacnhanXoa(int MASP)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == MASP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SANPHAMs.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}