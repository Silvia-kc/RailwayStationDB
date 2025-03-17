using System;
using System.Collections.Generic;

namespace RailwayStationDB.Data.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? Name { get; set; }

    public string? Position { get; set; }

    public int? TrainId { get; set; }

    public virtual Train? Train { get; set; }
}
