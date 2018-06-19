using KucKuStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KucKuStore.Models.Functions
{
    public class SANPHAMF
    {
        private DbContent context;

        public SANPHAMF()
        {
            context = new DbContent();
        }

        // Trả về danh muc
        public IQueryable<SANPHAM> DSSanPham
        {
            get { return context.SANPHAMs; }
        }
        public List<SANPHAM> GetList()
        {
            return context.SANPHAMs.ToList();
        }

    }
}