using AdventOfCode.Days;

public class Program {

    public static void Main() {

        string[] myInput = File.ReadAllLines(@"D:\Projects\Personal\AdventO\input2.txt");
        List<KeyValuePair<char, char>> myMatchups = new List<KeyValuePair<char, char>>();

        foreach (string matchup in myInput)
        {
            myMatchups.Add(new KeyValuePair<char, char>(matchup[0], matchup[2]));
        }

        Console.WriteLine(Day2.Problem2(myMatchups));
    }
}