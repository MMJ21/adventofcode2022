namespace AdventOfCode.Days
{
    public static class Day4
    {
        private static Func<string, int[]> ConvertIntoIntArray = (string s) => 
        {
            var numbers = s.Split("-");
            return new int[] { Int32.Parse(numbers[0]), Int32.Parse(numbers[1]) };
        };
        public static int Problem1(string[] input)
        {
            var result = 0;

            foreach (var rawPair in input)
            {
                var pair = rawPair.Split(",");
                var first = ConvertIntoIntArray(pair[0].TrimStart());
                var second = ConvertIntoIntArray(pair[1].TrimEnd());

                if ((first[0] <= second[0] && first[1] >= second[1])
                    || (first[0] >= second[0] && first[1] <= second[1]))
                {
                    result++;
                }
            }

            return result;
        }
        public static int Problem2(string[] input)
        {
            var result = 0;
            
            foreach (var rawPair in input)
            {
                var pair = rawPair.Split(",");
                var first = ConvertIntoIntArray(pair[0].TrimStart());
                var second = ConvertIntoIntArray(pair[1].TrimEnd());

                if ((first[0] >= first[1] && first[0] <= second[1])
                    || (first[1] >= first[0] && first[1] <= second[0]))
                {
                    result++;
                }
            }

            return result;
        }
    }
}