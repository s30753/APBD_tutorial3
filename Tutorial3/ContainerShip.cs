namespace Tutorial3;

public class ContainerShip
{
    public List<Container> Containers { get; set; }
    public double MaxSpeed { get; set; }
    public double MaxNum { get; set; }
    public double MaxWeight { get; set; }

    public void LoadSingleContainer(Container c)
    {
        if (MaxNum > Containers.Count)
        {
            double totalWeight = 0;
            for (int i = 0; i < Containers.Count; i++)
            {
                totalWeight += Containers[i].CargoMass;
            }

            if (totalWeight + c.CargoMass <= MaxWeight)
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

            if (MaxWeight >= totalWeight + totalCListWeight)
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
            if (totalWeight + c.CargoMass - Containers[index].CargoMass <= MaxWeight)
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
}