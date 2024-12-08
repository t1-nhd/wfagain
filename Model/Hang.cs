namespace test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hang")]
    public partial class Hang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hang()
        {
            NhapChiTiets = new HashSet<NhapChiTiet>();
            XuatChiTiets = new HashSet<XuatChiTiet>();
        }

        [Key]
        [StringLength(20)]
        public string MaH { get; set; }

        [Required]
        [StringLength(100)]
        public string TenH { get; set; }

        [Column(TypeName = "money")]
        public decimal DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhapChiTiet> NhapChiTiets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XuatChiTiet> XuatChiTiets { get; set; }
    }
}
