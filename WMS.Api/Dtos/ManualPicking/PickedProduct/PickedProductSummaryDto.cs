using System;

namespace WMS.Api.Dtos.ManualPicking.PickedProduct;

/// <summary>Summarizes a product line recorded on a manual pick order.</summary>
public record class PickedProductSummaryDto
(
    /// <param name="id">The picked-product line ID.</param>
    int id,
    /// <param name="Name">The name of the received product.</param>
    string Name,
    /// <param name="QuantityPicked">The quantity picked from inventory.</param>
    int QuantityPicked,
    /// <param name="DatePicked">The date and time when the product was picked.</param>
    DateTime DatePicked
);