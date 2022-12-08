using AdventOfCode.Days;
public class Program {
    public static void Main() {
        string[] myInput = File.ReadAllLines(@"C:\Users\marco\Desktop\advent2022\input2.txt");
        List<KeyValuePair<char, char>> myMatchups = new List<KeyValuePair<char, char>>();
        foreach (string matchup in myInput)
        {
            myMatchups.Add(new KeyValuePair<char, char>(matchup[0], matchup[2]));
        }
        Console.WriteLine(Day2.Problem1(myMatchups));
    }
}

