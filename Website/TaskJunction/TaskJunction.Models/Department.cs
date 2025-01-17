using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskJunction.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public List<Worker>? Workers { get; set; } = new();


        public Department()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }

        public Department(string Name)
            : this()
        {
            this.Name = Name;
        }
        public Department(Guid Id, string Name)
            : this(Name)
        {
            this.Id = Id;
        }
    }
}
