namespace AdventOfCode.Days
{
    public static class Day5
    {
        internal class Stack 
        {
            static readonly int MAX = 1000;
            int top;
            char[] stack = new char[MAX];
            string name;

            bool IsEmpty()
            {
                return (top < 0);
            }

            public Stack(string name)
            {
                top = -1;
                this.name = name;
            }

            internal string GetName()
            {
                return name;
            }

            internal bool Push(char data)
            {
                if (top >= MAX) 
                {
                    Console.WriteLine("Stack " + name + " is full. Error adding a new element");
                    return false;
                }

                stack[++top] = data;
                return true;
            }

            internal char Pop()
            {
                if (top < 0)
                {
                    Console.WriteLine("Stack " + name + " has no elements.");
                    return ' ';
                }
                return stack[top--];
            }

            internal char Peek()
            {
                return stack[top];
            }
        }
        
        private static Stack[] stacks = new Stack[9] 
        {
            new Stack("1"),
            new Stack("2"),
            new Stack("3"),
            new Stack("4"),
            new Stack("5"),
            new Stack("6"),
            new Stack("7"),
            new Stack("8"),
            new Stack("9")
        };
        
        private static void InitializeStacks(string[] inputStack)
        {
            // Get stack count
            var stackCount = stacks.Length;

            // Initialize stacks
            for (var i = inputStack.Length - 1; i >= 0; i--) 
            {
                var pointer = 0;

                var line = inputStack[i];

                for (var j = 1; j <= stackCount; j++)
                {
                    if (j == 1) 
                    {
                        pointer = 1;
                    }

                    if (line[pointer] != ' ') 
                    {
                        stacks[j - 1].Push(line[pointer]);
                        
                        Console.WriteLine("Adding " + line[pointer] +  " to stack " + stacks[j - 1].GetName());
                    }

                    pointer += 4;
                }
            }
        }
        public static string Problem1(string[] inputStack, string[] inputMoves)
        {   
            InitializeStacks(inputStack);

            // Execute instructions
            foreach (string line in inputMoves) 
            {
                var split = line.Split(" ");
                var count = Int32.Parse(split[1]);
                var initialStack = Int32.Parse(split[3]);
                var finalStack = Int32.Parse(split[5]);

                for (int i = 0; i < count; i++)
                {
                    stacks[finalStack - 1].Push(stacks[initialStack - 1].Pop());
                }
            }

            //Create result string
            var result = "";

            foreach (var stack in stacks)
            {
                result += stack.Peek();
            }

            return result;
        }

        public static string Problem2(string[] inputStack, string[] inputMoves)
        {
            InitializeStacks(inputStack);

            // Execute instructions
            foreach (string line in inputMoves)
            {
                var split = line.Split(" ");
                var count = Int32.Parse(split[1]);
                var initialStack = Int32.Parse(split[3]);
                var finalStack = Int32.Parse(split[5]);
                var toPush = "";

                for (var i = 0; i < count; i++)
                {
                    toPush += stacks[initialStack - 1].Pop();
                }

                for (var j = toPush.Length - 1; j >= 0; j--)
                {
                    stacks[finalStack - 1].Push(toPush[j]);
                } 
            }

            //Create result string
            var result = "";

            foreach (var stack in stacks)
            {
                result += stack.Peek();
            }

            return result;
        }
    }
}