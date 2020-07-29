using System;
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
    }
}
