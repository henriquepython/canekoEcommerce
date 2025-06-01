using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caneko.Domain.Interfaces.Service
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindOne(string id);
        Task Create(T entity);
        Task Update(string id, T entity);
        Task Delete(string id);
    }
}
