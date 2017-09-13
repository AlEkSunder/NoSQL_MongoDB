using System;
using DAL.Concrete;

namespace TestProject.Entity
{
    public class Book : MongoEntity
    {
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The author.
        /// </value>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The caption.
        /// </value>
        public string Caption { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Book"/> is booked.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        ///   <c>true</c> if booked; otherwise, <c>false</c>.
        /// </value>
        public bool IsBooked { get; set; }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The number of pages.
        /// </value>
        public int NumberOfPages { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The year.
        /// </value>
        public int Year { get; set; }
    }
}