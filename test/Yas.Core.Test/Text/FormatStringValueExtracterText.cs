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
    public class FormatStringValueExtracterText
    {
        [TestMethod]
        public void Extracte()
        {
            var r1 = FormatStringValueExtracter.Extract("test.domain.com", "{0}.domain.com");
            var r2 = FormatStringValueExtracter.Extract("My Name Is You, Age 32", "My Name Is {0}, Age {1}");
            var r3 = FormatStringValueExtracter.Extract("My Name Is You, Age 32", "My Name Is {name}, Age {age}");
        }
    }
}
