﻿using System;
using System.Collections.Generic;

namespace RailwayStationDB.Data.Models;

public partial class Track
{
    public int TrackId { get; set; }

    public string? StationName { get; set; }

    public int? TrackNumber { get; set; }

    public int? TrainId { get; set; }

    public virtual Train? Train { get; set; }
}
