namespace test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhap")]
    public partial class Nhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhap()
        {
            NhapChiTiets = new HashSet<NhapChiTiet>();
        }

        [Key]
        [StringLength(20)]
        public string MaHD { get; set; }

        [Required]
        [StringLength(20)]
        public string MaNB { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayNhap { get; set; }

        [Column(TypeName = "money")]
        public decimal CongTH { get; set; }

        public double ThueSuatGTGT { get; set; }

        [Column(TypeName = "money")]
        public decimal TongTT { get; set; }

        public virtual NguoiBan NguoiBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhapChiTiet> NhapChiTiets { get; set; }
    }
}
