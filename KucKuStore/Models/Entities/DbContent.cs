namespace KucKuStore.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbContent : DbContext
    {
        public DbContent()
            : base("name=DbContent")
        {
        }

        public virtual DbSet<CTDONHANG> CTDONHANGs { get; set; }
        public virtual DbSet<DANHMUC> DANHMUCs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<KHUYENMAI> KHUYENMAIs { get; set; }
        public virtual DbSet<LIENHE> LIENHEs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<SLIDER> SLIDERs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTDONHANG>()
                .Property(e => e.MACT)
                .IsFixedLength();

            modelBuilder.Entity<CTDONHANG>()
                .Property(e => e.MADH)
                .IsFixedLength();

            modelBuilder.Entity<CTDONHANG>()
                .Property(e => e.MASP)
                .IsFixedLength();

            modelBuilder.Entity<DANHMUC>()
                .Property(e => e.MADM)
                .IsFixedLength();

            modelBuilder.Entity<DANHMUC>()
                .Property(e => e.TIEUDENGAN)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MADH)
                .IsFixedLength();

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MAKH)
                .IsFixedLength();

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.DIENTHOAI)
                .IsFixedLength();

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.EMAIL)
                .IsFixedLength();

            modelBuilder.Entity<DONHANG>()
                .HasMany(e => e.CTDONHANGs)
                .WithRequired(e => e.DONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHUYENMAI>()
                .Property(e => e.MAKM)
                .IsFixedLength();

            modelBuilder.Entity<LIENHE>()
                .Property(e => e.MALH)
                .IsFixedLength();

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.TENDN)
                .IsFixedLength();

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.MATKHAU)
                .IsFixedLength();

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.QUYEN)
                .IsFixedLength();

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MASP)
                .IsFixedLength();

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MADM)
                .IsFixedLength();

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.KICHCO)
                .IsFixedLength();

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CTDONHANGs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SLIDER>()
                .Property(e => e.MASD)
                .IsFixedLength();
        }
    }
}
