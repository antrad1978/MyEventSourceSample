using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStorage.Repository
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(Guid id) where T : Event<T>;
        Task SaveAsync<T>(T aggregate) where T : Event<T>;
    }
}
