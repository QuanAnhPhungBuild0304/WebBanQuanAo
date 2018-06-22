namespace KucKuStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SLIDER")]
    public partial class SLIDER
    {
        [Key]
        [StringLength(10)]
        public string MASD { get; set; }

        [StringLength(250)]
        public string HINHANH { get; set; }

        public int? VITRI { get; set; }

        [StringLength(250)]
        public string MOTA1 { get; set; }

        [StringLength(250)]
        public string MOTA2 { get; set; }

        public bool? TRANGTHAI { get; set; }
    }
}
