namespace test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XuatChiTiet")]
    public partial class XuatChiTiet
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MaHDX { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaH { get; set; }

        public int SoLuong { get; set; }

        public virtual Hang Hang { get; set; }

        public virtual Xuat Xuat { get; set; }
    }
}
