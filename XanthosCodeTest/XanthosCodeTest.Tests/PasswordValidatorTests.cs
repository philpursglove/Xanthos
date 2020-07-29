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
    }
}