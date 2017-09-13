using System;
using MongoDB.Driver;
using DAL.Interface;

namespace DAL.Concrete
{
    /// <summary>
    /// Provides interface for database context.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    /// <seealso cref="IContextMongoDB" />
    public class ContextMongoDb : IContextMongoDB
    {
        /// <summary>
        /// Holds the mongo database.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private readonly IMongoDatabase database;

        /// <summary>
        /// Holds the collection of the <see cref="MongoEntity"/>.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <returns>The collection of entities in database.</returns>
        public IMongoCollection<T> Collection<T>()
            where T : MongoEntity
        {
            return this.database.GetCollection<T>(typeof(T).Name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextMongoDb"/> class.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="connectionString">The connection string.</param>
        public ContextMongoDb(string connectionString)
        {
            if(string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            var client = new MongoClient(connectionString);
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;
            this.database = client.GetDatabase(databaseName);
        }
    }
}