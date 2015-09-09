using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Leetcode: add binary */
            string result = addBinary("11", "1"); 
        }
        /*
            Author:     Julia chen
            Date:       July 3, 2015 
            Update:     
            Problem:    Add Binary
            Difficulty: Easy
            Source:     http://leetcode.com/onlinejudge#question_67
            Source 2: https://github.com/leetcoders/LeetCode/blob/master/AddBinary.h
            Notes:
            Given two binary strings, return their sum (also a binary string).
            For example,
             a = "11"
             b = "1"
             Return "100".
             Solution: '1'-'0' = 1.
             Julia comment: 
         *   copy C++ code from the github:
         *   https://github.com/leetcoders/LeetCode/blob/master/AddBinary.h
         *   Annie Kim - facebook, london, UK
         *   and then, convert it to C# code; learn C#,
         *   Learn or review 3 things:
         *   1. StringBuilder vs string, readonly for string  (Line 47)
         *   2. convert int to char in C#, using conversion explicityly, (char)
         *   3. StringBuilder.Insert function, first time use 
         *   4. create a string, and then, construct StringBuilder from it. 
         * 
         * */
        public static string addBinary(string a, string b) {
            int N = a.Length, M = b.Length, K = Math.Max(N, M);

            string kChars = new string(' ', K); 
            StringBuilder res = new StringBuilder(kChars); // julia comment: cannot using string, readonly, and then, use StringBuilder        

            int carry = 0;
            int i = N-1, j = M-1, k = K-1;

            while (i >= 0 || j >= 0)
            {
                int sum = carry;
                if (i >= 0) sum += a[i--] - '0';
                if (j >= 0) sum += b[j--] - '0';
                carry = sum / 2;
                res[k--] = (char)(sum % 2 + '0');  // julia comment C#: cannot convert implicitly, so add (char)(...)
            }

            if (carry == 1)
                res.Insert(0, '1');  // julia comment C#: first time, use insert function, 

            string s = res.ToString(); // julia comment: C#, convert StringBuilder to String before return

            return s;
       }
    }
}
