using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Days;

public static class Day3 
{
    private static char[] Chars = new char[] 
    { 
        ' ', 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
    };

    private static Func<string, char> RepeatedCharacter = (string s) => {
        var compartments = SplitString(s, s.Count() / 2).ToList();
        for (var i = 0; i < compartments[0].Length; i++) 
        {
            if (compartments[0].Contains(compartments[1][i])) 
            {
                return compartments[1][i];
            }
        }
        
        throw new KeyNotFoundException();
    };

    private static Func<string[], char> RepeatedCharacterInGroupedRucksacks = (string[] group) => {
        if (group.Length != 3)
        {
            throw new InvalidDataException();
        }
        for (var i = 0; i < group[0].Length; i++)
        {
            if (group[1].Contains(group[0][i]) && group[2].Contains(group[0][i]))
            {
                return group[0][i];
            }
        }

        throw new KeyNotFoundException();
    };

    private static IEnumerable<string> SplitString(string str, int chunkSize) 
    {
        return Enumerable.Range(0, str.Length / chunkSize)
        .Select(i => str.Substring(i * chunkSize, chunkSize));
    }

    private static IEnumerable<string[]> SplitRucksacksInGroups(string[] rucksacks) 
    {
        List<string[]> groupedRucksacks = new List<string[]>();
        var i = 0;
        
        while (i + 2 < rucksacks.Count()) 
        {
            groupedRucksacks.Add(new string[] { rucksacks[i], rucksacks[i + 1], rucksacks[i + 2]});
            i += 3;
        }

        return groupedRucksacks;
    }

    public static int Problem1(string[] input) 
    {
        var sumPriorities = 0;

        try 
        {        
            foreach (var rucksack in input) 
            {
                sumPriorities += Array.IndexOf(Chars, RepeatedCharacter(rucksack));
            }
        }
        catch 
        {
            return -1;
        }

        return sumPriorities;
    }

    public static int Problem2(string[] input)
    {
        var sumPriorities = 0;

        try {
            var groupedRucksacks = SplitRucksacksInGroups(input);

            foreach (var group in groupedRucksacks)
            {
                sumPriorities += Array.IndexOf(Chars, RepeatedCharacterInGroupedRucksacks(group));
            }
        }
        catch {
            return -1;
        }

        return sumPriorities;
    }
}