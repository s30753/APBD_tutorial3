namespace Tutorial3;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool StoresHazardousCargo { get; set; }

    public LiquidContainer(double height, double depth, double cargoMass, double tareWeight, double cargoWeight, double maxPayload) : base(height, depth, cargoMass, tareWeight, cargoWeight, maxPayload)
    {
        StoresHazardousCargo = false;
        SerialNumber = SerialNumber.Replace('A', 'L');
    }

    public LiquidContainer(double height, double depth, double tareWeight, double maxPayload) : base(height, depth, tareWeight, maxPayload)
    {
        StoresHazardousCargo = false;
        SerialNumber = SerialNumber.Replace('A', 'L');
    }

    public override void EmptyCargo()
    {
        CargoWeight = 0;
        CargoMass = TareWeight;
        StoresHazardousCargo = false;
        Console.WriteLine("Cargo unloaded successfully");
    }
    
    public override void LoadContainer(Cargo cargo, double weight)
    {
        base.LoadContainer(cargo, weight);
        double currentCapacity = StoresHazardousCargo || cargo.IsHazardous ? 0.5 * MaxPayload : 0.9 * MaxPayload;
        currentCapacity -= CargoWeight;
        if (weight > currentCapacity)
        {
            Console.WriteLine("Dangerous operation attempted. Not enough space left to load this cargo");
        }
        else
        {
            if (cargo.IsHazardous)
            {
                StoresHazardousCargo = true;
                Notify();
            }

            CargoWeight += weight;
            CargoMass += weight;
            Console.WriteLine("Cargo successfully loaded");
        }
    }

    public void Notify()
    {
        Console.WriteLine($"Hazardous situation in container {SerialNumber}");
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        if (StoresHazardousCargo) Console.WriteLine("Stores hazardous cargo");
        else Console.WriteLine("Doesn't store hazardous cargo");
    }
}