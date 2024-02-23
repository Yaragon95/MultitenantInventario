using MultitenantInventario.Domain.Entities;

namespace MultitenantInventario.Application.Dtos
{
    public class ProductoDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int StatusId { get; set; }
        public int ManufactureTypeId { get; set; }
    }
}
