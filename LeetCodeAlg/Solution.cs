using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace LeetCodeAlg
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    class Solution
    {
        public int GetDecimalValue(ListNode head)
        {
            return recursiveDecimal(head, 0);
        }
        private int recursiveDecimal(ListNode head, int current)
        {
            current += head.val;
            if (head.next == null)
            {
                return current;
            }
            else
            {
                return recursiveDecimal(head.next, current * 2);
            }
        }

        public int MaxPower(string s)
        {
            int current = 0;
            int max = 0;
            char c = s[0];
            for (int i = 0; i < s.Length; i++)
            {
                if (c == s[i])
                {
                    current++;
                    if (current > max)
                    {
                        max = current;
                    }
                }
                else
                {
                    current = 1;
                    c = s[i];
                }
            }
            return max;
        }

        public int[] RunningSum(int[] nums)
        {
            int[] result = new int[nums.Length];
            int current = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                current += nums[i];
                result[i] = current;
            }
            return result;
        }

        public int PivotIndex(int[] nums)
        {
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                rightSum += nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (leftSum == rightSum)
                {
                    return i;
                }
                //else -end of array
                if (i == nums.Length-1)
                {
                    return -1;
                }
                //else 
                leftSum += nums[i];
                rightSum -= nums[i + 1];
            }
            return -2;
        }

        public string LongestPalindrome(string s)
        {
            string result = s[0].ToString();
            int longest = 1; // 1 as s.length >= 1
            List<string> currentSubstrings = new List<string>();
            bool skip = false;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < currentSubstrings.Count; j++)
                {
                    currentSubstrings[j] = String.Concat(currentSubstrings[j], s[i]);
                    if (!skip && isPalindrome(currentSubstrings[j]))
                    {
                        if (longest < currentSubstrings[j].Length)
                        {
                            result = currentSubstrings[j];
                            longest = result.Length;
                            skip = true; // don't need to check shorter ones once a longer one matches
                        }
                    }
                    if (!skip && currentSubstrings[j].Length <= longest)
                    {
                        skip = true; // don't need to check if all remainings are shorter
                    }
                }
                //at the end, add the char
                currentSubstrings.Add(s[i].ToString());
                skip = false;
            }
            return result;
        }

        private bool isPalindrome(string s)
        {
            int length = s.Length;
            for (int i = 0; i < length/2; i++)
            {
                if (s[i] != s[length-1-i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> dictionary = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dictionary.ContainsKey(s[i]))
                {
                    if (dictionary[s[i]] != t[i])
                    {
                        return false;
                    }
                }
                else if (dictionary.ContainsValue(t[i]))
                {
                    return false;
                }
                else
                {
                    dictionary.Add(s[i], t[i]);
                }
            }
            return true;
        }

        public bool IsSubsequence(string s, string t)
        {
            int i = 0, j = 0;
            int length = t.Length;
            for (; i < s.Length && j < length; i++,j++)
            {
                while (s[i] != t[j])
                {
                    j++;
                    if (j >= length)
                    {
                        return false;
                    }
                }
            }
            if (i == s.Length)
            {
                return true;
            }
            return false;
        }
    }
}
