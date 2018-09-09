using Company.Infra.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Company.Infra.Repository
{
    /// <summary>
    /// Use this only if you know what you are doing.
    /// If you don't, please use IRepository<TEntity> instead
    /// </summary>
    public interface IRepository { }

    public interface IRepository<TEntity> : IRepository where TEntity : IEntity
    {
        /// <summary>
        /// Adds a new item in the database
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entidade);

        /// <summary>
        /// Adds a list of items in the database
        /// </summary>
        /// <param name="entities"></param>
        void AddBulk(IEnumerable<TEntity> entidades);

        /// <summary>
        /// Removes an entity from the database
        /// </summary>
        /// <param name="key"></param>
        void Remove(TEntity entidade);

        /// <summary>
        /// Removes a list of items from the database
        /// </summary>
        /// <param name="keys"></param>
        void RemoveBulk(IEnumerable<TEntity> entidades);

        /// <summary>
        /// Find an item based on the primary key
        /// </summary>
        /// <param name="valoresChave"></param>
        /// <returns></returns>
        TEntity Find(params object[] valoresChave);

        /// <summary>
        /// Search for a list of items based on a predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
    }
}
