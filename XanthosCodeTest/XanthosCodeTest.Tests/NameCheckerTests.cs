using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace XanthosCodeTest.Tests
{
    [TestFixture]
    public class NameCheckerTests
    {
        [TestCase("Jules Gabriel Verne", true)]
        [TestCase("J G Verne", true)]
        [TestCase("Jules Verne", true)]
        [TestCase("Jules", false)]
        [TestCase("M. Jules Gabriel Verne", false)]
        public void Name_Must_Contain_Two_Or_Three_Elements(string name, bool expected)
        {
            NameChecker checker = new NameChecker();
            bool result = checker.CheckNumberOfElementsInName(name);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("Jules Gabriel Verne", true)]
        [TestCase("J. G. V.", false)]
        [TestCase("Jules Verne", true)]
        [TestCase("Jules V", false)]
        public void Last_Name_Must_Not_Be_An_Initial(string name, bool expected)
        {
            NameChecker checker = new NameChecker();
            bool result = checker.CheckLastNameHasMultipleCharacters(name);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("J. G. Verne", true)]
        [TestCase("j. G. Verne", false)]
        [TestCase("J. g. Verne", false)]
        [TestCase("J. G. verne", false)]
        public void All_Leading_Letters_Must_Be_Capitalised(string name, bool expected)
        {
            NameChecker checker = new NameChecker();
            bool result = checker.CheckAllLeadingCharactersAreCapitalised(name);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
