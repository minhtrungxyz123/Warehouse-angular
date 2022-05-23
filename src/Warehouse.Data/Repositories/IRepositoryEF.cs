﻿using System.Linq.Expressions;
using Warehouse.Data.Entities.Base;
using Warehouse.Data.UnitOfWork;

namespace Warehouse.Data.Repositories
{
    public partial interface IRepositoryEF<T> where T : BaseEntity
    {
        public IUnitOfWork UnitOfWork { get; }

        IEnumerable<T> GetList(Func<T, bool> filter = null);

        Task<T> GetFirstAsync(string id);

        Task<T> GetFirstAsyncAsNoTracking(string id);

        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> ListAllAsync();

        Task<IEnumerable<T>> ListByListId(IEnumerable<string> ids);

        void Update(T entity);

        void Delete(T entity);

        void BulkInsert(IList<T> listEntity);

        Task BulkInsertAsync(IList<T> listEntity);

        void BulkUpdate(IList<T> listEntity);

        Task BulkUpdateAsync(IList<T> listEntity);

        void BulkDelete(IList<T> listEntity);

        Task BulkInsertOrUpdateAsync(IList<T> listEntity);
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
              Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int records = 0,
              string includeProperties = "");
        public Task<IEnumerable<T>> GetAync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int records = 0,
        string includeProperties = "");
    }
}