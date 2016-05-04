namespace MaxPath
{
    using System.Collections.Generic;

    public class Node
    {
        private int value;
        private bool hasParent;
        private List<Node> children;

        public Node(int value)
        {
            this.value = value;
            this.children = new List<Node>();
        }

        public int Value 
        {
            get 
            {
                return this.value;
            }
        }

        public int NumberOfChildren
        {
            get
            {
                return this.children.Count;
            }
        }

        public void AddChild(Node child)
        {
            child.hasParent = true;
            children.Add(child);
        }

        public Node GetChild(int index)
        {
            return this.children[index];
        }
    }
}
