namespace MaxPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static long maxSum = 0;
        static HashSet<Node> usedNodes = new HashSet<Node>();

        static void DFS(Node node, long currentSum)
        {
            currentSum += node.Value;
            usedNodes.Add(node);

            for (int i = 0; i < node.NumberOfChildren; i++)
            {
                if (usedNodes.Contains(node.GetChild(i)))
                {
                    continue;
                }

                DFS(node.GetChild(i), currentSum);
            }

            if (node.NumberOfChildren == 1 && currentSum >= maxSum)
            {
                maxSum = currentSum;
            }
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, Node> nodes = new Dictionary<int, Node>();

            int maxNode = 0;

            for (int i = 0; i < n - 1; i++)
            {
                string connection = Console.ReadLine();

                string[] separatedConnection = connection.Split(new char[] {'(', '<', '-', ')'}, StringSplitOptions.RemoveEmptyEntries);

                int parent = int.Parse(separatedConnection[0]);
                int child = int.Parse(separatedConnection[1]);

                Node parentNode;
                Node childNode;

                if (nodes.ContainsKey(parent))
                {
                    parentNode = nodes[parent];
                }
                else
                {
                    parentNode = new Node(parent);
                    nodes.Add(parent, parentNode);
                }

                if (nodes.ContainsKey(child))
                {
                    childNode = nodes[child];
                }
                else
                {
                    childNode = new Node(child);
                    nodes.Add(child, childNode);
                }

                parentNode.AddChild(childNode);
                childNode.AddChild(parentNode);

                if (parent > maxNode)
                {
                    maxNode = parent;
                }

                if (child > maxNode)
                {
                    maxNode = child;
                }
            }

            foreach (var node in nodes)
            {
                if (node.Value.NumberOfChildren == 1)
                {
                    usedNodes.Clear();
                    DFS(node.Value, 0);
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
