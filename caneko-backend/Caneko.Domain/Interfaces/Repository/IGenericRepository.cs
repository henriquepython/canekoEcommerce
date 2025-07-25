﻿using Caneko.Domain.Entities;

namespace Caneko.Domain.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindOne(string id);
        Task<Product> Create(T entity);
        Task<T> Update(string id, T entity);
        Task Delete(string id);
    }
}
