using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStorage.PubSub
{
    public interface ICommandExecutor<T>
    {
        void ExecuteAsync(Command<T> command);
    }
}
