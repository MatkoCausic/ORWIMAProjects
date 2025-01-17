using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskJunction.Models
{
    public class Worker
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string? Address { get; set; }
        public Guid? DepartmentId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public Department? Department { get; set; } = new();

        public List<Task>? Tasks { get; set; } = new();

        public Worker(Guid Id, string FirstName, string LastName, string Email, string Address, Guid? DepartmentId,DateTime DateCreated)
            : this(FirstName, LastName, Email, Address, DepartmentId)
        {
            this.Id = Id;
            this.DateUpdated = DateUpdated;
        }
        public Worker(string FirstName, string LastName, string Email, string Address)
            : this()
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Address = Address;
        }
        public Worker(string FirstName, string LastName, string Email, string Address, Guid? DepartmentId)
            : this(FirstName, LastName, Email, Address)
        {
            this.DepartmentId = DepartmentId;
        }
        public Worker(Guid Id, string FirstName, string LastName, string Email, string Address, Guid? DepartmentId)
            : this(FirstName, LastName, Email, Address, DepartmentId)
        {
            this.Id = Id;
        }
        public Worker()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
    }
}
