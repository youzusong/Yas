using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yas.Core.Email
{
    public abstract class EmailSenderConfigurationBase : IEmailSenderConfiguration
    {
        public Task<string> GetAddressAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetDisplayNameAsync()
        {
            throw new NotImplementedException();
        }
    }
}
