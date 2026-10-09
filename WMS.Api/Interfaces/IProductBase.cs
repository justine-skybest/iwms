using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using WMS.Api.Entities;

namespace WMS.Api.Interfaces
{
    public abstract class IProductBase
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal? UnitPrice { get; set; }
        [Precision(18, 2)]
        public decimal? TotalAmount { get; set; }

        [Precision(18, 4)]
        public decimal? CBM { get; set; }

        [Precision(18, 6)]
        public decimal? Weight { get; set; }

        [NotMapped]
        public decimal TotalWeight => Math.Round((Weight ?? 0m) * Quantity, 2, MidpointRounding.AwayFromZero);

        [Precision(18, 4)]
        [NotMapped]
        public decimal? TotalCbm => CBM.HasValue ? CBM.Value * Quantity : null;
        public DateOnly? ExpirationDate { get; set; }

        public string? Supplier { get; set; }
        public string? Remarks { get; set; }
    }
}
