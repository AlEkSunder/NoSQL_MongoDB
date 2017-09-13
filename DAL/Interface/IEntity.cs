using System;

namespace DAL.Interface
{
    /// <summary>
    /// Provides interface for database entity.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The identifier.
        /// </value>
        string Id { get; set; }
    }
}
