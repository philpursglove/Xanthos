using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XanthosCodeTest
{
    public class NameChecker
    {
        public IEnumerable<string> Elements { get; set; }

        public bool CheckNumberOfElementsInName(string name)
        {
            SplitNameIntoElements(name);

            return Elements.Count() == 2 || Elements.Count() == 3;
        }

        private IEnumerable<string> SplitNameIntoElements(string name)
        {
            Elements = name.Split(' ');
        }
    }
}
