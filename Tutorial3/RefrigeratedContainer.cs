﻿namespace Tutorial3;

public class RefrigeratedContainer : Container
{
    public Product ProductType { get; set; }
    public double Temperature { get; set; }
    
    public RefrigeratedContainer(double height, double depth, double cargoMass, double tareWeight, double cargoWeight, double maxPayload, Product productType, double temperature) : base(height, depth, cargoMass, tareWeight, cargoWeight, maxPayload)
    {
        SerialNumber = SerialNumber.Replace('A', 'C');
        ProductType = productType;
        Temperature = temperature >= productType.MinTemperature ? temperature : productType.MinTemperature;
    }

    public RefrigeratedContainer(double height, double depth, double tareWeight, double maxPayload, Product productType, double temperature) : base(height, depth, tareWeight, maxPayload)
    {
        SerialNumber = SerialNumber.Replace('A', 'C');
        ProductType = productType;
        Temperature = temperature >= productType.MinTemperature ? temperature : productType.MinTemperature;
    }
    

    public override void EmptyCargo()
    {
        CargoWeight = 0;
        CargoMass = TareWeight;
        Console.WriteLine("Cargo unloaded successfully");
    }

    public void LoadContainer(Product product, double weight)
    {
        if (ProductType.Name == product.Name)
        {
            if (CargoWeight + weight > MaxPayload)
            {
                Console.WriteLine("Cannot load - maximum payload would be exceeded");
            }
            else
            {
                CargoWeight += weight;
                CargoMass += weight;   
                Console.WriteLine("Cargo successfully loaded");
            }
        }
        else
        {
            Console.WriteLine("This container stores different products.");
        }
    }
    
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Product Type: {ProductType.Name}");
        Console.WriteLine($"Temperature: {Temperature}");
    }
}