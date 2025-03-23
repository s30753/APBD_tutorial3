namespace Tutorial3;
using System;

public class MainClass
{
    public static void Main(string[] args)
    {
        Cargo cargo1 = new Cargo("fuel", true);
        Cargo cargo2 = new Cargo("water", false);
        Cargo cargo3 = new Cargo("helium", false);
        Cargo cargo4 = new Cargo("methane", true);

        Product p1 = new Product("bananas", 13.3);
        Product p2 = new Product("chocolate", 18);
        Product p3 = new Product("fish", 2);
        Product p4 = new Product("meat", -15);

        Container l1 = new LiquidContainer(1500, 1200, 300, 150);
        Container g1 = new GasContainer(1500, 1200, 250, 150,20);
        Container r1 = new RefrigeratedContainer(1500, 1200, 300, 400, p3,5 );
        Container r2 = new RefrigeratedContainer(1500, 1200, 300, 400, p4,-10 );

        ContainerShip c1 = new ContainerShip(20, 3, 1.5);
        ContainerShip c2 = new ContainerShip(20, 3, 1);
        
        l1.LoadContainer(cargo1, 50);
        l1.LoadContainer(cargo2, 50);
        l1.PrintInfo();
    }

    public static void TransferContainer(ContainerShip c1, ContainerShip c2, string sNum)
    {
        int index = -1;
        for (int i = 0; i < c1.Containers.Count; i++)
        {
            if (c1.Containers[i].SerialNumber == sNum) index = i;
        }

        if (index == -1)
        {
            Console.WriteLine("Container with a given serial number not found");
        }
        else
        {
            Container c = c1.Containers[index];
            if (c2.TotalContainersWeight() + c.CargoMass < c2.MaxWeight * 1000)
            {
                c1.Containers.RemoveAt(index);
                c2.Containers.Add(c);
                Console.WriteLine("Container " + sNum + " transferred successfully");
            }
            else
            {
                Console.WriteLine("Container " + sNum + " cannot be transferred as the weight would exceed " +
                                  "the limit of the ship");
            }
        }
    }
}