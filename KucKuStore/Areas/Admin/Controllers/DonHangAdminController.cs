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
    public class DonHangAdminController : Controller
    {
        // GET: Admin/DonHangAdmin
        DbContent db = new DbContent();
        public ActionResult Index(int? pageTemp)
        {
            int pageSize = 5;
            int pageNumb = pageTemp ?? 1;

            return View(db.DONHANGs.ToList().OrderBy(a => a.MADH).ToPagedList(pageNumb, pageSize));
        }
    }
}