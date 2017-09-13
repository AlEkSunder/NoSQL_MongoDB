using System;
using MongoDB.Driver;
using DAL.Concrete;

namespace DAL.Interface
{
    /// <summary>
    /// Provides interface for database context.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    public interface IContextMongoDB
    {
        /// <summary>
        /// Holds the collection of the <see cref="MongoEntity"/>.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <returns>The collection of entities in database.</returns>
        IMongoCollection<T> Collection<T>() where T : MongoEntity;
    }
}
