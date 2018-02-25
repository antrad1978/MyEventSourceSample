using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStorage.Repository
{
    public interface ISnapshot<T>
    {
        Snapshot<T> TakeSnapshot();
        void ApplySnapshot(Snapshot<T> snapshot);
    }
}
