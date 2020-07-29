using System.ComponentModel;
using NUnit.Framework;

namespace XanthosCodeTest.Tests
{

    [TestFixture]
    public class PolybiusSquareTests
    {
        [TestCase("A", "11")]
        [TestCase("Z", "55")]
        [TestCase("N", "33")]
        public void Correct_Letter_Encoding(string letter, string expected)
        {
            PolybiusSquare square = new PolybiusSquare();
            string result = square.Encrypt(letter);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("Hi", "2324")]
        [TestCase("Xanthos", "53113344233443")]
        public void Encode_Word_Correctly(string word, string expected)
        {
            PolybiusSquare square = new PolybiusSquare();
            string result = square.Encrypt(word);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Decode_Letter_Correctly()
        {
            PolybiusSquare square = new PolybiusSquare();
            string result = square.Decrypt("12");
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        public void Decode_Word_Correctly()
        {
            PolybiusSquare square = new PolybiusSquare();
            string result = square.Decrypt("21422415331443");
            Assert.That(result, Is.EqualTo("FRIENDS"));
        }
    }
}