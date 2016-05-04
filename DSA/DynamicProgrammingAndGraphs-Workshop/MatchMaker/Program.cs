namespace MatchMaker
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static string GetInput()
        {
            return @"6
Pesho
m
1
ski
Gosho
m
3
chalga ski batman
Ivancho
m
2
batman ski
Mariika
f
1
chalga
Petra
f
3
chalga batman ski
Elena
f
1
batman";
        }

        private static void Solve()
        {
            Queue<string> queue = new Queue<string>();
            var matches = new Dictionary<string, int>();
            foreach (var gal in gals)
            {
                queue.Clear();
                matches.Clear();

                queue.Enqueue(gal);
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();

                    vertices[current].ForEach(next => 
                    {
                        if (guys.Contains(next))
                        {
                            if (matches.ContainsKey(next))
                            {
                                matches[next] = 0;
                            }

                            matches[next]++;
                        }
                        else 
                        { 
                            queue.Enqueue(next); 
                        }
                    });
                    //foreach (var next in vertices[current])
                    //{
                    //    if (guys.Contains(next))
                    //    {
                    //        if (matches.ContainsKey(next))
                    //        {
                    //            matches[next] = 0;
                    //        }

                    //        matches[next]++;
                    //    }
                    //    else 
                    //    { 
                    //        queue.Enqueue(next); 
                    //    }
                    //}

                    // All matches found

                    // check best
                    // best match
                    // order
                }
            }
        }

        private static void ReadInput()
        {
            guys = new HashSet<string>();
            gals = new HashSet<string>();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var gender = Console.ReadLine();
                var __ = Console.ReadLine();
                var interests = Console.ReadLine().Split(' ');
                foreach (var interest in interests)
                {
                    string from;
                    string to;
                    if (gender == "f")
                    {
                        from = name;
                        to = interest;
                        gals.Add(name);
                    }
                    else
                    {
                        from = interest;
                        to = name;
                        guys.Add(name);
                    }
                    
                    if (vertices.ContainsKey(from))
                    {
                        vertices[from] = new List<string>();
                    }

                    vertices[from].Add(to);
                }
            }
        }

        private static void MockInput()
        {
            Console.SetIn(new StringReader(GetInput()));
        }

        static Dictionary<string, List<string>> vertices;
        static HashSet<string> guys;
        static HashSet<string> gals;

        public static void Main()
        {
            MockInput();
            ReadInput();
            //for (int i = 0; i < vertices.Length; i++)
            //{
            //    Console.WriteLine("Vertex: {0}", i);
            //    if (vertices[i] != null)
            //    {
            //        foreach (var next in vertices[i])
            //        {
            //            Console.Write("{0} ", next.Name);
            //        }
            //        Console.WriteLine();
            //    }
            //}

            Solve();
        }
    }
}
