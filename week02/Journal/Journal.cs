// Journal.cs

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; // For Random.Choice equivalent (though not strictly needed for single random)

public class Journal
{
    private List<Entry> _entries;
    private List<string> _prompts;
    private Random _random;

    public Journal()
    {
        _entries = new List<Entry>();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is one new thing I learned today?",
            "Describe a moment today that made you smile.",
            "What challenge did I overcome today?"
        };
        _random = new Random();
    }

    public void AddEntry()
    {
        // Get a random prompt
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        // Get current date as a string
        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

        Entry newEntry = new Entry(prompt, response, currentDate);
        _entries.Add(newEntry);
        Console.WriteLine("Entry added successfully!\n");
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nYour journal is empty.\n");
            return;
        }

        Console.WriteLine("\n--- Your Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("----------------------------\n");
    }

    public void SaveJournal(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.ToSaveString());
                }
            }
            Console.WriteLine($"\nJournal saved to '{filename}' successfully!\n");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"\nError: Could not save journal to '{filename}'. {ex.Message}\n");
        }
    }

    public void LoadJournal(string filename)
    {
        _entries.Clear(); // Clear current entries before loading
        try
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                Entry entry = Entry.FromSaveString(line);
                if (entry != null)
                {
                    _entries.Add(entry);
                }
            }
            Console.WriteLine($"\nJournal loaded from '{filename}' successfully! ({_entries.Count} entries loaded)\n");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"\nError: File '{filename}' not found.\n");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"\nError: Could not load journal from '{filename}'. {ex.Message}\n");
        }
    }
}