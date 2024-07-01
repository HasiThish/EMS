using System;
using System.Collections.Generic;

namespace EmployeeManagementServices.Data;

public partial class Employee
{
    public long Employeeid { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public int? Department { get; set; }

    public int? Roleid { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public DateTime Started { get; set; }

    public bool Isactive { get; set; }

    public bool Isdeleted { get; set; }

    public string? Address { get; set; }

    public string? Nic { get; set; }
}
