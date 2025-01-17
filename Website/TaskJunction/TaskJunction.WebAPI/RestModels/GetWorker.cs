namespace TaskJunction.WebAPI.RestModels
{
    public class GetWorker
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public Guid? DepartmentId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
