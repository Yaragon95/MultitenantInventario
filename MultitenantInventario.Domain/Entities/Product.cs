namespace MultitenantInventario.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string Duration { get; set; } = string.Empty;
        public string SlugTenant { get; set; } = string.Empty;
    }
}
