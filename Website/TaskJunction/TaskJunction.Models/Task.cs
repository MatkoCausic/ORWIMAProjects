using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskJunction.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public Guid? WorkerId { get; set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; set; }

        public Worker Worker { get; set; } = new();

        public Task()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
    }
}
