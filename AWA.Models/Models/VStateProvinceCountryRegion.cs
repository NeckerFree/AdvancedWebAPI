using System;
using System.Collections.Generic;

namespace AWA.Models;

public partial class VStateProvinceCountryRegion
{
    public int StateProvinceId { get; set; }

    public string StateProvinceCode { get; set; } = null!;

    public bool IsOnlyStateProvinceFlag { get; set; }

    public string StateProvinceName { get; set; } = null!;

    public int TerritoryId { get; set; }

    public string CountryRegionCode { get; set; } = null!;

    public string CountryRegionName { get; set; } = null!;
}
