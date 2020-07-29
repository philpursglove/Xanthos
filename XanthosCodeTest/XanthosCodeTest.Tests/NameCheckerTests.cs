﻿using NUnit.Framework;

namespace XanthosCodeTest.Tests
{
    [TestFixture]
    public class NameCheckerTests
    {
        private NameChecker checker;

        [SetUp]
        public void Setup()
        {
            checker = new NameChecker();
        }

        [TestCase("Jules Gabriel Verne", true)]
        [TestCase("J G Verne", true)]
        [TestCase("Jules Verne", true)]
        [TestCase("Jules", false)]
        [TestCase("M. Jules Gabriel Verne", false)]
        public void Name_Must_Contain_Two_Or_Three_Elements(string name, bool expected)
        {
            bool result = checker.CheckNumberOfElementsInName(name);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("Jules Gabriel Verne", true)]
        [TestCase("J. G. V.", false)]
        [TestCase("Jules Verne", true)]
        [TestCase("Jules V", false)]
        public void Last_Name_Must_Not_Be_An_Initial(string name, bool expected)
        {
            bool result = checker.CheckLastNameHasMultipleCharacters(name);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("J. G. Verne", true)]
        [TestCase("j. G. Verne", false)]
        [TestCase("J. g. Verne", false)]
        [TestCase("J. G. verne", false)]
        public void All_Leading_Letters_Must_Be_Capitalised(string name, bool expected)
        {
            bool result = checker.CheckAllLeadingCharactersAreCapitalised(name);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("J G Verne", false)]
        [TestCase("J. G. Verne", true)]
        public void Initials_Must_Be_Suffixed_With_A_Period(string name, bool expected)
        {
            bool result = checker.CheckInitialsAreSuffixedWithAPeriod(name);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("Jules Gabriel Verne", true)]
        [TestCase("Jules. Gabriel. Verne", false)]
        public void Names_Must_Not_Be_Suffixed_With_A_Period(string name, bool expected)
        {
            bool result = checker.CheckNamesAreNotSuffixedWithAPeriod(name);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("Jules Gabriel Verne", true)]
        [TestCase("J. Gabriel Verne", false)]
        [TestCase("Jules G. Verne", true)]
        public void Names_Must_Be_Expanded_Correctly(string name, bool expected)
        {
            bool result = checker.CheckNamesAreExpandedCorrectly(name);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("H. Wells", true)]
        [TestCase("H. G. Wells", true)]
        [TestCase("Herbert G. Wells", true)]
        [TestCase("Herbert George Wells", true)]
        [TestCase("Herbert", false)]
        [TestCase("Wells", false)]
        [TestCase("H Wells", false)]
        [TestCase("H. G Wells", false)]
        [TestCase("h. Wells", false)]
        [TestCase("H. wells", false)]
        [TestCase("h. g. Wells", false)]
        [TestCase("H. George Wells", false)]
        [TestCase("H. G. W.", false)]
        [TestCase("Herb. G. Wells", false)]
        public void Name_Is_Valid(string name, bool expected)
        {
            bool result = checker.CheckNameIsValid(name);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
