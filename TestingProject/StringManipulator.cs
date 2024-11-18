using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    internal class StringManipulator
    {
        public string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public bool IsPalindrome(string input)
        {
            return (ReverseString(input) == input);  
        }
    }
}
