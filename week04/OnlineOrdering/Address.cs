using System;

public class Address
{
    // Private fields to store address components.
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    // Public properties to expose and set the address components.
    // Encapsulation: The user interacts with these properties, not the private fields directly.
    public string Street
    {
        get { return _street; }
        set { _street = value; } // Simple setter, can add validation if needed.
    }

    public string City
    {
        get { return _city; }
        set { _city = value; }
    }

    public string StateProvince
    {
        get { return _stateProvince; }
        set { _stateProvince = value; }
    }

    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }

    // Constructor to initialize an Address object.
    public Address(string street, string city, string stateProvince, string country)
    {
        // Using properties in the constructor ensures any future validation in setters is applied.
        Street = street;
        City = city;
        StateProvince = stateProvince;
        Country = country;
    }

    // Method to check if the address is in the USA.
    // Encapsulation: Hides the country string comparison logic.
    public bool IsInUSA()
    {
        // Case-insensitive comparison for "USA" or "United States"
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase) ||
               _country.Equals("United States", StringComparison.OrdinalIgnoreCase);
    }

    // Method to return the full address as a formatted string.
    // Encapsulation: Provides a clean, formatted output without exposing individual fields.
    public string GetFullAddressString()
    {
        return $"{_street}\n{_city}, {_stateProvince}\n{_country}";
    }
}