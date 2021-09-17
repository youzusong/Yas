using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yas.Core.Text.Formatting;

namespace Yas.Core.Test.Text
{
    [TestClass]
    public class FormatStringTextTokenizerTest
    {
        [TestMethod]
        public void TokenizeForValidFormat()
        {
            var tokenizer = new FormatStringTextTokenizer();
            var t1 = tokenizer.Tokenize("a sample {0} value");

        }

        [TestMethod]
        public void TokenizeForInvalidFormat()
        {

        }
    }
}
