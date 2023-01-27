using System;
using System.Collections.Generic;

namespace AWA.Models;

/// <summary>
/// Telephone number and type of a person.
/// </summary>
public partial class PersonPhone
{
    /// <summary>
    /// Business entity identification number. Foreign key to Person.BusinessEntityID.
    /// </summary>
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Telephone number identification number.
    /// </summary>
    public string PhoneNumber { get; set; } = null!;

    /// <summary>
    /// Kind of phone number. Foreign key to PhoneNumberType.PhoneNumberTypeID.
    /// </summary>
    public int PhoneNumberTypeId { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    public DateTime ModifiedDate { get; set; }

    public virtual Person BusinessEntity { get; set; } = null!;

    public virtual PhoneNumberType PhoneNumberType { get; set; } = null!;
}
