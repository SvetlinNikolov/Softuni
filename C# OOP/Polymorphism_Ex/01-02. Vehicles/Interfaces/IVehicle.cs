using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumtionPerKm { get; }

        string Drive(double distance);
        void Refuel(double fuelAmount);

        double TankCapacity { get; }
    }
}
