namespace MultitenantInventario.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
        public int ManufactureTypeId { get; set; }
        public virtual ManufactureType ManufactureType { get; set; }
        public string SlugTenant { get; set; } = string.Empty;
    }
}
