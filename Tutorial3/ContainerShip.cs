namespace Tutorial3;

public class ContainerShip
{
    public List<Container> Containers { get; set; }
    public double MaxSpeed { get; set; }
    public double MaxNum { get; set; }
    public double MaxWeight { get; set; }

    public ContainerShip(List<Container> containers, double maxSpeed, double maxNum, double maxWeight)
    {
        Containers = containers;
        MaxSpeed = maxSpeed;
        MaxNum = maxNum;
        MaxWeight = maxWeight;
    }

    public ContainerShip(double maxSpeed, double maxNum, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxNum = maxNum;
        MaxWeight = maxWeight;
        Containers = new List<Container>();
    }

    public void LoadSingleContainer(Container c)
    {
        if (MaxNum > Containers.Count)
        {
            double totalWeight = 0;
            for (int i = 0; i < Containers.Count; i++)
            {
                totalWeight += Containers[i].CargoMass;
            }

            if (totalWeight + c.CargoMass <= MaxWeight * 1000)
            {
                Containers.Add(c);
                Console.WriteLine("Container " + c.SerialNumber + " added successfully");
            }
            else
            {
                Console.WriteLine("Cannot add the container as the weight exceeds the limit");
            }
        }
        else
        {
            Console.WriteLine("Cannot add the container as there's already maximum number of containers");
        }
    }
    public void LoadMultipleContainers(List<Container> cList)
    {
        if (MaxNum >= Containers.Count + cList.Count)
        {
            double totalWeight = 0;
            for (int i = 0; i < Containers.Count; i++)
            {
                totalWeight += Containers[i].CargoMass;
            }

            double totalCListWeight = 0;
            for (int i = 0; i < cList.Count; i++)
            {
                totalWeight += cList[i].CargoMass;
            }

            if (MaxWeight * 1000 >= totalWeight + totalCListWeight)
            {
                for (int i = 0; i < cList.Count; i++)
                {
                    Containers.Add(cList[i]);
                }
                Console.WriteLine("Multiple containers added successfully");
            }
            else
            {
                Console.WriteLine("Cannot add these containers as their weight exceeds the limit left");
            }
        }
        else
        {
            Console.WriteLine("Cannot add these containers as their number exceeds maximum number of containers left");
        }
    }

    public void RemoveContainer(string sNum)
    {
        bool found = false;
        for (int i = 0; i < Containers.Count; i++)
        {
            if (Containers[i].SerialNumber == sNum)
            {
                found = true;
                Containers.RemoveAt(i);
                Console.WriteLine("Container " + sNum + " removed successfully");
            }
        }
        
        if(!found) Console.WriteLine("Container " + sNum + " not found");
    }
    
    public void ReplaceContainer(string sNum, Container c)
    {
        int index = -1;
        double totalWeight = 0;
        for (int i = 0; i < Containers.Count; i++)
        {
            if (Containers[i].SerialNumber == sNum) index = i;
            totalWeight += Containers[i].CargoMass;
        }

        if (index != -1)
        {
            if (totalWeight + c.CargoMass - Containers[index].CargoMass <= MaxWeight * 1000)
            {
                Containers[index] = c;
                Console.WriteLine("Containers replaced successfully");
            }
            else
            {
                Console.WriteLine("Cannot replace the container as the weight exceeds the limit");
            }
        }
        else
        {
            Console.WriteLine("Container " + sNum + " not found");
        }
    }

    public void PrintInfo()
    {
        Console.WriteLine($@"Container Ship Information:
maxSpeed: {MaxSpeed} knots
maxNum: {MaxNum}
maxWeight: {MaxWeight}t");
        Console.WriteLine("----------");
        foreach (Container c in Containers)
        {
            c.PrintInfo();
            Console.WriteLine("----------");
        }
        
    }
}