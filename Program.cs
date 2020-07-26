using System;
using System.Collections.Generic;

namespace TaxiCustomerAlgorithm
{
    class TaxiCustomerAlgorithm
    {
        static void Main()
        {
            var random = new Random();
            int LowestPrice = 0;
            string[] Customers = { "Customer1", "Customer2", "Customer3" };
            int[] CustomersExpenses1 = { random.Next(200), random.Next(200), random.Next(200) };
            int[] CustomersExpenses2 = { random.Next(20), random.Next(20), random.Next(20) };
            int[] CustomersExpenses3 = { random.Next(20), random.Next(20), random.Next(20) };
            string Result = $"Taxi 1 : {Customers[0]} for {CustomersExpenses1[0]} USD, Taxi 2 : {Customers[1]} for {CustomersExpenses1[1]} USD, Taxi 3 : {Customers[2]} for {CustomersExpenses1[2]} USD";

            for (int i1 = 0; i1 < CustomersExpenses1.Length; i1++)
            {
                int sumPrice = CustomersExpenses1[i1];
                for (int i2 = 0; i2 < CustomersExpenses2.Length; i2++)
                {
                    if (i2 == i1)
                    {
                        continue;
                    }
                    int sumPrice2 = sumPrice + CustomersExpenses2[i2];
                    for (int i3 = 0; i3 < CustomersExpenses3.Length; i3++)
                    {
                        if (i3 == i1 || i3 == i2)
                        {
                            continue;
                        }
                        int sumPrice3 = sumPrice2 + CustomersExpenses3[i3];
                        if (LowestPrice == 0 || sumPrice3 < LowestPrice)
                        {
                            LowestPrice = sumPrice3;
                            Result = $"Taxi 1 : {Customers[i1]} for {CustomersExpenses1[i1]} USD, Taxi 2 : {Customers[i2]} for {CustomersExpenses2[i2]} USD, Taxi3 : {Customers[i3]} for {CustomersExpenses3[i3]} USD";
                        }
                    };
                };
            };
            Console.WriteLine($"{Result}");
            Console.WriteLine($"Lowest combined price is {LowestPrice}");
        }
    }
}

/*tri customera puta tri taksista je 9 troškova
svaki takist izabare jednog customera
1 takist prvi trošak => ista 3 troška => 1 takista 1 trošak => 9 KOMB
1 takist drugi trošak => ista 3 troška* => 1 takista 2 trošak => 9 KOMB
1 takist treći tošak => ista 3 troška* => 1 takista 3 trošak => 9 KOMB
zbroj troškova
dobiti prvi trošak
ako je idući trošak veći odbaci, ako je manji postaje prvi
izabrati najmanji trošak
vratiti taksix customerx taksiy customery taksiz customerz*/
