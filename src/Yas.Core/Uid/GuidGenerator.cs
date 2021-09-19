using System;

namespace Yas.Core.Uid
{
    public class GuidGenerator : IGuidGenerator
    {
        public Guid Create()
        {
            return Guid.NewGuid();
        }
    }
}
