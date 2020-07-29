using System;
using System.Collections.Generic;
using System.Linq;

namespace XanthosCodeTest
{
    public class PasswordValidator
    {
        public bool CheckLength(string password)
        {
            return password.Length > 5 && password.Length < 25;
        }

        public bool CheckForUpperCase(string password)
        {
            return password.Any(char.IsUpper);
        }
        public bool CheckForLowerCase(string password)
        {
            return password.Any(char.IsLower);
        }

        public bool CheckForNumber(string password)
        {
            return password.Any(char.IsNumber);
        }

        public bool CheckForRepeatedCharacters(string password)
        {
            IEnumerable<char> letters = password.Distinct();

            foreach (char letter in letters)
            {
                string repeatedLetter = (new string(letter, 3));
                if (password.Contains(repeatedLetter))
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckPassword(string password)
        {
            return CheckLength(password) && CheckForUpperCase(password) && CheckForLowerCase(password) &&
                   CheckForNumber(password) && !CheckForRepeatedCharacters(password);
        }
    }
}
