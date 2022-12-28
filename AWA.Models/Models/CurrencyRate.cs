using System;
using System.Collections.Generic;

namespace AWA.Models;

/// <summary>
/// Currency exchange rates.
/// </summary>
public partial class CurrencyRate
{
    /// <summary>
    /// Primary key for CurrencyRate records.
    /// </summary>
    public int CurrencyRateId { get; set; }

    /// <summary>
    /// Date and time the exchange rate was obtained.
    /// </summary>
    public DateTime CurrencyRateDate { get; set; }

    /// <summary>
    /// Exchange rate was converted from this currency code.
    /// </summary>
    public string FromCurrencyCode { get; set; } = null!;

    /// <summary>
    /// Exchange rate was converted to this currency code.
    /// </summary>
    public string ToCurrencyCode { get; set; } = null!;

    /// <summary>
    /// Average exchange rate for the day.
    /// </summary>
    public decimal AverageRate { get; set; }

    /// <summary>
    /// Final exchange rate for the day.
    /// </summary>
    public decimal EndOfDayRate { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    public DateTime ModifiedDate { get; set; }

    public virtual Currency FromCurrencyCodeNavigation { get; set; } = null!;

    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; } = new List<SalesOrderHeader>();

    public virtual Currency ToCurrencyCodeNavigation { get; set; } = null!;
}
