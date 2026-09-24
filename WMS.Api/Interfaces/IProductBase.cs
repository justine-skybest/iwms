using Microsoft.EntityFrameworkCore;
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
        public required string CBM { get; set; }

        public required string TotalWeight { get; set; }
        public DateOnly? ExpirationDate { get; set; }

        public string? Supplier { get; set; }
        public string? Remarks { get; set; }
    }
}
