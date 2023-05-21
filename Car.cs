using System;
using System.Collections.Generic;

namespace CarRentalApp;

public partial class Car
{
    public int IdCar { get; set; }

    public string Model { get; set; } = null!;

    public string RegNum { get; set; } = null!;

    public double Price { get; set; }

    public int Year { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
