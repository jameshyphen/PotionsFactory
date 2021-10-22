using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenjiMomentFactory
{
    public abstract class Potion
    {
        public Potion()
        {
            var rnd = new Random();
            Tier = rnd.Next(1, 6);
        }
        public int Tier { get; set; }
        public string Name { get => GetType().Name.Split("Potion")[0]; }

        public abstract (Attributes, int) Drink();
    }
}
