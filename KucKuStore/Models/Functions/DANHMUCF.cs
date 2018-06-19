using KucKuStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KucKuStore.Models.Functions
{
    public class DANHMUCF
    {
        private DbContent context;

        public DANHMUCF()
        {
            context = new DbContent();
        }

        // Trả về danh muc
        public IQueryable<DANHMUC> DanhMUcs
        {
            get { return context.DANHMUCs; }
        }
    }
}