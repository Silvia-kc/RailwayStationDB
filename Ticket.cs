using System;
using System.Collections.Generic;

namespace RailwayStationDB.Data.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string? PassengerName { get; set; }

    public int? TraindId { get; set; }

    public int? RouteId { get; set; }

    public string? SeatNumber { get; set; }

    public decimal? Price { get; set; }

    public virtual Route? Route { get; set; }

    public virtual Train? Traind { get; set; }
}
