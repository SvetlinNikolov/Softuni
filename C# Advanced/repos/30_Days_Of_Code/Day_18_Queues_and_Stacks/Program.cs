using System;
using System.Collections;
using System.Collections.Generic;

namespace Day_18_Queues_and_Stacks
{
    class Solution
    {
        LinkedList<char> queue;

        public Solution()
        {
            queue = new LinkedList<char>();
        }

        public void pushCharacter(char c)
        {
            queue.AddFirst(c);
        }

        public char dequeueCharacter()
        {
            char firstChar = queue.First.Value;
            queue.RemoveFirst();
            return firstChar;
        }

        public char popCharacter()
        {
            char lastChar = queue.Last.Value;
            queue.RemoveLast();
            return lastChar;
        }
        static void Main(string[] args)
        {
            string s = Console.ReadLine();


            Solution obj = new Solution();

            foreach (char c in s)
            {
                obj.pushCharacter(c);
            }

            bool isPalindrome = true;

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (obj.popCharacter() != obj.dequeueCharacter())
                {
                    isPalindrome = false;

                    break;
                }
            }

            if (isPalindrome)
            {
                Console.Write("The word, {0}, is a palindrome.", s);
            }
            else
            {
                Console.Write("The word, {0}, is not a palindrome.", s);
            }
        }
    }
}