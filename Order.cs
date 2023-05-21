using System;
using System.Collections.Generic;

namespace CarRentalApp;

public partial class Order
{
    public int IdOrder { get; set; }

    public int? IdCar { get; set; }

    public int? IdClient { get; set; }

    public int Hours { get; set; }

    public double Summa { get; set; }

    public virtual Car? IdCarNavigation { get; set; }

    public virtual Client? IdClientNavigation { get; set; }
}
