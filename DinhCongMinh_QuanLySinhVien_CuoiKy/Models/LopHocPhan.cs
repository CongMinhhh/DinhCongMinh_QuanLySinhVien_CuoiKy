namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopHocPhan")]
    public partial class LopHocPhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopHocPhan()
        {
            SV_LHP = new HashSet<SV_LHP>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã lớp học phần")]
        public string MaLHP { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên lớp học phần")]
        public string TenLHP { get; set; }

        [Display(Name = "Số lượng")]
        public int? SoLuong { get; set; }

        [Display(Name = "Số tín chỉ")]
        public int? SoTinChi { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày bắt đầu")]
        public DateTime? NgayBatDau { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã giáo viên")]
        public string MaGV { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SV_LHP> SV_LHP { get; set; }
    }
}
