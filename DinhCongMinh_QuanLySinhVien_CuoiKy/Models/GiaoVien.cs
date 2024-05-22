namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaoVien")]
    public partial class GiaoVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiaoVien()
        {
            LopHocPhan = new HashSet<LopHocPhan>();
            LopSinhHoat = new HashSet<LopSinhHoat>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã giáo viên")]
        public string MaGV { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên giáo viên")]
        public string TenGiaoVien { get; set; }

        [StringLength(50)]
        [Display(Name = "Gmail")]
        public string Gmail { get; set; }

        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã Khoa")]
        public string MaKhoa { get; set; }

        public virtual Khoa Khoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHocPhan> LopHocPhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopSinhHoat> LopSinhHoat { get; set; }
    }
}
