namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopSinhHoat")]
    public partial class LopSinhHoat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopSinhHoat()
        {
            SinhVien = new HashSet<SinhVien>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã lớp sinh hoạt")]
        public string MaLSH { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên lớp sinh hoạt")]
        public string TenLSH { get; set; }

        [Display(Name = "Số lượng")]
        public int? SoLuong { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã giáo viên")]
        public string MaGV { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã khoa")]
        public string MaKhoa { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        public virtual Khoa Khoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVien> SinhVien { get; set; }
    }
}
