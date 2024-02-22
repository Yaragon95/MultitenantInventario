namespace MultitenantInventario.Domain.Entities
{
    public class Organization
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<User> Users { get; set; } = [];
    }
}
