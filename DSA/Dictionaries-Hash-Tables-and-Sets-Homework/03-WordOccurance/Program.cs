namespace _03_WordOccurance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            //Console.WriteLine("Enter some text with repeated words: ");
            //string text = Console.ReadLine();
            string text = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";
            Console.WriteLine("Enter some text with repeated words:\n{0}", text);
            
            string regex = @"\b\w+\b";
            IDictionary<string, int> dictionary = new Dictionary<string, int>();
            MatchCollection words = Regex.Matches(text.ToLower(), regex);
            foreach (Match word in words)
            {
                if (dictionary.ContainsKey(word.ToString()))
                {
                    dictionary[word.ToString()] += 1;
                }
                else
                {
                    dictionary.Add(word.ToString(), 1);
                }
            }
            foreach (var word in dictionary.OrderBy(m => m.Value))
            {
                Console.WriteLine("{0} - {1}", word.Key, word.Value);
            }
        }
    }
}