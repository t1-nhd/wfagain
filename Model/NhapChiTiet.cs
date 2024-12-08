namespace test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhapChiTiet")]
    public partial class NhapChiTiet
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaH { get; set; }

        [Column(TypeName = "money")]
        public decimal DonGiaNhap { get; set; }

        public int SoLuong { get; set; }

        public virtual Hang Hang { get; set; }

        public virtual Nhap Nhap { get; set; }
    }
}
