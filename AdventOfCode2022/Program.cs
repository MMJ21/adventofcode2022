using AdventOfCode.Days;

public class Program {

    public static void Main() {

        string[] myMoves = File.ReadAllLines(@"D:\Projects\Personal\AdventO\input5moves.txt");
        string[] myStacks = File.ReadAllLines(@"D:\Projects\Personal\AdventO\input5stacks.txt");
        Console.WriteLine(Day5.Problem1(myStacks, myMoves));
    }
}