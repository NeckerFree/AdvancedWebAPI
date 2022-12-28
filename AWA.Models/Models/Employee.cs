using System;
using System.Collections.Generic;

namespace AWA.Models;

/// <summary>
/// Employee information such as salary, department, and title.
/// </summary>
public partial class Employee
{
    /// <summary>
    /// Primary key for Employee records.  Foreign key to BusinessEntity.BusinessEntityID.
    /// </summary>
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Unique national identification number such as a social security number.
    /// </summary>
    public string NationalIdnumber { get; set; } = null!;

    /// <summary>
    /// Network login.
    /// </summary>
    public string LoginId { get; set; } = null!;

    /// <summary>
    /// The depth of the employee in the corporate hierarchy.
    /// </summary>
    public short? OrganizationLevel { get; set; }

    /// <summary>
    /// Work title such as Buyer or Sales Representative.
    /// </summary>
    public string JobTitle { get; set; } = null!;

    /// <summary>
    /// Date of birth.
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// M = Married, S = Single
    /// </summary>
    public string MaritalStatus { get; set; } = null!;

    /// <summary>
    /// M = Male, F = Female
    /// </summary>
    public string Gender { get; set; } = null!;

    /// <summary>
    /// Employee hired on this date.
    /// </summary>
    public DateTime HireDate { get; set; }

    /// <summary>
    /// Job classification. 0 = Hourly, not exempt from collective bargaining. 1 = Salaried, exempt from collective bargaining.
    /// </summary>
    public bool? SalariedFlag { get; set; }

    /// <summary>
    /// Number of available vacation hours.
    /// </summary>
    public short VacationHours { get; set; }

    /// <summary>
    /// Number of available sick leave hours.
    /// </summary>
    public short SickLeaveHours { get; set; }

    /// <summary>
    /// 0 = Inactive, 1 = Active
    /// </summary>
    public bool? CurrentFlag { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    public Guid Rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    public DateTime ModifiedDate { get; set; }

    public virtual Person BusinessEntity { get; set; } = null!;

    public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; } = new List<EmployeeDepartmentHistory>();

    public virtual ICollection<EmployeePayHistory> EmployeePayHistories { get; } = new List<EmployeePayHistory>();

    public virtual ICollection<JobCandidate> JobCandidates { get; } = new List<JobCandidate>();

    public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; } = new List<PurchaseOrderHeader>();

    public virtual SalesPerson? SalesPerson { get; set; }
}
