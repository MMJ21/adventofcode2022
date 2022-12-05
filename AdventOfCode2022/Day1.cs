public static class Day1 {
    public static int Problem1(string[] input) {
        var maxSum = 0;
        var currentSum = 0;
        for (int i = 0; i < input.Length; i++) {
            try {
                var nextInput = Int32.Parse(input[i].TrimEnd());
                currentSum += nextInput;
            }
            catch (Exception) {
                maxSum = currentSum > maxSum ? currentSum : maxSum;
                currentSum = 0;
            }
        }

        return maxSum;
    }
 }