namespace test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Xuat")]
    public partial class Xuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Xuat()
        {
            XuatChiTiets = new HashSet<XuatChiTiet>();
        }

        [Key]
        [StringLength(20)]
        public string MaHDX { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayXK { get; set; }

        [Column(TypeName = "money")]
        public decimal TongCong { get; set; }

        [Required]
        [StringLength(20)]
        public string MaKH { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XuatChiTiet> XuatChiTiets { get; set; }
    }
}
