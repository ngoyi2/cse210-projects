using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("---------Online Ordering Program ----------");
        Console.WriteLine();

        // --- Order 1: DRC Customer ---

        // 1. Create Address for Customer one DRC
        Address address1 = new Address("04 Hopital st", "Hunting Gun", "DT", "DRC");

        // 2. Create Customer 1
        Customer customer1 = new Customer("John Kasongo", address1);

        // 3. Create Products for Order 1
        Product product1_1 = new Product("Techno camon17 Pro", "tech-001", 1700.00m, 1);
        Product product1_2 = new Product("shooting gan", "Stg-008", 29.90m, 20);
        Product product1_3 = new Product("Type c cable", "cbl-010", 80.00m, 18);

        // 4. Create Order 1 and add products
        Order order1 = new Order(customer1);
        order1.AddProduct(product1_1);
        order1.AddProduct(product1_2);
        order1.AddProduct(product1_3);

        // 5. Display details for Order 1
        Console.WriteLine("=+= Order 1 Details (DRC Customer) =+=");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Order Cost: {order1.GetTotalCost():C}"); // :C for currency formatting
        Console.WriteLine("\n-------------------------------------\n");


        // --- Order 2: International Customer ---

        // 1. Create Address for Customer 2 (Canada)
        Address address2 = new Address("10 Rue Principale", "Katoka", "ht", "DRC");

        // 2. Create Customer 2
        Customer customer2 = new Customer("Ngoy Augustin", address2);

        // 3. Create Products for Order 2
        Product product2_1 = new Product("Bluetooth header", "bl-001", 800.00m, 90);
        Product product2_2 = new Product("Ergonomic Keyboard", "KB-012", 110.00m, 1);

        // 4. Create Order 2 and add products
        Order order2 = new Order(customer2);
        order2.AddProduct(product2_1);
        order2.AddProduct(product2_2);

        // 5. Display details for Order 2
        Console.WriteLine("=+= Order 2 Details (International Customer) =+=");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Order Cost: {order2.GetTotalCost():C}");
        Console.WriteLine("\n-------------------------------------\n");

        // --- Order 3: Another USA Customer (optional, but good for demonstrating) ---
        Address address3 = new Address("789 mweka", "bondoyi", "MD", "DRD Congo");
        Customer customer3 = new Customer("michel Mutonbw", address3);
        Product product3_1 = new Product("confuture", "CONF-001", 60.00m, 100);
        Order order3 = new Order(customer3);
        order3.AddProduct(product3_1);

        Console.WriteLine("=+= Order 3 Details (Another USA Customer) =+=");
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Order Cost: {order3.GetTotalCost():C}");
        Console.WriteLine("\n-------------------------------------\n");
    }
}