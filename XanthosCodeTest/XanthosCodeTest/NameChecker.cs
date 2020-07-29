using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XanthosCodeTest
{
    public class NameChecker
    {
        public IEnumerable<string> Elements { get; set; }

        public bool CheckNumberOfElementsInName(string name)
        {
            SplitNameIntoElements(name);

            return Elements.Count() == 2 || Elements.Count() == 3;
        }

        private void SplitNameIntoElements(string name)
        {
            Elements = name.Split(' ');
        }

        public bool CheckLastNameHasMultipleCharacters(string name)
        {
            SplitNameIntoElements(name);

            string familyname = Elements.Last().Replace(".", "");

            return familyname.Length > 1;
        }

        public bool CheckAllLeadingCharactersAreCapitalised(string name)
        {
            SplitNameIntoElements(name);

            foreach (string element in Elements)
            {
                if (char.IsLower(element.First()))
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckInitialsAreSuffixedWithAPeriod(string name)
        {
            SplitNameIntoElements(name);

            string firstName;
            string middleName;
            firstName = Elements.First();
            if (!CheckNameElementForLengthAndPeriodSuffix(firstName)) return false;

            middleName = Elements.Skip(1).Take(1).ToString();

            if (!CheckNameElementForLengthAndPeriodSuffix(middleName)) return false;
                
            return true;
        }

        private bool CheckNameElementForLengthAndPeriodSuffix(string name)
        {
            if (name.Length == 1 || name.Length == 2 && !name.EndsWith("."))
            {
                return false;
            }

            return true;
        }
    }
}
