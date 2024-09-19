using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Interfaces
{
    public interface IProdutoPublisher
    {
        Task SendMessage<T>(T message);
    };
}
