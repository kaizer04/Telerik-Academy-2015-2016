namespace WordsByChar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        //// static HashSet<string> allWords = new HashSet<string>();
        static Dictionary<char, HashSet<string>> wordsByCharDict = new Dictionary<char, HashSet<string>>();

        static void InitDict()
        {
            for (char a = 'a'; a <= 'z'; a++)
            {
                wordsByCharDict[a] = new HashSet<string>();
            }
        }

        static void AddWord(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                wordsByCharDict[word[i]].Add(word);
            }
        }

        static void ReadWords()
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string inputLine = Console.ReadLine();
                StringBuilder word = new StringBuilder();

                for (int j = 0; j < inputLine.Length; j++)
                {
                    if (inputLine[j] >= 'a' && inputLine[j] <= 'z')
                    {
                        word.Append(inputLine[j]);
                    }
                    else if (inputLine[j] >= 'A' && inputLine[j] <= 'Z')
                    {
                        word.Append((char)(inputLine[j] - 'A' + 'a'));
                    }
                    else if (word.Length > 0)
                    {
                        AddWord(word.ToString());
                        word.Clear();
                    }
                }

                if (word.Length > 0)
                {
                    AddWord(word.ToString());
                    word.Clear();
                }
            }
        }

        static void ProcessWords()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string wordToLower = word.ToLower();

                HashSet<string> current = new HashSet<string>(wordsByCharDict[wordToLower[0]]);
                for (int j = 0; j < wordToLower.Length; j++)
                {
                    current.IntersectWith(wordsByCharDict[wordToLower[j]]);
                }

                Console.WriteLine(word + " -> " + current.Count);
            }
        }

        public static void Main()
        {
            InitDict();
            ReadWords();
            ProcessWords();
        }
    }
}
