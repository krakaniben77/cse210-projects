using System;

class Program
{
    static void Main(string[] args)
    {
        
        Address addr1 = new Address("12 Main Street", "New York", "NY", "USA");
        Customer cust1 = new Customer("Benjamin Krakani", addr1);
        Order order1 = new Order(cust1);

        order1.AddProduct(new Product("Laptop", "A123", 800, 1));
        order1.AddProduct(new Product("Mouse", "M345", 25, 2));
        order1.AddProduct(new Product("USB Cable", "U567", 10, 3));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order1.GetTotalPrice()}\n");

        
        Address addr2 = new Address("45 Beach Road", "Accra", "Greater Accra", "Ghana");
        Customer cust2 = new Customer("Krakani Biney", addr2);
        Order order2 = new Order(cust2);

        order2.AddProduct(new Product("Football", "F123", 40, 1));
        order2.AddProduct(new Product("Boots", "B999", 120, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order2.GetTotalPrice()}\n");
    }
}
