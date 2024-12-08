namespace test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiBan")]
    public partial class NguoiBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiBan()
        {
            Nhaps = new HashSet<Nhap>();
        }

        [Key]
        [StringLength(20)]
        public string MaNB { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNB { get; set; }

        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nhap> Nhaps { get; set; }
    }
}
