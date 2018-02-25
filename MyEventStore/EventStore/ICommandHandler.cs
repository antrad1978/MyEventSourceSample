using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStorage
{
    public interface ICommandHandler<T>
    {
        Task HandleCommandAsync(Command<T> command);
    }
}
