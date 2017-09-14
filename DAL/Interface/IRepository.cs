using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interface
{
    /// <summary>
    /// Provides interface for CRUD operations.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    public interface IRepository<T> where T : IEntity
    {
        /// <summary>
        /// Gets the entity with the specified identifier.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="Id">The identifier.</param>
        /// <returns>The entity.</returns>
        T Get(int Id);

        /// <summary>
        /// Gets the entities with specified filter.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="filter">The filter for query.</param>
        /// <returns>The entities which match the filter.</returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="entities">The entities.</param>
        void Delete(params T[] entities);

        /// <summary>
        /// Inserts the specified entities.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="entities">The entities.</param>
        void Insert(params T[] entities);

        /// <summary>
        /// Gets the collection of entities.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The collection of entities.
        /// </value>
        IEnumerable<T> ListOfEntities { get; }

        /// <summary>
        /// Updates the specified entities.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="entities">The entities.</param>
        void Update(params T[] entities);
    }
}