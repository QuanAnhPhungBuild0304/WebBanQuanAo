namespace KucKuStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CTDONHANGs = new HashSet<CTDONHANG>();
        }

        [Key]
        [StringLength(10)]
        public string MASP { get; set; }

        [StringLength(200)]
        public string TENSP { get; set; }

        [StringLength(10)]
        public string MADM { get; set; }

        [StringLength(500)]
        public string MOTA { get; set; }

        [StringLength(200)]
        public string HINHANH { get; set; }

        [Column(TypeName = "xml")]
        public string HINHANHKHAC { get; set; }

        public int? GIA { get; set; }

        public string CHITIET { get; set; }

        public int? SOLUONG { get; set; }

        [StringLength(200)]
        public string TRANGTHAI { get; set; }

        public DateTime? SPHOT { get; set; }

        [StringLength(50)]
        public string MAUSAC { get; set; }

        [StringLength(10)]
        public string KICHCO { get; set; }

        [StringLength(50)]
        public string THUONGHIEU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }

        public virtual DANHMUC DANHMUC { get; set; }
    }
}
