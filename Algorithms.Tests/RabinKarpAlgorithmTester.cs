using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class RabinKarpAlgorithmTester
    {
        [TestMethod]
        public void Can_find_pattern_within_text()
        {
            var text = "abacadabrabracabracadabrabrabracad";
            var pattern = "rab";

            var result = RabinKarpMatcher.Find(text, pattern, 256, 13);

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Can_find_not_pattern_within_text_when_pattern_is_wrong()
        {
            var text = "abacadabrabracabracadabrabrabracad";
            var pattern = "abracadabra";

            var result = RabinKarpMatcher.Find(text, pattern, 256, 13);

            Assert.AreEqual(-1, result);
        }
    }
}
