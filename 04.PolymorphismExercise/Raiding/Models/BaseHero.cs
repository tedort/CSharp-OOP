﻿namespace Raiding.Models
{
    public abstract class BaseHero
    {
        public BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; protected set; }
        public int Power { get; protected set; }

        public abstract string CastAbility();
    }
}
