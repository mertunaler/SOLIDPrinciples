
using Microsoft.VisualBasic;
using System.Diagnostics;
/*
This example is created for demonstrating the SOLID's S principle --> Single Responsibility Principle. 

---------------------------------------------------------------------------------------------------------------------------------

Class Definitions:
Journal class has AddEntry for adding a string, RemoveEntry for deleting a string, ToString for ensuring the text is string.
Persistence class has SaveToFile which creates a file and writes to that file.

---------------------------------------------------------------------------------------------------------------------------------

After some time persistence implementation is needed to save journals to a file. If we go and add that into the Journal class,
we would have violated the Single Responsibility Principle. In order to solve that issue, we create another class Persistence and,
add all of the related implementations to that class. 
*/

public class Journal
{
    private readonly List<string> entries = new List<string>();

    private static int count = 0;

    public int AddEntry(string entry)
    {
        entries.Add($"{++count}:{entry}");
        return count;
    }
    public void RemoveEntry(int index)
    {
        entries.RemoveAt(index);
    }
    public override string ToString()
    {
        return string.Join(Environment.NewLine, entries);
    }
}
public class Persistence
{
    public void SaveToFile(Journal journal, string fileName, bool flag = false)
    {
        if (flag || !File.Exists(fileName))
        {
            File.WriteAllText(fileName, journal.ToString());
        }
    }
}
public class Demo
{
    public static void Main(string[] args)
    {
        var j = new Journal();
        j.AddEntry("HelloWorld!");
        j.AddEntry("This is an example of SOLID's S!");
        Console.WriteLine(j);
        var p = new Persistence();
        string fileName = @"c:\temp\myTxt.txt";
        p.SaveToFile(j, fileName);
        Process.Start(fileName);
    }
}