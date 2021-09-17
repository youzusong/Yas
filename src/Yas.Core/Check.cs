using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yas.Core
{
    [DebuggerStepThrough]
    public static class Check
    {
        public static T NotNull<T>(T value, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);

            return value;
        }
    }
}
