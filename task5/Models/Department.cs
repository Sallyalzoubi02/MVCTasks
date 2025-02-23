using System;
using System.Collections.Generic;

namespace task5.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public int? ManagerId { get; set; }

    public DateOnly? EstablishedDate { get; set; }
}
