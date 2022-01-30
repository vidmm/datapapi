using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataPapi.Models
{
    [Keyless]
    [Table("DimProduct", Schema = "cso")]
    public partial class DimProduct
    {
        public int ProductKey { get; set; }
        [StringLength(255)]
        public string? ProductLabel { get; set; }
        [StringLength(500)]
        public string? ProductName { get; set; }
        [StringLength(400)]
        public string? ProductDescription { get; set; }
        public int? ProductSubcategoryKey { get; set; }
        [StringLength(50)]
        public string? Manufacturer { get; set; }
        [StringLength(50)]
        public string? BrandName { get; set; }
        [Column("ClassID")]
        [StringLength(10)]
        public string? ClassId { get; set; }
        [StringLength(20)]
        public string? ClassName { get; set; }
        [Column("StyleID")]
        [StringLength(10)]
        public string? StyleId { get; set; }
        [StringLength(20)]
        public string? StyleName { get; set; }
        [Column("ColorID")]
        [StringLength(10)]
        public string? ColorId { get; set; }
        [StringLength(20)]
        public string ColorName { get; set; } = null!;
        [StringLength(50)]
        public string? Size { get; set; }
        [StringLength(50)]
        public string? SizeRange { get; set; }
        [Column("SizeUnitMeasureID")]
        [StringLength(20)]
        public string? SizeUnitMeasureId { get; set; }
        public double? Weight { get; set; }
        [Column("WeightUnitMeasureID")]
        [StringLength(20)]
        public string? WeightUnitMeasureId { get; set; }
        [Column("UnitOfMeasureID")]
        [StringLength(10)]
        public string? UnitOfMeasureId { get; set; }
        [StringLength(40)]
        public string? UnitOfMeasureName { get; set; }
        [Column("StockTypeID")]
        [StringLength(10)]
        public string? StockTypeId { get; set; }
        [StringLength(40)]
        public string? StockTypeName { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnitCost { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AvailableForSaleDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StopSaleDate { get; set; }
        [StringLength(7)]
        public string? Status { get; set; }
        [Column("ImageURL")]
        [StringLength(150)]
        public string? ImageUrl { get; set; }
        [Column("ProductURL")]
        [StringLength(150)]
        public string? ProductUrl { get; set; }
        [Column("ETLLoadID")]
        public int? EtlloadId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LoadDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
    }
}
