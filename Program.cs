using System;
using Serilog;


namespace TaxiCustomerAlgorithm
{
    class TaxiCustomerAlgorithm
    {
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs//taxicustomeralgorithm.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var random = new Random();
            int LowestExpense = 0;
            string[] Customers = { "Customer1", "Customer2", "Customer3" };
            int[] CustomersExpenses1 = { random.Next(200), random.Next(200), random.Next(200) };
            int[] CustomersExpenses2 = { random.Next(200), random.Next(200), random.Next(200) };
            int[] CustomersExpenses3 = { random.Next(200), random.Next(200), random.Next(200) };
            Log.Information("Customer1 expanses  for [Taxi 1, Taxi 2, Taxi 3]: {CustomersExpenses1}", CustomersExpenses1);
            Log.Information("Customer2 expanses for [Taxi 1, Taxi 2, Taxi 3]: {CustomersExpenses2}", CustomersExpenses2);
            Log.Information("Customer3 expanses for [Taxi 1, Taxi 2, Taxi 3]: {CustomersExpenses3}", CustomersExpenses3);

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
                        Log.Information("If Current {LowestPrice} is bigger than {sumPrice3} or {LowestPrice} is equal to 0, LowestPrice value will be changed", LowestExpense, sumPrice3);
                        if (LowestExpense == 0 || sumPrice3 < LowestExpense)
                        {
                            LowestExpense = sumPrice3;
                            Log.Information("New Lowest Expense for company is {LowestExpense}", LowestExpense);
                            Log.Information("{i1}, {i2}, {i3} are indexex that defines current Lowest Expense: {LowestExpense}!", i1, i2, i3, LowestExpense);
                            Result = $"Lowest expense for company is Taxi 1 : {Customers[i1]} for {CustomersExpenses1[i1]} USD, Taxi 2 : {Customers[i2]} for {CustomersExpenses2[i2]} USD, Taxi3 : {Customers[i3]} for {CustomersExpenses3[i3]} USD";
                        }
                    };
                };
            };
            Log.Information("{Result}", Result);
            Log.Information("Lowest expense is {LowestExpense}", LowestExpense);
            Console.WriteLine($"{Result}");
            Console.WriteLine($"Lowest expense is {LowestExpense}");
        }
    }
}
