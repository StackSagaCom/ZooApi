
namespace Domain.Entities
{
    public abstract class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }
        public abstract double FoodConsumption { get; }
    }
}
