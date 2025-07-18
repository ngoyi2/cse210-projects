using System;

class Program
{
    static void Main(string[] args)
    {
        Reference ref1 = new Reference("john", 3, 16);
        Scripture scripture1 = new Scripture(ref1, "For God So Loved the world, that he gave his only begotten Son that housoever believeth in him should not perish, but have everlasting life.");

        Scripture currentScripture = scripture1; // or 2 
        string uiserInput = "";
        while (uiserInput.ToLower() != "quit" && !currentScripture.IsCompletelyhiden())
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine("\n Press Enter to continue or type 'quit' to exit.");

            uiserInput = Console.ReadLine();
            if (uiserInput.ToLower() == "quit")
            {
                break; // for exiting the loop
            }
            currentScripture.HideRandomWords(3);

        }
        Console.Clear();
        Console.WriteLine(currentScripture.GetDisplayText());
        Console.WriteLine("\n Program finished All words or 'quit' Typed.");
    }
}    