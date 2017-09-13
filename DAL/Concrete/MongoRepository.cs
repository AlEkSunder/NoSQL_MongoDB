using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface;
using MongoDB.Driver;

namespace DAL.Concrete
{
    /// <summary>
    /// Provides logic for CRUD operations in Mongo database.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    /// <seealso cref="IRepository" />
    public class MongoRepository<T> : IRepository<T> where T : MongoEntity
    {
        /// <summary>
        /// Holds the context.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private readonly IContextMongoDB context;

        /// <summary>
        /// Holds the collection of entities.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private IMongoCollection<T> collection;

        /// <summary>
        /// Gets the collection of entities.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The collection of entities.
        /// </value>
        private IMongoCollection<T> Collection
        {
            get
            {
                if (this.collection == null)
                    this.collection = this.context.Collection<T>();

                return this.collection;
            }
        }

        /// <summary>
        /// Gets the entity with the specified identifier.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="Id">The identifier.</param>
        /// <returns>The entity.</returns>
        public T Get(int Id)
        {
            return this.Collection.Find(x => string.Equals(x.Id, Id)).FirstOrDefault();
        }

        /// <summary>
        /// Gets the entities with specified filter.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="filter">The filter for query.</param>
        /// <returns>The entities which match the filter.</returns>
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            return this.Collection.Find(filter).ToEnumerable();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="entities">The entity.</param>
        private void Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            this.Collection.DeleteOne(filter);
        }

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="entities">The entities.</param>
        public void Delete(params T[] entities)
        {
            if (this.IsNullOrEmpty(entities))
                return;

            foreach(var entity in entities)
                this.Delete(entity);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="entity">The entity.</param>
        private void Insert(T entity)
        {
            this.Collection.InsertOne(entity);
        }

        /// <summary>
        /// Inserts the specified entities.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="entities">The entities.</param>
        public void Insert(params T[] entities)
        {
            if (this.IsNullOrEmpty(entities))
                return;

            foreach(var entity in entities)
                this.Insert(entity);
        }

        /// <summary>
        /// Determines whether the specified entity collection is null or empty.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="entities">The entities.</param>
        /// <returns>
        ///   <c>true</c> if the specified entity collection is null or empty; otherwise, <c>false</c>.
        /// </returns>
        private bool IsNullOrEmpty(params T[] entities)
        {
            if (entities == null || !entities.Any())
                return true;

            return false;
        }

        /// <summary>
        /// Gets the collection of entities.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The collection of entities.
        /// </value>
        public IEnumerable<T> ListOfEntities
        {
            get
            {
                return this.Collection.AsQueryable().ToList();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoRepository"/> class.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="context">The context.</param>
        public MongoRepository(IContextMongoDB context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="entity">The entity.</param>
        private void Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            this.Collection.ReplaceOne(filter, entity);
        }

        /// <summary>
        /// Updates the specified entities.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="entities">The entities.</param>
        public void Update(params T[] entities)
        {
            if (this.IsNullOrEmpty(entities))
                return;

            foreach (var entity in entities)
                this.Update(entity);
        }
    }
}