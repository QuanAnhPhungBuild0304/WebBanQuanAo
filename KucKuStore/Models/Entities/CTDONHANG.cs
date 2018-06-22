namespace KucKuStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDONHANG")]
    public partial class CTDONHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MACT { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MADH { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string MASP { get; set; }

        public int? SL { get; set; }

        public int? GIA { get; set; }

        public virtual DONHANG DONHANG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
