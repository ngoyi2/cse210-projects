using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2020;
        job1._endYear = 2025;

        Job job2 = new Job();
        job2._jobTitle = "Analyser";
        job2._company = "Google";
        job2._startYear = 2024;
        job2._endYear = 2026;

        Resume myResume = new Resume();
        myResume._name = "Augustin ngoy";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();



    }
}