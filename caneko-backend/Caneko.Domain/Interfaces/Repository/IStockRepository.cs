using Caneko.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caneko.Domain.Interfaces.Repository
{
    public interface IStockRepository : IGenericRepository<Stock>
    {
        Task<IEnumerable<Stock>> FindByIds(IEnumerable<string> ids);
    }
}
