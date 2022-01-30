using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataPapi.Models
{
    [Keyless]
    [Table("FactOnlineSales", Schema = "cso")]
    public partial class FactOnlineSale
    {
        public int OnlineSalesKey { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateKey { get; set; }
        public int StoreKey { get; set; }
        public int ProductKey { get; set; }
        public int PromotionKey { get; set; }
        public int CurrencyKey { get; set; }
        public int CustomerKey { get; set; }
        [StringLength(20)]
        public string SalesOrderNumber { get; set; } = null!;
        public int? SalesOrderLineNumber { get; set; }
        public int SalesQuantity { get; set; }
        [Column(TypeName = "money")]
        public decimal SalesAmount { get; set; }
        public int ReturnQuantity { get; set; }
        [Column(TypeName = "money")]
        public decimal? ReturnAmount { get; set; }
        public int? DiscountQuantity { get; set; }
        [Column(TypeName = "money")]
        public decimal? DiscountAmount { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalCost { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnitCost { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        [Column("ETLLoadID")]
        public int? EtlloadId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LoadDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
    }
}
