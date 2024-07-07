using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public abstract double FoodConsumption { get; }
    }
}
