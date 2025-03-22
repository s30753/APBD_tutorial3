namespace Tutorial3;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool StoresHazardousCargo { get; set; }

    public LiquidContainer(double height, double depth, double cargoMass, double tareWeight, double cargoWeight, double maxPayload) : base(height, depth, cargoMass, tareWeight, cargoWeight, maxPayload)
    {
        StoresHazardousCargo = false;
        SerialNumber = base.SerialNumber.Replace('A', 'L');
    }

    public LiquidContainer(double height, double depth, double tareWeight, double maxPayload) : base(height, depth, tareWeight, maxPayload)
    {
        StoresHazardousCargo = false;
        SerialNumber = base.SerialNumber.Replace('A', 'L');
    }

    public override void EmptyCargo()
    {
        CargoWeight = 0;
        CargoMass = TareWeight;
        StoresHazardousCargo = false;
    }
    
    public override void LoadContainer(Cargo cargo, double weight)
    {
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
                notify();
            }

            CargoWeight += weight;
            CargoMass += weight;
        }
    }

    public void notify()
    {
        // to implement
    }
    
}