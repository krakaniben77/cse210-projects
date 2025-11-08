using System;

public class Journal
{
    public List<Entry> Entries = new List<Entry>();
    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);

    }

    public void DisplayAll()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("No entries yet.");

        }
        else
        {
            foreach (Entry entry in Entries)
            {
                entry.Dispalay();

            }
        }
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in Entries)
            {
                outputFile.WriteLine(entry.ToFileFormate());
            }
        }
        Console.WriteLine($" Journal saved to {filename}");

    }
    public void LoadFromFile(string filename)
    {
        Entries.Clear();
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                Entry entry = Entry.FromFileFormate(line);
                if (entry != null)
                {
                    Entries.Add(entry);

                }
            }
            Console.WriteLine($"Journal Loaded from {filename}");
        }
        else
        {
            Console.WriteLine("File not found");
        }
    }
}