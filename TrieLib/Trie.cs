using System;
using System.Collections.Generic;
using System.Linq;
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

        #region Insert Methods

        public void InsertSet(Dictionary<int, string> items)
        {
            foreach (var item in items)
            {
                var s = $"#{item.Value.ToLower()}";
                var l = s.Length;
                for (int i = 0; i < s.Length; i++)
                {
                    Insert(s.Substring(i, l - i < 10 ? l - i : 10), item.Key);
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

        #endregion

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

        public Dictionary<int, int> Search(string s, int limit = int.MaxValue)
        {
            var dict = new Dictionary<int, int>();
            var list = new List<int>();
            s = s.Substring(0, s.Length > 10 ? 10 : s.Length).ToLower();
            var s1 = $"#{s}";
            var prefix = Prefix(s1);
            if (prefix.Depth == s1.Length)
            {
                list = ChildIndexes(prefix, list);
            }
            list.ForEach(i => dict.Add(i, 1));
            if (list.Count >= limit) return dict;

            var s2 = $" {s}";
            prefix = Prefix(s2);
            if (prefix.Depth == s2.Length)
            {
                var listWordStart = new List<int>();
                listWordStart = ChildIndexes(prefix, list);
                listWordStart.ForEach(i => { if (!dict.ContainsKey(i)) dict.Add(i, 2); });
            }
            if (dict.Count >= limit) return dict;

            prefix = Prefix(s);
            if (prefix.Depth == s.Length)
            {
                var listContains = new List<int>();
                listContains = ChildIndexes(prefix, list);
                listContains.ForEach(i => { if (!dict.ContainsKey(i)) dict.Add(i, 3); });
            }
            return dict;
        }

        public List<int> ChildIndexes(Node node, List<int> inputList)
        {
            if (node.IsTerminal)
            {
                inputList.AddRange(node.Indexes);
            }
            else
            {
                foreach (var n in node.Children.Values)
                {
                    inputList = ChildIndexes(n, inputList);
                }
            }
            return inputList;
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
