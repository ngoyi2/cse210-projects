using System;

public class Customer
{
    // Private fields for customer's name and address.
    private string _name;
    private Address _address; // Customer contains an Address object (composition)

    // Public properties for name and address.
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Address Address // The Address itself is an object, hence its type is Address.
    {
        get { return _address; }
        set { _address = value; }
    }

    // Constructor to initialize a Customer object.
    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    // Method to determine if the customer lives in the USA.
    // Encapsulation: Delegates the "IsInUSA" check to the Address object,
    // so Customer doesn't need to know address details.
    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }
}