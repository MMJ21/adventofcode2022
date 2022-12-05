public class Program {
    public static void Main() {
        string[] myInput = File.ReadAllLines(@"../input1.txt");

        Console.WriteLine(Day1.Problem1(myInput));
    }
}

