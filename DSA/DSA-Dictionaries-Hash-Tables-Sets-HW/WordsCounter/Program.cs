using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordsCounter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var text = new StreamReader("text.txt").ReadToEnd().ToLower();
            //             string regex = @"\b\w+\b";
            //             MatchCollectionollection words = Regex.Matches(text, regex);
            var words = text.Split(new char[] { '.', '!', '?', ';', ' ', ':', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var dictionary = new Dictionary<string, int>();
            foreach (var item in words)
            {
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item]++;
                }
                else
                {
                    dictionary.Add(item, 1);
                }
            }

            foreach (var item in dictionary.OrderBy(x => x.Value))
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }

            Console.ReadKey(true);
        }
    }
}