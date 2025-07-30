// File: Product.cs

using System;

public class Product
{
    // Private fields for product details.
    private string _name;
    private string _productId; // Product ID, e.g., SKU
    private decimal _pricePerUnit;
    private int _quantity;

    // Public properties for product details.
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string ProductId
    {
        get { return _productId; }
        set { _productId = value; }
    }

    public decimal PricePerUnit
    {
        get { return _pricePerUnit; }
        set { _pricePerUnit = value; }
    }

    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }

    // Constructor to initialize a Product object.
    public Product(string name, string productId, decimal pricePerUnit, int quantity)
    {
        Name = name;
        ProductId = productId;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
    }

    // Method to calculate the total cost for this specific product (quantity * price).
    // Encapsulation: Hides the calculation logic within the Product class.
    public decimal GetTotalCost()
    {
        return _pricePerUnit * _quantity;
    }
}