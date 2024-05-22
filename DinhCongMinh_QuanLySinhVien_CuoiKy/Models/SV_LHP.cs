namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SV_LHP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        [Display(Name = "Mã lớp học phần")]
        public string MaLHP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        [Display(Name = "Mã sinh viên")]
        public string MaSV { get; set; }

        [Display(Name = "Điểm học phần")]
        public int? DiemHocPhan { get; set; }

        public virtual LopHocPhan LopHocPhan { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
