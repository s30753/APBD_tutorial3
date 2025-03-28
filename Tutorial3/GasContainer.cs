﻿namespace Tutorial3;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }
    public bool StoresHazardousCargo { get; set; }
    
    
    public GasContainer(double height, double depth, double cargoMass, double tareWeight, double cargoWeight, double maxPayload, double pressure) : base(height, depth, cargoMass, tareWeight, cargoWeight, maxPayload)
    {
        StoresHazardousCargo = false;
        Pressure = pressure;
        SerialNumber = SerialNumber.Replace('A', 'G');
    }

    public GasContainer(double height, double depth, double tareWeight, double maxPayload, double pressure) : base(height, depth, tareWeight, maxPayload)
    {
        StoresHazardousCargo = false;
        Pressure = pressure;
        SerialNumber = SerialNumber.Replace('A', 'G');
    }
    
    public override void EmptyCargo()
    {
        CargoWeight *= 0.05;
        CargoMass = TareWeight + CargoWeight;
        Console.WriteLine("Cargo unloaded successfully");
    }
    
    public override void LoadContainer(Cargo cargo, double weight)
    {
        base.LoadContainer(cargo, weight);
        if (cargo.IsHazardous)
        {
            StoresHazardousCargo = true;
            Notify();
        }
        CargoWeight += weight;
        CargoMass += weight;
        Console.WriteLine("Cargo successfully loaded");
    }

    public void Notify()
    {
        Console.WriteLine($"Hazardous situation in container {SerialNumber}");
    }
    
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Pressure: {Pressure}");
        if (StoresHazardousCargo) Console.WriteLine("Stores hazardous cargo");
        else Console.WriteLine("Doesn't store hazardous cargo");
    }
}