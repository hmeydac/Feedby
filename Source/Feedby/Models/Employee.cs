namespace Feedby.Models
{
    using System.Collections.Generic;
    using Feedby.Model.Entities;

    public class Employee
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", this.FirstName, this.LastName); }
        }
    }
}