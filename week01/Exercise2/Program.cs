using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

    

    string message = "congratulation you made it. see you next time";



        Console.Write("what is your grade? :");
        int result = int.Parse(Console.ReadLine());

        string letter = "";

        if (result >= 90)
        {
            letter = "A";
        }
        else if (result >= 80)
        {
            letter = "B";
        }
        else if (result >= 70)
        {
            letter = "C";
        }


        else if (result >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }


        if (result >= 70)
        {
            Console.Write($"your grade is {letter}, \n {message}");

        }


    }
}