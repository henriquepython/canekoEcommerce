using System;
using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Repository;
using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.Mappers;
using Caneko.Domain.ViewModels.Recommend;

namespace Caneko.Domain.Services;

public class RecommendService : IRecommendService
{
    private readonly IRecommendRepository _recommendRepository;

    public RecommendService(IRecommendRepository recommendRepository)
    {
        _recommendRepository = recommendRepository;
    }

    public async Task<RecommendViewModel> Create(RecommendCreateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Product entity cannot be null");
        }

        var entity = model.MapToEntity();
        var result = await _recommendRepository.Create(entity);
        return result.MapToViewModel();
    }

    public async Task Delete(string id) => await _recommendRepository.Delete(id);

    public async Task Disable(string id, bool isDisable) => await _recommendRepository.Disable(id, isDisable);

    public async Task<RecommendOutputFilterPaginationViewModel> Filter(RecommendInputFilterViewModel filter)
    {
        if (filter == null)
        {
            throw new ArgumentNullException(nameof(filter), "Filter cannot be null");
        }

        var result = await _recommendRepository.Filter(filter);

        var models = result.products.Select(x => x.MapToOutputFilterViewModel());

        var data = new RecommendOutputFilterPaginationViewModel
        {
            Items = models,
            Total = (int)result.totalItems,
            PageSize = filter.PageSize,
            PageNumber = filter.PageNumber
        };

        return data;
    }

    public async Task<RecommendViewModel> FindOne(string id)
    {
        var result = await _recommendRepository.FindOne(id);
        return result.MapToViewModel();
    }

    public async Task<IEnumerable<RecommendViewModel>> GetAll() {
       var result = await _recommendRepository.GetAll();
        return result.Select(x => x.MapToViewModel());
    }

    public async Task<RecommendViewModel> Update(string id, RecommendUpdateViewModel model)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentNullException(nameof(id), "Product ID cannot be null or empty");
        }

        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Product entity cannot be null");
        }

        var entity = model.MapToEntity();
        var update = await _recommendRepository.Update(id, entity);
        return update.MapToViewModel();
    }
}
