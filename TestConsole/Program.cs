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
            itemsSet.Add(1, "Victor");
            itemsSet.Add(2, "Alex");
            itemsSet.Add(3, "Constructor");
            itemsSet.Add(4, "Destructor");

            trie.InsertSet(itemsSet);



            Console.WriteLine(string.Join(',', trie.Search("Alex").Select(s => $"{s}")));
            Console.WriteLine(string.Join(',', trie.Search("Test").Select(s => $"{s}")));
            Console.WriteLine(string.Join(',', trie.Search("Victor").Select(s => $"{s}")));
            Console.WriteLine(string.Join(',', trie.Search("tor").Select(s => $"{s}")));
            Console.WriteLine(string.Join(',', trie.Search("e").Select(s => $"{s}")));
            Console.WriteLine(string.Join(',', trie.Search("o").Select(s => $"{s}")));

            Console.ReadLine();
        }
    }
}
