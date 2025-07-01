using System;
using Caneko.Domain.ViewModels.Recommend;

namespace Caneko.Domain.Interfaces.Service;

public interface IRecommendService
{
    Task<IEnumerable<RecommendViewModel>> GetAll();
    Task<RecommendOutputFilterPaginationViewModel> Filter(RecommendInputFilterViewModel filter);
    Task<RecommendViewModel> FindOne(string id);
    Task<RecommendViewModel> Create(RecommendCreateViewModel entity);
    Task<RecommendViewModel> Update(string id, RecommendUpdateViewModel entity);
    Task Delete(string id);
    Task Disable(string id, bool isDisable);
}
