//namespace Friends
//{
//    using System;
//    using System.Collections.Generic;
//    using System.IO;
//    using System.Linq;
//    using System.Text;
//    using System.Threading.Tasks;

//    public class Program
//    {
//        public class Vertex : IComparable<Vertex>
//        {
//            public Vertex(int name, int weight)
//            {
//                this.Name = name;
//                this.Weight = weight;
//            }

//            public int Name { get; set; }

//            public int Weight { get; set; }

//            public int CompareTo(Vertex other)
//            {
//                if (this.Weight.CompareTo(other.Weight) == 0)
//                {
//                    return this.Name.CompareTo(other.Name);
//                }

//                return this.Weight.CompareTo(other.Weight);
//            }
//        }

//        static int n;
//        static int m;
//        static List<Vertex>[] vertices;

//        static int s;
//        static int e;
//        static int m1;
//        static int m2;

//        static string GetInput()
//        {
//            return @"18 30
//1 17
//11 4
//1 8 15
//1 9 1
//1 14 100
//2 4 100
//2 8 10
//2 9 100
//3 9 100
//3 10 3
//3 14 1
//4 9 1
//4 10 3
//4 11 1
//5 11 6
//5 16 7
//6 7 1
//6 11 1
//6 15 7
//6 16 1
//7 11 3
//7 15 2
//7 18 1
//8 18 1
//10 12 4
//10 13 6
//11 12 5
//12 13 10
//12 17 100
//13 14 2
//15 16 10
//16 17 2";
//        }

//        static void MockInput()
//        {
//            Console.SetIn(new StringReader(GetInput()));
//        }

//        static void ReadInput()
//        {
//            int[] nm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//            n = nm[0];
//            m = nm[1];

//            int[] se = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//            s = se[0] - 1;
//            e = se[1] - 1;

//            int[] m1m2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//            m1 = m1m2[0] - 1;
//            m2 = m1m2[1] - 1;

//            vertices = new List<Vertex>[n];

//            for (int i = 0; i < m; i++)
//            {
//                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//                var from = edge[0] - 1;
//                var to = edge[1] - 1;
//                var w = edge[2];

//                AddEdge(from, to, w);
//                AddEdge(to, from, w);
//            }
//        }

//        private static void AddEdge(int from, int to, int weight)
//        {
//            if (vertices[from] == null)
//            {
//                vertices[from] = new List<Vertex>();
//            }

//            vertices[from].Add(new Vertex(to, weight));
//        }

//        static void Solve()
//        {
//            int fromToM1 = Dijkstra(s, m1, m2, e);
//            int fromToM2 = Dijkstra(s, m2, m1, e);

//            int m1ToM2 = Dijkstra(m1, m2, s, e);

//            int m1ToTo = Dijkstra(m1, e, s, m2);
//            int m2ToTo = Dijkstra(m2, e, s, m1);

//            int min = Math.Min(
//                fromToM1 + m1ToM2 + m2ToTo,
//                fromToM2 + m1ToM2 + m1ToTo
//                );

//            Console.WriteLine(min);
//        }

//        private static int Dijkstra(int s, int e, params int[] excludes)
//        {
//            //HashSet<int> visited = new HashSet<int>();
//            bool[] visited = new bool[n];
//            int[] d = Enumerable.Repeat(int.MaxValue, n).ToArray();
//            d[s] = 0;

//            SortedSet<Vertex> queue = new SortedSet<Vertex>();

//            queue.Add(new Vertex(s, 0));

//            while (queue.Count > 0)
//            {
//                // heap.Pop();
//                var current = queue.Min;
//                queue.Remove(current);
//                //visited.Add(current.Name);
//                visited[current.Name] = true;

//                foreach (var next in vertices[current.Name])
//                {
//                    if (excludes.Contains(next.Name))
//                    {
//                        continue;
//                    }

//                    if (d[next.Name] > d[current.Name] + next.Weight)
//                    {
//                        d[next.Name] = d[current.Name] + next.Weight;
//                        queue.Add(new Vertex(next.Name, d[next.Name]));
//                    }
//                }

//                while (queue.Count > 0 && visited[queue.Min.Name])
//                {
//                    queue.Remove(queue.Min);
//                }

//                // vertices[current.Name].Where(next => !excludes.Any(exclude => exclude == next.Name));
//            }
//            // find best

//            // update distances

//            return d[e];
//        }

//        public static void Main()
//        {
//            //MockInput();
//            ReadInput();
//            //for (int i = 0; i < vertices.Length; i++)
//            //{
//            //    Console.WriteLine("Vertex: {0}", i);
//            //    if (vertices[i] != null)
//            //    {
//            //        foreach (var next in vertices[i])
//            //        {
//            //            Console.Write("{0} ", next.Name);
//            //        }
//            //        Console.WriteLine();
//            //    }
//            //}

//            Solve();
//        }
//    }
//}
