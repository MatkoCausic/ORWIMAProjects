﻿namespace TaskJunction.WebAPI.RestModels
{
    public class PostWorker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
