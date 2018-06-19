namespace KucKuStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAND { get; set; }

        [StringLength(10)]
        public string TENDN { get; set; }

        [StringLength(10)]
        public string MATKHAU { get; set; }

        [StringLength(10)]
        public string QUYEN { get; set; }
    }
}
