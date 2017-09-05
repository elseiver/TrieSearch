using System;
using System.Collections.Generic;
using System.Text;

namespace TrieLib
{
    public class Trie
    {
        private readonly Node _root;

        public Trie()
        {
            _root = new Node('^', 0, null, null);
        }

        public Node Prefix(string s)
        {
            var currentNode = _root;
            var result = currentNode;

            foreach (var c in s)
            {
                currentNode = currentNode.FindChildNode(c);
                if (currentNode == null)
                    break;
                result = currentNode;
            }

            return result;
        }

        public List<int> Search(string s)
        {
            var list = new List<int>();
            var prefix = Prefix(s);
            if (prefix.Depth == s.Length)
            {
                list = ChildIndexes(prefix, list);
            }
            return list;
        }

        public List<int> ChildIndexes(Node node, List<int> inputList)
        {
            if (node.IsTerminal)
            {
                inputList.AddRange(node.Indexes);
            }
            else
            {
                foreach(var n in node.Children.Values)
                {
                    inputList = ChildIndexes(n, inputList);
                }
            }
            return inputList;
        }

        public void InsertSet(Dictionary<int, string> items)
        {
            foreach(var item in items)
            {
                for(int i = 0; i < item.Value.Length; i++)
                {
                    Insert(item.Value.Substring(i), item.Key);
                }
            }
        }

        public void Insert(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
                Insert(items[i], i);
        }

        public void Insert(string s, int index)
        {
            var commonPrefix = Prefix(s);
            var current = commonPrefix;

            for (var i = current.Depth; i < s.Length; i++)
            {
                var newNode = new Node(s[i], current.Depth + 1, current, null);
                current.Children.TryAdd(s[i], newNode);
                current = newNode;
            }
            var node = current.FindChildNode('$');
            if (node == null)
            {
                node = new Node('$', current.Depth + 1, current, index);
                current.Children.TryAdd('$', node);
            }
            else
            {
                node.AddIndex(index);
            }
        }

        public void Delete(string s)
        {
            var node = Prefix(s);
            if (node != null)
            {
                node = node.FindChildNode('$');

                while (node.IsLeaf)
                {
                    var parent = node.Parent;
                    parent.DeleteChildNode(node.Value);
                    node = parent;
                }
            }
        }

    }
}
