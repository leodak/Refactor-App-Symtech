using System;

namespace refactor_this.Models
{
    /// <summary>
    /// Account Class
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Is New Record
        /// </summary>
        private bool isNew;

        /// <summary>
        /// Account Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Account Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Account Number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Account holder amount
        /// </summary>
        public float Amount { get; set; }

        /// <summary>
        /// Account Constructor
        /// </summary>
        public Account()
        {
            isNew = true;
        }

        /// <summary>
        /// Account Constructor
        /// </summary>
        /// <param name="id">Account Id</param>
        public Account(Guid id)
        {
            isNew = false;
            Id = id;
        }
    }
}