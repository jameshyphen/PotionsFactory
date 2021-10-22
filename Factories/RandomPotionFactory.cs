using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenjiMomentFactory.Factories
{
    class RandomPotionFactory : PotionFactory
    {
        private Type[] Potions { get; set; }
        public RandomPotionFactory()
        {
            var type = typeof(Potion);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => type.IsAssignableFrom(type))
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Potion)));
            Potions = types.ToArray();
        }


        public override Potion DropPotion()
        {
            var random = new Random();
            var length = this.Potions.Length;
            var typePotion = Potions[random.Next(0, length - 1)];
            var potionToDrop = (Potion)Activator.CreateInstance(typePotion); ;

            return potionToDrop;
        }
    }
}
