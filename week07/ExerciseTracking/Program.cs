// Ngoy A Ngoy 
using System;

public class SwimmingActivity
{
       // Properties to store the input data
       public int Laps { get; set; }
       public double Minutes { get; set; }

       // Methods to perform all the calculations
       public double CalculateDistanceKm()
       {
              return (double)Laps * 50 / 1000;
       }

       public double CalculateDistanceMiles()
       {
              return (double)Laps * 50 / 1000 * 0.62;
       }

       public double CalculateSpeedKph()
       {
              double distanceKm = CalculateDistanceKm();
              if (Minutes == 0) return 0;
              return (distanceKm / Minutes) * 60;
       }

       public double CalculateSpeedMph()
       {
              double distanceMiles = CalculateDistanceMiles();
              if (Minutes == 0) return 0;
              return (distanceMiles / Minutes) * 60;
       }

       public double CalculatePaceMinPerKm()
       {
              double distanceKm = CalculateDistanceKm();
              if (distanceKm == 0) return 0;
              return Minutes / distanceKm;
       }

       public double CalculatePaceMinPerMile()
       {
              double distanceMiles = CalculateDistanceMiles();
              if (distanceMiles == 0) return 0;
              return Minutes / distanceMiles;
       }
}

public class Program
{
       public static void Main(string[] args)
       {
              // Creating an instance of the SwimmingActivity class
              SwimmingActivity activity = new SwimmingActivity();

              // Setting the input values
              activity.Laps = 100;
              activity.Minutes = 30;

              // Displaying the inputs
              Console.WriteLine($"Number of swimming laps : {activity.Laps}");
              Console.WriteLine($"Session duration (minutes) : {activity.Minutes}");
              Console.WriteLine("---------------------------------------------");

              // Calculating and displaying the results
              Console.WriteLine($"Distance (km) : {activity.CalculateDistanceKm():F2}");
              Console.WriteLine($"Distance (miles) : {activity.CalculateDistanceMiles():F2}");
              Console.WriteLine($"Speed (kph) : {activity.CalculateSpeedKph():F2}");
              Console.WriteLine($"Speed (mph) : {activity.CalculateSpeedMph():F2}");
              Console.WriteLine($"Pace (min/km) : {activity.CalculatePaceMinPerKm():F2}");
              Console.WriteLine($"Pace (min/mile) : {activity.CalculatePaceMinPerMile():F2}");
       }
}
