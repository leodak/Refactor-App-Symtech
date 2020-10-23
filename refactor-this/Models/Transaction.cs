using System;

namespace refactor_this.Models
{
    /// <summary>
    /// Transaction Class Model
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Transaction Amount
        /// </summary>
        public float Amount { get; set; }

        /// <summary>
        /// Transaction Date
        /// </summary>
        public DateTime Date { get; set; }
    }
}