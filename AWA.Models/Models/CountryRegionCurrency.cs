using System;
using System.Collections.Generic;

namespace AWA.Models;

/// <summary>
/// Cross-reference table mapping ISO currency codes to a country or region.
/// </summary>
public partial class CountryRegionCurrency
{
    /// <summary>
    /// ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.
    /// </summary>
    public string CountryRegionCode { get; set; } = null!;

    /// <summary>
    /// ISO standard currency code. Foreign key to Currency.CurrencyCode.
    /// </summary>
    public string CurrencyCode { get; set; } = null!;

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    public DateTime ModifiedDate { get; set; }

    public virtual CountryRegion CountryRegionCodeNavigation { get; set; } = null!;

    public virtual Currency CurrencyCodeNavigation { get; set; } = null!;
}
