using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer=customer;
        _products=new List<Product>();

    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public string GetPackingLabel()
    {
        StringBuilder sb=new StringBuilder();
        sb.AppendLine("PACKING LABLE:");
        sb.AppendLine("---------------");

        foreach (Product p in _products)
        {
            sb.AppendLine($"{p.GetName()} (ID: {p.GetProductId()})");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL: ----------------" +
               $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }

    public float GetTotalPrice()
    {
        float total =0;

        foreach (Product p in _products)
        {
            total+=p.GetTotalCost();
        }


        total += _customer.LivesInUSA() ? 5:35;

        return total;
    }
}