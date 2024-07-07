using Domain.Entities;
using Infrastructure.Data;
using ZooApi.Repository;

namespace Infrastructure.Repository
{
    public class InMemoryZooRepository : IZooRepository
    {
        private readonly ZooContext _context;

        public InMemoryZooRepository(ZooContext context)
        {
            _context = context;
        }

        public Zoo GetZoo()
        {
            var foodSupply = _context.FoodSupplies.FirstOrDefault();
            return new Zoo
            {
                Animals = _context.Animals.ToList(),
                FoodSupply = foodSupply?.Amount ?? 0
            };
        }


       public void AddFood(double amount)
        {
            var foodSupply = _context.FoodSupplies.FirstOrDefault();
            if (foodSupply != null)
            {
                foodSupply.Amount += amount;
            }
            else
            {
                _context.FoodSupplies.Add(new FoodSupply { Amount = amount });
            }
            _context.SaveChanges();
        }

        public void FeedAnimals()
        {
            var foodSupply = _context.FoodSupplies.FirstOrDefault();
            if (foodSupply == null) return;

            foreach (var animal in _context.Animals)
            {
                if (foodSupply.Amount >= animal.FoodConsumption)
                {
                    foodSupply.Amount -= animal.FoodConsumption;
                }
            }
            _context.SaveChanges();
        }
    }
}
