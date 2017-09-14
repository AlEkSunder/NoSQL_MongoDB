using System;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using DAL.Interface;

namespace DAL.Concrete
{
    /// <summary>
    /// Provides base logic for database entity.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    [DataContract]
    [Serializable]
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class MongoEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
