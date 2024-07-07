using Domain.Entities;

namespace ZooApi.Repository
{
    public interface IZooRepository
    {
        Zoo GetZoo();
        void AddFood(double amount);
        void FeedAnimals();
    }

    public class Zoo
    {
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public double FoodSupply { get; set; }
    }
}
