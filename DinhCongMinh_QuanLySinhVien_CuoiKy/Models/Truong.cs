namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Truong")]
    public partial class Truong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Truong()
        {
            Khoa = new HashSet<Khoa>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã trường")]
        public string MaTruong { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên trường")]
        public string TenTruong { get; set; }

        [StringLength(50)]
        [Display(Name = "Gmail")]
        public string Gmail { get; set; }

        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Khoa> Khoa { get; set; }
    }
}
