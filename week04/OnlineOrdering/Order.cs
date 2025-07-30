using System;
using System.Collections.Generic; // Necessary for List<T>

public class Order
{
    // Private fields for the list of products and the customer.
    private List<Product> _products;
    private Customer _customer;

    // Public properties to access the products list and customer.
    public List<Product> Products
    {
        get { return _products; }
        // Setter could be removed or made private if we only allow adding via a method.
        set { _products = value; }
    }

    public Customer Customer
    {
        get { return _customer; }
        set { _customer = value; }
    }

    // Constructor to initialize an Order with a customer and an empty list of products.
    public Order(Customer customer)
    {
        Customer = customer;
        _products = new List<Product>(); // Initialize the products list.
    }

    // Method to add a product to the order. Encapsulates the list management.
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate the total cost of the order, including shipping.
    // Encapsulation: Hides the complex logic of summing product costs and adding shipping.
    public decimal GetTotalCost()
    {
        decimal productsTotal = 0;
        foreach (Product product in _products)
        {
            productsTotal += product.GetTotalCost(); // Delegate to Product for its total cost.
        }

        decimal shippingCost = _customer.LivesInUSA() ? 5.00m : 35.00m;

        return productsTotal + shippingCost;
    }

    // Method to generate the packing label string.
    // Encapsulation: Formats the label without exposing product list directly.
    public string GetPackingLabel()
    {
        string label = "--- Packing Label ---\n";
        foreach (Product product in _products)
        {
            label += $"Product: {product.Name} (ID: {product.ProductId})\n";
        }
        return label;
    }

    // Method to generate the shipping label string.
    // Encapsulation: Formats the label by delegating to Customer and Address.
    public string GetShippingLabel()
    {
        string label = "--- Shipping Label ---\n";
        label += $"Customer Name: {_customer.Name}\n";
        label += $"Address:\n{_customer.Address.GetFullAddressString()}";
        return label;
    }
}