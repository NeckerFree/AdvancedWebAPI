using System;
using System.Collections.Generic;

namespace AWA.Models;

/// <summary>
/// Unit of measure lookup table.
/// </summary>
public partial class UnitMeasure
{
    /// <summary>
    /// Primary key.
    /// </summary>
    public string UnitMeasureCode { get; set; } = null!;

    /// <summary>
    /// Unit of measure description.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<BillOfMaterial> BillOfMaterials { get; } = new List<BillOfMaterial>();

    public virtual ICollection<Product> ProductSizeUnitMeasureCodeNavigations { get; } = new List<Product>();

    public virtual ICollection<ProductVendor> ProductVendors { get; } = new List<ProductVendor>();

    public virtual ICollection<Product> ProductWeightUnitMeasureCodeNavigations { get; } = new List<Product>();
}
