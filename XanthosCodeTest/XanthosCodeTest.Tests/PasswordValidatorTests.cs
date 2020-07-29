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
        [TestCase("abcde", false)]
        // All upper
        [TestCase("ABCDE", true)]
        // One upper
        [TestCase("Abcde", true)]
        public void Password_Must_Contain_At_Least_One_Lowercase_Letter(string password, bool expected)
        {
            PasswordValidator checker = new PasswordValidator();
            bool result = checker.CheckForLowerCase(password);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}