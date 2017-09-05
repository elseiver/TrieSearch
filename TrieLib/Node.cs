using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TrieLib
{
    public class Node
    {
        public char Value { get; set; }
        public ConcurrentDictionary<char, Node> Children { get; set; }
        public Node Parent { get; set; }
        public int Depth { get; set; }
        public List<int> Indexes { get; set; }

        public Node(char value, int depth, Node parent, int? index)
        {
            Value = value;
            Children = new ConcurrentDictionary<char,Node>();
            Depth = depth;
            Parent = parent;
            Indexes = new List<int>();
            if (index.HasValue) Indexes.Add(index.Value);
        }

        public bool IsLeaf
        {
            get
            {
                return Children.Count == 0;
            }
        }

        public bool IsTerminal
        {
            get
            {
                return Value == '$';
            }
        }

        public Node FindChildNode(char c)
        {
            Node childNode;
            if (Children.ContainsKey(c))
                if (Children.TryGetValue(c, out childNode))
                    return childNode;

            return null;
        }

        public bool DeleteChildNode(char c)
        {
            Node deletedNode;
            if (Children.ContainsKey(c))
                return Children.TryRemove(c, out deletedNode);
            return false;
        }
    }
}
