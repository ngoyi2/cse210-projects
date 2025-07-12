using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");


        Random generater = new Random();
        int magicNumber = generater.Next(1, 101);

        int guessnumber = -1;
        while (guessnumber != magicNumber)
        {
            Console.Write(" what is you guessiung Number ? :");
            guessnumber = int.Parse(Console.ReadLine());

            if (magicNumber > guessnumber)
            {
                Console.WriteLine("Higher");
            }

            else if (magicNumber < guessnumber)
            {
                Console.WriteLine("Lower");
            }

            else
            {
                Console.WriteLine("You Guessed it congratulation");
            }
        }
    }
}