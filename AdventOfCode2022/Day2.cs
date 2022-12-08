namespace AdventOfCode.Days
{
    public static class Day2  {
        private static Dictionary<char, int> ShapePointDictionary { get; set; }

        private static void InitializeDictionary ()
        {
            ShapePointDictionary = new Dictionary<char, int>();
            ShapePointDictionary.Add('A', 1);
            ShapePointDictionary.Add('B', 2);
            ShapePointDictionary.Add('C', 3);
            ShapePointDictionary.Add('X', 1);
            ShapePointDictionary.Add('Y', 2);
            ShapePointDictionary.Add('Z', 3);
        }

        private static int CalculateScore(char key, char value)
        {
            var score = 0;
            if (Char.ToUpperInvariant(key).Equals('A'))
            {
                if (Char.ToUpperInvariant(value).Equals('X'))
                {
                    score = 3;
                }
                if (Char.ToUpperInvariant(value).Equals('Y'))
                {
                    score = 6;
                }
                if (Char.ToUpperInvariant(value).Equals('Z'))
                {
                    score = 0;
                }
            }
            else if (Char.ToUpperInvariant(key).Equals('B'))
            {
                if (Char.ToUpperInvariant(value).Equals('X'))
                {
                    score = 0;
                }
                if (Char.ToUpperInvariant(value).Equals('Y'))
                {
                    score = 3;
                }
                if (Char.ToUpperInvariant(value).Equals('Z'))
                {
                    score = 6;
                }
            }
            else if (Char.ToUpperInvariant(key).Equals('C'))
            {
                if (Char.ToUpperInvariant(value).Equals('X'))
                {
                    score = 6;
                }
                if (Char.ToUpperInvariant(value).Equals('Y'))
                {
                    score = 0;
                }
                if (Char.ToUpperInvariant(value).Equals('Z'))
                {
                    score = 3;
                }
            }
            else
            {
                score = -1;
            }
            
            return score;
        }
        
        public static int Problem1 (List<KeyValuePair<char, char>> input){
            InitializeDictionary();

            var score = 0;

            foreach (var pair in input)
            {
                int shapeScore = 0;
                if (ShapePointDictionary.TryGetValue(
                        pair.Value,
                        out shapeScore))
                {
                    score += shapeScore;
                    score += CalculateScore(pair.Key, pair.Value);

                }
                else
                {
                    return -1;
                }
            }
            
            return score;
        }
    }
}