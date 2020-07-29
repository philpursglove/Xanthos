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
    }
}
