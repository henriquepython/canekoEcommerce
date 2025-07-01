using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.Recommend;

namespace Caneko.Domain.Interfaces.Repository;

public interface IRecommendRepository: IGenericRepository<Recommend>
{
    Task<(IEnumerable<Recommend> products, float totalItems)> Filter(RecommendInputFilterViewModel filter);
    Task Disable(string id, bool isDisable);
}
