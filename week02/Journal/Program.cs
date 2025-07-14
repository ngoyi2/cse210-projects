// Program.cs
// this class as a supper class itr as two subclasses like Entry,journal and got a prompt.txt
// each class hase it's own proprieties and methods.
// 
// This program is a simple journal application that allows users to write entries, display them, and save/load from a file.
// in this program i have used thge main function.
// i have choosed to use a while loop with a parametter to precice if true or false.
// so a user can choose to write a new entry, display the journal, save the journal to a file, load the journal from a file, or exit the program.
// we creeted a journal and renitialised its proprierity.


using System;
using System.Collections.Generic; // Not strictly needed here, but common

public class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        
        
        while (true) // Using a while loop to keep the program running until the user chooses to exit
        {
            Console.WriteLine("--- Journal Program Menu ---");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            // Represents the standard input, output, and error streams for console applications. This class cannot be inherited.

            string choice = Console.ReadLine();
            // i decided to use a switch statement to handle the user's choice.
            // The switch statement is a control structure that allows you to execute different code blocks based on the value of a variable.
            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter filename to save (e.g., my_journal.txt): ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveJournal(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load (e.g., my_journal.txt): ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadJournal(loadFilename);
                    break;
                case "5":
                    Console.WriteLine("Exiting Journal Program. Goodbye!");
                    return; // Exits the Main method, thus ending the program
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.\n");
                    break;
            }
            Console.WriteLine(); // Add an empty line for better readability between menu loops
        }
    }
}