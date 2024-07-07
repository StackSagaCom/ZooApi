using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Carnivore : Animal
    {
        public override double FoodConsumption => 3.0;
    }
}
