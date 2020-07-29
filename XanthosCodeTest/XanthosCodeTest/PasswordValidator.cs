using System;

namespace XanthosCodeTest
{
    public class PasswordValidator
    {
        public bool CheckLength(string password)
        {
            return password.Length > 5 && password.Length < 25;
        }
    }
}
