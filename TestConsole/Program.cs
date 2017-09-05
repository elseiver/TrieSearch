using System;
using System.Linq;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new TrieLib.Trie();

            trie.Insert("Victor", 1);
            trie.Insert("ictor", 1);
            trie.Insert("ctor", 1);
            trie.Insert("tor", 1);
            trie.Insert("or", 1);
            trie.Insert("Alex", 2);
            trie.Insert("lex", 2);
            trie.Insert("ex", 2);
            trie.Insert("x", 2);
            trie.Insert("Constructor", 3);
            trie.Insert("onstructor", 3);
            trie.Insert("nstructor", 3);
            trie.Insert("structor", 3);
            trie.Insert("tructor", 3);
            trie.Insert("ructor", 3);
            trie.Insert("uctor", 3);
            trie.Insert("ctor", 3);
            trie.Insert("tor", 3);



            Console.WriteLine(string.Join(',', trie.Search("Alex").Select(s => $"{s}")));
            Console.WriteLine(string.Join(',', trie.Search("Test").Select(s => $"{s}")));
            Console.WriteLine(string.Join(',', trie.Search("Victor").Select(s => $"{s}")));
            Console.WriteLine(string.Join(',', trie.Search("tor").Select(s => $"{s}")));

            Console.ReadLine();
        }
    }
}
