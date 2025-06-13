using Caneko.Domain.Entities;

namespace Caneko.Domain.Interfaces.Repository
{
    public interface IStockRepository : IGenericRepository<Stock>
    {
        Task<List<Stock>> FindByIds(List<string> ids);
    }
}
