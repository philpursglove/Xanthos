using NUnit.Framework;

namespace XanthosCodeTest.Tests
{
    public class PasswordValidatorTests
    {
        // Six
        [TestCase("abcdef", true)]
        // Five
        [TestCase("abcde", false)]
        // Twenty Five
        [TestCase("abcdefghijklmnopqrstuwvxy", false)]
        // TwentyFour
        [TestCase("abcdefghijklmnopqrstuwvx", true)]
        public void Password_Must_Be_Between_Six_And_TwentyFour_Characters(string password, bool expected)
        {
            PasswordValidator checker = new PasswordValidator();
            bool result = checker.CheckLength(password);
            Assert.That(result, Is.EqualTo(expected));
        }

        // All lower
        [TestCase("abcde", false)]
        // All upper
        [TestCase("ABCDE", true)]
        // One upper
        [TestCase("Abcde", true)]
        public void Password_Must_Contain_At_Least_One_Uppercase_Letter(string password, bool expected)
        {
            PasswordValidator checker = new PasswordValidator();
            bool result = checker.CheckForUpperCase(password);
            Assert.That(result, Is.EqualTo(expected));
        }

        // All lower
        [TestCase("abcde", true)]
        // All upper
        [TestCase("ABCDE", false)]
        // One lower
        [TestCase("aBCDE", true)]
        public void Password_Must_Contain_At_Least_One_Lowercase_Letter(string password, bool expected)
        {
            PasswordValidator checker = new PasswordValidator();
            bool result = checker.CheckForLowerCase(password);
            Assert.That(result, Is.EqualTo(expected));
        }

        // No numbers
        [TestCase("abcde", false)]
        // One number
        [TestCase("abcde1", true)]
        // All numbers
        [TestCase("123456", true)]
        public void Password_Must_Contain_One_Number(string password,bool expected)
        {
            PasswordValidator checker = new PasswordValidator();
            bool result = checker.CheckForNumber(password);
            Assert.That(result, Is.EqualTo(expected));
        }

        // No strings of three characters
        [TestCase("aabbccddee", false)]
        // One string of three repeated characters
        [TestCase("aaabbccddee", true)]
        [TestCase("aabbccdddee", true)]
        public void Password_Must_Not_Contain_A_Contiguous_String_Of_Three_Or_More_Of_The_Same_Character(string password, bool expected)
        {
            PasswordValidator checker = new PasswordValidator();
            bool result = checker.CheckForRepeatedCharacters(password);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("A1bcdef", true)]
        [TestCase("AAA1bcdef", false)]
        [TestCase("abcdefg", false)]
        [TestCase("ABCDEFG", false)]
        [TestCase("1234567", false)]
        public void Password_Is_Valid(string password, bool expected)
        {
            PasswordValidator checker = new PasswordValidator();
            bool result = checker.CheckPassword(password);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}