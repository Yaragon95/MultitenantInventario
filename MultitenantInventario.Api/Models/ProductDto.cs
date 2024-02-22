namespace EdynamicsLog.Prueba.Api.Models
{
    public class ProductDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string Duration { get; set; } = string.Empty;
    }
}
