using System;

namespace LeetCodeAlg
{
    class Program
    {
        static Solution solution = new Solution();
        static void Main(string[] args)
        {
            test_longest_palindrome();
        }

        static void testGetDecimalValue()
        {

        }

        static void test_longest_palindrome()
        {
            Console.WriteLine(solution.LongestPalindrome("grtsrtbertevrawetrerte4tbertredtretqeertaertret"));
        }
    }
}
