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

            return letters.Select(letter => (new string(letter, 3))).Any(repeatedLetter => password.Contains(repeatedLetter));
        }

        public bool CheckPassword(string password)
        {
            return CheckLength(password) && CheckForUpperCase(password) && CheckForLowerCase(password) &&
                   CheckForNumber(password) && !CheckForRepeatedCharacters(password) && CheckForSpecialCharacters(password);
        }

        public bool CheckForSpecialCharacters(string password)
        {
            string specialCharacters = "!@#$%^&*()+=_-{}[]:;\"'?<>,.";

            return password.Where(character => !char.IsLetterOrDigit(character)).All(character => specialCharacters.Contains(character));
        }
    }
}
