using System.Collections.Generic;
using System.Linq;

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
            // If your name (or the name you *use*) has two letters, you'll fail this.
            // I don't make the rules.
            // Bad luck, Ed Sheeran. 
            // https://www.kalzumeus.com/2010/06/17/falsehoods-programmers-believe-about-names/
            if (name.Length == 1 || name.Length == 2) 
            {
                if (!name.EndsWith(".")) return false;
            }
            else
            {
                if (name.EndsWith(".")) return false;
            }

            return true;
        }

        public bool CheckNamesAreNotSuffixedWithAPeriod(string name)
        {
            SplitNameIntoElements(name);

            string firstName;
            string middleName;
            firstName = Elements.First();
            if (!CheckNameElementForLengthAndPeriodSuffix(firstName)) return false;

            middleName = Elements.Skip(1).Take(1).First();

            if (!CheckNameElementForLengthAndPeriodSuffix(middleName)) return false;
                
            return true;
        }

        public bool CheckNamesAreExpandedCorrectly(string name)
        {
            SplitNameIntoElements(name);

            if (Elements.Count() == 3)
            {
                string firstName;
                string middleName;
                firstName = Elements.First();
                middleName = Elements.Skip(1).Take(1).First();
                if (firstName.Length == 2 && middleName.Length != 2) return false;
            }

            return true;
        }

        public bool CheckNameIsValid(string name)
        {
            return CheckNumberOfElementsInName(name) && CheckLastNameHasMultipleCharacters(name) &&
                   CheckInitialsAreSuffixedWithAPeriod(name) && CheckAllLeadingCharactersAreCapitalised(name) &&
                   CheckNamesAreNotSuffixedWithAPeriod(name) && CheckNamesAreExpandedCorrectly(name);
        }
    }
}
