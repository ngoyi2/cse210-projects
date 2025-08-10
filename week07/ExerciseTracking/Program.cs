// Ngoy Augustin Ngoy. 
using System;
using System.Collections.Generic;


public abstract class Activity
{
       private string _date;
       private double _minutes;

       public Activity(string date, double minutes)
       {
              _date = date;
              _minutes = minutes;
       }

       public double GetMinutes()
       {
              return _minutes;
       }

       public abstract double GetDistance();
       public abstract double GetSpeed();
       public abstract double GetPace();

       public virtual string GetSummary()
       {
              return $"{_date} {this.GetType().Name} ({_minutes:F2} min): " +
                     $"Distance {GetDistance():F2} km, " +
                     $"Speed: {GetSpeed():F2} kph, " +
                     $"Pace: {GetPace():F2} min per km";
       }
}


public class Running : Activity
{
       private double _distance; // in kilometers

       public Running(string date, double minutes, double distance) : base(date, minutes)
       {
              _distance = distance;
       }

       public override double GetDistance()
       {
              return _distance;
       }

       public override double GetSpeed()
       {
              if (GetMinutes() == 0) return 0;
              return (GetDistance() / GetMinutes()) * 60;
       }

       public override double GetPace()
       {
              if (GetDistance() == 0) return 0;
              return GetMinutes() / GetDistance();
       }
}


public class Cycling : Activity
{
       private double _speed; // in kph

       public Cycling(string date, double minutes, double speed) : base(date, minutes)
       {
              _speed = speed;
       }

       public override double GetDistance()
       {
              return (GetSpeed() * GetMinutes()) / 60;
       }

       public override double GetSpeed()
       {
              return _speed;
       }

       public override double GetPace()
       {
              if (GetDistance() == 0) return 0;
              return GetMinutes() / GetDistance();
       }
}



public class Swimming : Activity
{
       private int _laps;

       public Swimming(string date, double minutes, int laps) : base(date, minutes)
       {
              _laps = laps;
       }

       public override double GetDistance()
       {
              return (double)_laps * 50 / 1000;
       }

       public override double GetSpeed()
       {
              if (GetMinutes() == 0) return 0;
              return (GetDistance() / GetMinutes()) * 60;
       }

       public override double GetPace()
       {
              if (GetDistance() == 0) return 0;
              return GetMinutes() / GetDistance();
       }
}



//using System;

public class Program
{
       public static void Main(string[] args)
       {
              List<Activity> activities = new List<Activity>();

              activities.Add(new Running("03 Nov 2022", 30, 4.8));
              activities.Add(new Cycling("04 Nov 2022", 45, 20.0));
              activities.Add(new Swimming("05 Nov 2022", 30, 40));

              foreach (Activity activity in activities)
              {
                     Console.WriteLine(activity.GetSummary());
              }
       }
}
