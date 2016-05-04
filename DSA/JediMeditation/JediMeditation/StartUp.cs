namespace JediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            int numberJedi = int.Parse(Console.ReadLine());
            string inputJedi = Console.ReadLine();
            
            string[] allJedi = inputJedi.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> masters = new List<string>();
            List<string> knights = new List<string>();
            List<string> padowans = new List<string>();

            foreach (var jedi in allJedi)
            {
                if (jedi[0] == 'm')
                {
                    masters.Add(jedi);
                }
                else if (jedi[0] == 'k')
                {
                    knights.Add(jedi);
                }
                else if (jedi[0] == 'p')
                {
                    padowans.Add(jedi);
                }
            }

            masters.OrderByDescending(m => m[1]);
            //masters.OrderByDescending(k => k[1]);

            var allJediOrdered = new StringBuilder();
            allJediOrdered.Append(Print(masters));
            allJediOrdered.Append(Print(knights));
            allJediOrdered.Append(Print(padowans));

            Console.WriteLine(allJediOrdered.ToString().TrimEnd());
        }

        public static string Print(List<string> jediList)
        {
            int count = jediList.Count;
            var result = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                result.Append(jediList[i]);
                result.Append(" ");
            }

            return result.ToString();
        }
    }
}