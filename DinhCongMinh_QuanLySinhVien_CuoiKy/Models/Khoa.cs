namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Khoa")]
    public partial class Khoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khoa()
        {
            GiaoVien = new HashSet<GiaoVien>();
            LopSinhHoat = new HashSet<LopSinhHoat>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã Khoa")]
        public string MaKhoa { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên Khoa")]
        public string TenKhoa { get; set; }

        [StringLength(50)]
        [Display(Name = "Gmail")]
        public string Gmail { get; set; }

        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã trường")]
        public string MaTruong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiaoVien> GiaoVien { get; set; }

        public virtual Truong Truong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopSinhHoat> LopSinhHoat { get; set; }
    }
}
