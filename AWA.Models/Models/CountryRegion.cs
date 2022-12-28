using System;
using System.Collections.Generic;

namespace AWA.Models;

/// <summary>
/// Lookup table containing the ISO standard codes for countries and regions.
/// </summary>
public partial class CountryRegion
{
    /// <summary>
    /// ISO standard code for countries and regions.
    /// </summary>
    public string CountryRegionCode { get; set; } = null!;

    /// <summary>
    /// Country or region name.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; } = new List<CountryRegionCurrency>();

    public virtual ICollection<SalesTerritory> SalesTerritories { get; } = new List<SalesTerritory>();

    public virtual ICollection<StateProvince> StateProvinces { get; } = new List<StateProvince>();
}
