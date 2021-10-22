using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenjiMomentFactory;

namespace BenjiMomentFactory
{
    public class StaminaPotion : Potion
    {
        public override (Attributes, int) Drink()
        {
            return (Attributes.Dexterity, Tier * 5);
        }
    }
}
