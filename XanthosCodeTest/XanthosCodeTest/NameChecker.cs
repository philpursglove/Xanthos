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

            return Elements.All(element => !char.IsLower(element.First()));
        }

        public bool CheckInitialsAreSuffixedWithAPeriod(string name)
        {
            SplitNameIntoElements(name);

            string firstName = Elements.First();
            if (!CheckNameElementForLengthAndPeriodSuffix(firstName)) return false;

            string middleName = Elements.Skip(1).Take(1).ToString();

            if (!CheckNameElementForLengthAndPeriodSuffix(middleName)) return false;
                
            return true;
        }

        private bool CheckNameElementForLengthAndPeriodSuffix(string name)
        {
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

            string firstName = Elements.First();
            if (!CheckNameElementForLengthAndPeriodSuffix(firstName)) return false;

            string middleName = Elements.Skip(1).Take(1).First();

            if (!CheckNameElementForLengthAndPeriodSuffix(middleName)) return false;
                
            return true;
        }

        public bool CheckNamesAreExpandedCorrectly(string name)
        {
            SplitNameIntoElements(name);

            if (Elements.Count() == 3)
            {
                string firstName = Elements.First();
                string middleName = Elements.Skip(1).Take(1).First();
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
