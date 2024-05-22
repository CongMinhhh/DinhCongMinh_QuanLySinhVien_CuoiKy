using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Models
{
    public partial class DBSinhVienContext : DbContext
    {
        public DBSinhVienContext()
            : base("name=DBSinhVienContext")
        {
        }

        public virtual DbSet<GiaoVien> GiaoVien { get; set; }
        public virtual DbSet<Khoa> Khoa { get; set; }
        public virtual DbSet<LopHocPhan> LopHocPhan { get; set; }
        public virtual DbSet<LopSinhHoat> LopSinhHoat { get; set; }
        public virtual DbSet<SinhVien> SinhVien { get; set; }
        public virtual DbSet<SV_LHP> SV_LHP { get; set; }
        public virtual DbSet<Truong> Truong { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiaoVien>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<GiaoVien>()
                .Property(e => e.Gmail)
                .IsUnicode(false);

            modelBuilder.Entity<GiaoVien>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GiaoVien>()
                .Property(e => e.MaKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<Khoa>()
                .Property(e => e.MaKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<Khoa>()
                .Property(e => e.Gmail)
                .IsUnicode(false);

            modelBuilder.Entity<Khoa>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Khoa>()
                .Property(e => e.MaTruong)
                .IsUnicode(false);

            modelBuilder.Entity<LopHocPhan>()
                .Property(e => e.MaLHP)
                .IsUnicode(false);

            modelBuilder.Entity<LopHocPhan>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<LopSinhHoat>()
                .Property(e => e.MaLSH)
                .IsUnicode(false);

            modelBuilder.Entity<LopSinhHoat>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<LopSinhHoat>()
                .Property(e => e.MaKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MaSV)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.Gmail)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MaLSH)
                .IsUnicode(false);

            modelBuilder.Entity<SV_LHP>()
                .Property(e => e.MaLHP)
                .IsUnicode(false);

            modelBuilder.Entity<SV_LHP>()
                .Property(e => e.MaSV)
                .IsUnicode(false);

            modelBuilder.Entity<Truong>()
                .Property(e => e.MaTruong)
                .IsUnicode(false);

            modelBuilder.Entity<Truong>()
                .Property(e => e.Gmail)
                .IsUnicode(false);

            modelBuilder.Entity<Truong>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
