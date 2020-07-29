using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace XanthosCodeTest.Tests
{
    [TestFixture]
    public class OddsAndEvensTests
    {
        [Test]
        public void Find_Odd_And_Even_Strings_For_Beginners()
        {
            OddEvenStringFinder finder = new OddEvenStringFinder();

            List<string> expected = new List<string> {"941"};

            List<string> result = finder.FindOddAndEvenStrings("5941");

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Find_Odd_And_Even_Strings_For_Intermediates()
        {
            OddEvenStringFinder finder = new OddEvenStringFinder();

            List<string> expected = new List<string> {"941","345", "3456"};

            List<string> result = finder.FindOddAndEvenStrings("59413456");

            Assert.That(result, Is.EqualTo(expected));
        }

        
        [TestCase("594127169973391692147228678476","16921472")]
        [TestCase("498275991861592742273244667214", "67214")]
        public void Find_Longest_Odd_Even_String(string source, string expected)
        {
            OddEvenStringFinder finder = new OddEvenStringFinder();

            string result = finder.FindLongestOddAndEvenString(source);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_Input_Is_Not_Numeric_Throw_Exception()
        {
            OddEvenStringFinder finder = new OddEvenStringFinder();

            Assert.That(() => { finder.FindLongestOddAndEvenString("123456789A"); }, Throws.TypeOf<FormatException>().With.Message.EqualTo("String contains non-numeric data"));
        }

        [Test]
        public void When_Input_Is_Empty_Return_Empty_String()
        {
            OddEvenStringFinder finder = new OddEvenStringFinder();

            string result = finder.FindLongestOddAndEvenString("");

            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}
