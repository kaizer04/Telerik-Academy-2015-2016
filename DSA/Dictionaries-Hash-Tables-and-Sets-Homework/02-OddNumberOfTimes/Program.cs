﻿namespace _02_OddNumberOfTimes
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            List<string> words = new List<string>() { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            Dictionary<string, int> wordOccurances = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordOccurances.ContainsKey(word))
                {
                    wordOccurances[word]++;
                }
                else
                {
                    wordOccurances.Add(word, 1);
                }
            }
            
            foreach (var wordOccurance in wordOccurances)
            {
                if (wordOccurance.Value % 2 != 0)
                {
                    Console.WriteLine(wordOccurance.Key);
                }
            }
        }
    }
}