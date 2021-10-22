using System;
using System.Collections.Generic;
using System.Linq;
using BenjiMomentFactory.Factories;

namespace BenjiMomentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = 0;
            var inputDrink = 0;
            List<Potion> potionsInventory = new List<Potion>();
            RandomPotionFactory rng = new RandomPotionFactory();
            do
            {
                Console.WriteLine("You're being attacked by a Troglodyte! Choose an action:");
                Console.WriteLine("1) Attack");
                Console.WriteLine("2) Run");
                Console.WriteLine("3) Drink a potion");
                input = Convert.ToInt16(Console.ReadLine());
                if (input == 3)
                {
                    HandlePotionDrink(potionsInventory);
                }
                else
                {
                    Console.WriteLine("You've killed a monster!");
                    var potionDropped = rng.DropPotion();
                    potionsInventory.Add(potionDropped);
                    Console.WriteLine($"It dropped a: [{potionDropped.Name}]");
                }

            } while (input != 2);

        }

        private static void HandlePotionDrink(List<Potion> potionsInventory)
        {
            if (potionsInventory.Count <= 0)
            {
                Console.WriteLine("You have no potions.");
                return;
            }

            var inputDrink = 0;
            Console.WriteLine("Which potion would you like to drink?");

            int i = 0;
            potionsInventory.ForEach(x =>
            {
                Console.WriteLine($"{(i++) + 1}) {x.Name}");
            });

            inputDrink = Convert.ToInt16(Console.ReadLine());

            if (inputDrink != 99)
            {
                var potion = potionsInventory[inputDrink];
                var attributesRestored = potion.Drink();

                potionsInventory.Remove(potion);

                var potionName = attributesRestored.Item1.ToString().ToLower();

                Console.WriteLine($"You drink Tier {potion.Tier} {potionName} potion");
                Console.WriteLine($"You've restored {attributesRestored.Item2} {potionName}.");
            }
        }
    }
}
