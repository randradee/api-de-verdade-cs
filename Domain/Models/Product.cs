using api_de_verdade.Domain.Models.Enums;

namespace api_de_verdade.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public short QuantityInPackage { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public Product() { }
        public Product(string name, short quantityInPackage, int unitOfMeasurement, int categoryId)
        {
            Name = name;
            QuantityInPackage = quantityInPackage;
            UnitOfMeasurement = Enum.GetValues<EUnitOfMeasurement>()[unitOfMeasurement];
            CategoryId = categoryId;
        }
    }
}
