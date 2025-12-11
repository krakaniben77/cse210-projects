using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    
    abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;           // points awarded for a single completion
        protected bool _isComplete;

        protected Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        public string Name => _name;
        public string Description => _description;
        public int Points => _points;
        public bool IsComplete => _isComplete;

        
        public abstract int RecordEvent();

                public virtual string Serialize()
        {
                        return $"{GetType().Name}|{Escape(_name)}|{Escape(_description)}|{_points}|{_isComplete.ToString()}";
        }

        
        public static string Escape(string s)
        {
            return s.Replace("|", "&#124;"); // simple escaping for pipe
        }

        public static string Unescape(string s)
        {
            return s.Replace("&#124;", "|");
        }

        
        public virtual string GetDetailsString()
        {
            string status = _isComplete ? "[X]" : "[ ]";
            return $"{status} {_name} ({_description}) — Points: { _points }";
        }

        
        protected void MarkComplete()
        {
            _isComplete = true;
        }

        
        public static Goal Deserialize(string line)
        {
            
            var parts = SplitPreserveEmpty(line, '|').ToArray();
            if (parts.Length < 5) return null;
            string type = parts[0];
            string name = Unescape(parts[1]);
            string desc = Unescape(parts[2]);
            if (!int.TryParse(parts[3], out int pts)) pts = 0;
            bool.TryParse(parts[4], out bool isComplete);

            if (type == nameof(SimpleGoal))
            {
                var g = new SimpleGoal(name, desc, pts);
                if (isComplete) g.ForceComplete(); // internal helper
                return g;
            }
            else if (type == nameof(EternalGoal))
            {
                var g = new EternalGoal(name, desc, pts);
                if (isComplete) g.ForceComplete();
                return g;
            }
            else if (type == nameof(ChecklistGoal))
            {
                
                if (parts.Length < 8) return null;
                if (!int.TryParse(parts[5], out int target)) target = 0;
                if (!int.TryParse(parts[6], out int current)) current = 0;
                if (!int.TryParse(parts[7], out int bonus)) bonus = 0;
                var g = new ChecklistGoal(name, desc, pts, target, bonus);
                g.ForceSetCurrent(current);
                if (isComplete) g.ForceComplete();
                return g;
            }

            return null;
        }

        
        private static IEnumerable<string> SplitPreserveEmpty(string s, char sep)
        {
            var parts = s.Split(sep);
            return parts;
        }
    }

    
    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) 
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            if (_isComplete)
            {
                Console.WriteLine("This goal is already completed. No points awarded.");
                return 0;
            }

            MarkComplete();
            Console.WriteLine($"Goal '{_name}' completed! You earned {_points} points.");
            return _points;
        }

        public override string Serialize()
        {
            return base.Serialize();
        }

        public void ForceComplete()
        {
            _isComplete = true;
        }
    }

       class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            Console.WriteLine($"Recorded '{_name}'. You earned {_points} points.");
            return _points;
        }

        public override string Serialize()
        {
            return base.Serialize();
        }

        public void ForceComplete() // kept for deserialization parity though eternal goals never "complete"
        {
            _isComplete = true;
        }
    }

     
    class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _completionBonus;

        public ChecklistGoal(string name, string description, int pointsPerCompletion, int targetCount, int completionBonus)
            : base(name, description, pointsPerCompletion)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _completionBonus = completionBonus;
        }

        public override int RecordEvent()
        {
            if (_isComplete)
            {
                Console.WriteLine("This checklist goal is already completed. No points awarded.");
                return 0;
            }

            _currentCount++;
            int awarded = _points;
            Console.WriteLine($"Progress for '{_name}': {_currentCount}/{_targetCount} — You gained {_points} points.");

            if (_currentCount >= _targetCount)
            {
                MarkComplete();
                awarded += _completionBonus;
                Console.WriteLine($"Congratulations — you finished '{_name}' and earned a bonus of {_completionBonus} points!");
            }

            return awarded;
        }

        public override string GetDetailsString()
        {
            string status = _isComplete ? "[X]" : "[ ]";
            return $"{status} {_name} ({_description}) — {_currentCount}/{_targetCount} times completed — {(_points)} pts each, bonus { _completionBonus }";
        }

        public override string Serialize()
        {
           
            return $"{base.Serialize()}|{_targetCount}|{_currentCount}|{_completionBonus}";
        }

       
        public void ForceSetCurrent(int current)
        {
            _currentCount = current;
        }

        public void ForceComplete()
        {
            _isComplete = true;
        }
    }

    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int totalScore = 0;
        const string SAVE_FILE = "goals.txt";

        static void Main()
        {
            Console.Title = "Eternal Quest - Goal Tracker";
            LoadFromFileOnStart();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Eternal Quest ===");
                Console.WriteLine($"Total Score: {totalScore}");
                Console.WriteLine();
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event (complete a goal)");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Quit");
                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine() ?? "";
                switch (choice.Trim())
                {
                    case "1": CreateNewGoal(); break;
                    case "2": ListGoals(); Pause(); break;
                    case "3": RecordEventMenu(); Pause(); break;
                    case "4": SaveToFile(); Pause(); break;
                    case "5": LoadFromFile(); Pause(); break;
                    case "6": SaveOnExitPrompt(); return;
                    default: Console.WriteLine("Invalid option."); Pause(); break;
                }
            }
        }

        static void CreateNewGoal()
        {
            Console.Clear();
            Console.WriteLine("Create New Goal");
            Console.WriteLine("1. Simple Goal (complete once)");
            Console.WriteLine("2. Eternal Goal (repeatable)");
            Console.WriteLine("3. Checklist Goal (complete N times for bonus)");
            Console.Write("Choose goal type: ");
            string t = Console.ReadLine() ?? "";

            Console.Write("Goal name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Short description: ");
            string desc = Console.ReadLine() ?? "";

            int points = PromptForInt("Points awarded per completion (integer): ");

            if (t == "1")
            {
                goals.Add(new SimpleGoal(name, desc, points));
                Console.WriteLine("Simple goal created.");
            }
            else if (t == "2")
            {
                goals.Add(new EternalGoal(name, desc, points));
                Console.WriteLine("Eternal goal created.");
            }
            else if (t == "3")
            {
                int target = PromptForInt("How many times must this be completed to finish (target count)? ");
                int bonus = PromptForInt("Completion bonus points: ");
                goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                Console.WriteLine("Checklist goal created.");
            }
            else
            {
                Console.WriteLine("Unknown type. Aborting.");
            }
            Pause();
        }

        static void ListGoals()
        {
            Console.Clear();
            Console.WriteLine("Your Goals:");
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
            }
        }

        static void RecordEventMenu()
        {
            Console.Clear();
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available. Create one first.");
                return;
            }

            Console.WriteLine("Select a goal to record an event:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
            }
            int sel = PromptForInt($"Choose (1-{goals.Count}): ");
            if (sel < 1 || sel > goals.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var goal = goals[sel - 1];
            int earned = goal.RecordEvent();
            totalScore += earned;
            Console.WriteLine($"Your total score is now: {totalScore}");
        }

        static int PromptForInt(string prompt)
        {
            int val;
            while (true)
            {
                Console.Write(prompt);
                string? s = Console.ReadLine();
                if (int.TryParse(s, out val)) return val;
                Console.WriteLine("Please enter a valid integer.");
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

        
        static void SaveToFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(SAVE_FILE))
                {
                    sw.WriteLine(totalScore);
                    foreach (var g in goals)
                    {
                        sw.WriteLine(g.Serialize());
                    }
                }
                Console.WriteLine($"Saved {goals.Count} goals to {SAVE_FILE} (score saved).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving: {ex.Message}");
            }
        }

        static void LoadFromFile()
        {
            try
            {
                if (!File.Exists(SAVE_FILE))
                {
                    Console.WriteLine("No save file found.");
                    return;
                }

                var lines = File.ReadAllLines(SAVE_FILE);
                if (lines.Length == 0) { Console.WriteLine("Save file empty."); return; }

               
                if (!int.TryParse(lines[0], out int scoreFromFile)) scoreFromFile = 0;
                totalScore = scoreFromFile;

                goals.Clear();
                for (int i = 1; i < lines.Length; i++)
                {
                    var g = Goal.Deserialize(lines[i]);
                    if (g != null) goals.Add(g);
                }

                Console.WriteLine($"Loaded {goals.Count} goals. Score = {totalScore}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading: {ex.Message}");
            }
        }

        static void LoadFromFileOnStart()
        {
            if (File.Exists(SAVE_FILE))
            {
                try
                {
                    var lines = File.ReadAllLines(SAVE_FILE);
                    if (lines.Length > 0 && int.TryParse(lines[0], out int scoreFromFile))
                    {
                        totalScore = scoreFromFile;
                        for (int i = 1; i < lines.Length; i++)
                        {
                            var g = Goal.Deserialize(lines[i]);
                            if (g != null) goals.Add(g);
                        }
                                            }
                }
                catch
                {
                    
                }
            }
        }

        static void SaveOnExitPrompt()
        {
            Console.Write("Save before quitting? (Y/N): ");
            string? s = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(s) && (s.Trim().ToUpper() == "Y"))
            {
                SaveToFile();
            }
            Console.WriteLine("Goodbye!");
        }
    }
}
