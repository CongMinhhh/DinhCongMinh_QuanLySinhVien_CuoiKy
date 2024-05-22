namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            SV_LHP = new HashSet<SV_LHP>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã sinh viên")]
        public string MaSV { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ và tên")]
        public string TenSinhVien { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(10)]
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        [Display(Name = "Quê quán")]
        public string QueQuan { get; set; }

        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ Gmail")]
        public string Gmail { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã lớp sinh hoạt")]
        public string MaLSH { get; set; }

        public virtual LopSinhHoat LopSinhHoat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SV_LHP> SV_LHP { get; set; }
    }
}
