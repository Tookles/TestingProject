using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    internal class WordAnalyser
    {
        public List<string> FindLongestWords(string text)
        {
            List<string> splitStrings = text.Split(" ").ToList();
            Dictionary<int, List<string>> wordLength = new Dictionary<int, List<string>>();
            int largestWord = 0;
            foreach (string word in splitStrings)
            {
                char[] charWord = word.ToCharArray();
                String newString = new string(charWord.Where(c => !char.IsPunctuation(c)).ToArray());
                if (newString.Length >= largestWord)
                {
                    largestWord = newString.Length;
                    if (wordLength.ContainsKey(newString.Length))
                    {
                        wordLength[newString.Length].Add(newString);
                    }
                    else
                    {
                        wordLength.Add(newString.Length, new List<string>() { newString });
                    }
                }
            }
            return wordLength[largestWord];
        }

        public Dictionary<char, int> CalculateLetterFrequency(string text)
        {
            char[] charArray = text.ToLower().ToCharArray();
            Dictionary<char, int> returnDict = new Dictionary<char, int>();
            foreach (char c in charArray)
            {
                int unicodeVal = (int)c; 
                if ((unicodeVal > 97) && (unicodeVal < 123)) {
                    if (returnDict.ContainsKey(c))
                    {
                        returnDict[c] += 1;
                    } else
                    {
                        returnDict.Add(c, 1);
                    }
                }
            }
            return returnDict; 
        }
    }
}
