using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace test.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Hang> Hangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NguoiBan> NguoiBans { get; set; }
        public virtual DbSet<Nhap> Nhaps { get; set; }
        public virtual DbSet<NhapChiTiet> NhapChiTiets { get; set; }
        public virtual DbSet<Xuat> Xuats { get; set; }
        public virtual DbSet<XuatChiTiet> XuatChiTiets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hang>()
                .Property(e => e.MaH)
                .IsUnicode(false);

            modelBuilder.Entity<Hang>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hang>()
                .HasMany(e => e.NhapChiTiets)
                .WithRequired(e => e.Hang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hang>()
                .HasMany(e => e.XuatChiTiets)
                .WithRequired(e => e.Hang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.Xuats)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiBan>()
                .Property(e => e.MaNB)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiBan>()
                .HasMany(e => e.Nhaps)
                .WithRequired(e => e.NguoiBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nhap>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<Nhap>()
                .Property(e => e.MaNB)
                .IsUnicode(false);

            modelBuilder.Entity<Nhap>()
                .Property(e => e.CongTH)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Nhap>()
                .Property(e => e.TongTT)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Nhap>()
                .HasMany(e => e.NhapChiTiets)
                .WithRequired(e => e.Nhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhapChiTiet>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<NhapChiTiet>()
                .Property(e => e.MaH)
                .IsUnicode(false);

            modelBuilder.Entity<NhapChiTiet>()
                .Property(e => e.DonGiaNhap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Xuat>()
                .Property(e => e.MaHDX)
                .IsUnicode(false);

            modelBuilder.Entity<Xuat>()
                .Property(e => e.TongCong)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Xuat>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<Xuat>()
                .HasMany(e => e.XuatChiTiets)
                .WithRequired(e => e.Xuat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XuatChiTiet>()
                .Property(e => e.MaHDX)
                .IsUnicode(false);

            modelBuilder.Entity<XuatChiTiet>()
                .Property(e => e.MaH)
                .IsUnicode(false);
        }
    }
}
