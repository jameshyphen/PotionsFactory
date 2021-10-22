﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenjiMomentFactory
{
    public class StrengthPotion : Potion
    {
        public override (Attributes, int) Drink()
        {
            return (Attributes.Strength, Tier * 5);
        }
    }
}
