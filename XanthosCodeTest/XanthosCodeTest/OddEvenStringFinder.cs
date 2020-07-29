using System;
using System.Collections.Generic;
using System.Linq;

namespace XanthosCodeTest
{
    public class OddEvenStringFinder
    {
        public List<string> FindOddAndEvenStrings(string input)
        {
            List<string> oddEvenStrings = new List<string>();

            string oddEvenString;
            int lastNumber;

            // Prime the pump
            oddEvenString = input.Substring(0, 1);
            lastNumber = int.Parse(oddEvenString);

            for (int i = 1; i < input.Length; i++)
            {
                int number = int.Parse(input.Substring(i, 1));

                if (number.IsEven())
                {
                    // Both even - break the chain
                    if (lastNumber.IsEven())
                    {
                        if (oddEvenString.Length > 2)
                        {
                            oddEvenStrings.Add(oddEvenString);
                        }
                        oddEvenString = number.ToString();
                    }
                    else
                    {
                        oddEvenString += number.ToString();
                        if (oddEvenString.Length > 2)
                        {
                            oddEvenStrings.Add(oddEvenString);
                        }
                    }
                }
                else
                {
                    // Both odd - break the chain
                    if (lastNumber.IsOdd())
                    {
                        if (oddEvenString.Length > 2)
                        {
                            oddEvenStrings.Add(oddEvenString);
                        }
                        oddEvenString = number.ToString();
                    }
                    else
                    {
                        oddEvenString += number.ToString();
                        if (oddEvenString.Length > 2)
                        {
                            oddEvenStrings.Add(oddEvenString);
                        }
                    }
                }

                lastNumber = number;
            }

            return oddEvenStrings.Distinct().ToList();
        }

        public string FindLongestOddAndEvenString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            CheckInputFormat(input);

            return FindOddAndEvenStrings(input).OrderByDescending(s => s.Length).First();
        }

        private void CheckInputFormat(string input)
        {
            if (!input.All(char.IsNumber))
            {
                throw new FormatException("String contains non-numeric data");
            }
        }
    }
}
