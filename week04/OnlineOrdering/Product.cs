public class Product
{
    private string _name;
    private string _productId;
    private float _price;
    private int _quantity;

    public Product(string name, string productId, float price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string GetName()=> _name;
    public string GetProductId()=> _productId;
    public float GetPrice()=> _price;
    public int GetQuantity()=> _quantity;

    public float GetTotalCost()
    {
        return _price*_quantity;
    }
}