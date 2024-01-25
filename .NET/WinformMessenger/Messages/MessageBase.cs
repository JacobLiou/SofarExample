using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformMessenger.Messages
{
    internal class MessageBase
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
