using System;
using System.Collections.Generic;
using System.Linq;

namespace Possible_Matches_or_Number_of_Matching_Subsequencess
{
		class Program
		{
        static void Main(string[] args)
        {
            string s = "abcde";
            var words = new string[] { "a", "bb", "acd", "ace" };
            Console.WriteLine(Improved_CountSubsequest(s, words));
        }

        static int Improved_CountSubsequest(string s, string[] words)
        {
            // step 1 - create a Dictionary to track each char and matching words first char from each word
            Dictionary<char, Queue<string>> hash = new Dictionary<char, Queue<string>>();

            foreach (char c in s)
                hash.Add(c, new Queue<string>());

            // step 2 - fill the hash values from word array
            foreach (string word in words)
            {
                char key = word[0]; // first char as key
                if (hash.ContainsKey(key))
                {
                    hash[key].Enqueue(word);
                }
            }

            int count = 0;
            foreach (char c in s)
            {
                Queue<string> values = hash[c];
                int size = values.Count();
                for (int i = 0; i < size; i++)
                {
                    string str = values.Dequeue();
                    if (str.Length == 1) count++;
                    else
                    {
                        char key = str[1];
                        if (hash.ContainsKey(key))
                            hash[key].Enqueue(str.Substring(1));
                    }
                }
            }

            return count;
        }

        #region Brute force
        static int CountSubsequent(string s, string[] words)
        {
            int count = 0;
            foreach (string word in words)
            {
                if (BruteForce_Subsq(s, word)) count++;
            }

            return count++;
        }

        static bool BruteForce_Subsq(string s, string word)
        {
            int i = 0;
            foreach (char c in s)
            {
                if (i < word.Length && c == word[i]) i++;
            }

            return i == word.Length;
        }
        #endregion
    }
}
