// Entry.cs

using System;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; } // Storing date as a string as per simplification

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine("------------------------------");
    }

    // Method to convert entry to a string for saving (using a separator)
    // Example: "2026-10-27~|~What was the best part of my day?~|~Getting a promotion!"
    public string ToSaveString()
    {
        // Using a unique separator that is unlikely to appear in user input
        // For actual CSV, more robust handling of commas and quotes would be needed.
        string separator = "~|~";
        return $"{Date}{separator}{Prompt}{separator}{Response}";
    }

    // Static method to parse a string back into an Entry object
    public static Entry FromSaveString(string entryString)
    {
        string separator = "~|~";
        string[] parts = entryString.Split(new string[] { separator }, StringSplitOptions.None);

        if (parts.Length == 3)
        {
            return new Entry(parts[1], parts[2], parts[0]);
        }
        return null; // Handle malformed lines
    }
}