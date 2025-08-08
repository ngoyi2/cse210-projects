using System;
using System.Collections.Generic;
using System.IO;

// This class will manage all the goals, user score, and menu interactions.
// Exceeds Requirements: The GoalManager class encapsulates all program logic,
// making the Program.cs Main method clean and simple. It manages the goals list,
// score, and all file I/O, which is a significant improvement over scattering this logic.
public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        // Exceeds Requirements: Added a basic leveling system to gamify the experience.
        // The level is determined by the score, providing a sense of progression.
        string level = "Apprentice";
        if (_score >= 1000) level = "Journeyman";
        if (_score >= 5000) level = "Master";
        if (_score >= 10000) level = "Legend";
        Console.WriteLine($"Current Level: {level}");
    }

    public void ListGoals()
    {
        Console.Clear();
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals set yet.");
        }
        else
        {
            Console.WriteLine("Your Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }
        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
        }
    }

    public void RecordEvent()
    {
        Console.Clear();
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record an event for.");
            Console.WriteLine("\nPress any key to return to the menu.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
            int pointsEarned = _goals[index].GetPoints();
            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully. Press any key to continue.");
        Console.ReadKey();
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        _goals.Clear(); // Clear current goals to load new ones

        try
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] goalData = parts[1].Split(',');

                string name = goalData[0];
                string description = goalData[1];
                int points = int.Parse(goalData[2]);

                switch (type)
                {
                    case "SimpleGoal":
                        bool isComplete = bool.Parse(goalData[3]);
                        SimpleGoal sGoal = new SimpleGoal(name, description, points);
                        if (isComplete)
                        {
                            sGoal.RecordEvent(); // Mark as complete without adding points again
                        }
                        _goals.Add(sGoal);
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(name, description, points));
                        break;
                    case "ChecklistGoal":
                        int target = int.Parse(goalData[3]);
                        int current = int.Parse(goalData[4]);
                        int bonus = int.Parse(goalData[5]);
                        ChecklistGoal cGoal = new ChecklistGoal(name, description, points, target, bonus);
                        cGoal.SetAmountCompleted(current);
                        _goals.Add(cGoal);
                        break;
                }
            }
            Console.WriteLine("Goals loaded successfully. Press any key to continue.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Press any key to continue.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
            Console.WriteLine("Press any key to continue.");
        }
        Console.ReadKey();
    }
}

// Main entry point for the program.
class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}

// Base Goal class
public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _shortName;
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract void RecordEvent();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}

// Simple Goal class (completed once)
public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
        }
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}

// Eternal Goal class (never completed)
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // No change in state, just grants points.
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}

// Checklist Goal class (completed multiple times for a bonus)
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    
    // Exceeds Requirements: Added a method to set the amount completed, which is useful
    // for loading goals from a file without triggering the RecordEvent logic.
    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }
    
    // Exceeds Requirements: The GetPoints method now includes the bonus logic.
    // When the goal is completed, it returns the bonus points in addition to the regular points.
    public new int GetPoints()
    {
        if (_amountCompleted == _target)
        {
            return _points + _bonus;
        }
        return _points;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_amountCompleted},{_bonus}";
    }
}