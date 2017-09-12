using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new TrieLib.Trie();

            var itemsSet = new Dictionary<int, string>();
            itemsSet.Add(1, "Victor test hiking club biography");
            itemsSet.Add(2, "Alex");
            itemsSet.Add(3, "Constructor");
            itemsSet.Add(4, "Destructor");

            trie.InsertSet(itemsSet);



            Console.WriteLine(string.Join(",", trie.Search("Alex").OrderBy(e => e.Value).Select(s => $"{itemsSet[s.Key]}")));
            Console.WriteLine(string.Join(",", trie.Search("Test").OrderBy(e => e.Value).Select(s => $"{itemsSet[s.Key]}")));
            Console.WriteLine(string.Join(",", trie.Search("Victor").OrderBy(e => e.Value).Select(s => $"{itemsSet[s.Key]}")));
            Console.WriteLine(string.Join(",", trie.Search("tor").OrderBy(e => e.Value).Select(s => $"{itemsSet[s.Key]}")));
            Console.WriteLine(string.Join(",", trie.Search("e").OrderBy(e => e.Value).Select(s => $"{itemsSet[s.Key]}")));
            Console.WriteLine(string.Join(",", trie.Search("o").OrderBy(e => e.Value).Select(s => $"{itemsSet[s.Key]}")));
            Console.WriteLine(string.Join(",", trie.Search("hik").OrderBy(e => e.Value).Select(s => $"{itemsSet[s.Key]}")));

            Console.ReadLine();
        }
    }
}
