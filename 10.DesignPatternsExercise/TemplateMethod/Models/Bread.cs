﻿namespace TemplateMethod.Models
{
    public abstract class Bread
    {
        public abstract void MixIngredients();
        public abstract void Bake();
        public virtual void Slice()
        {
            Console.WriteLine($"Slicing the {GetType().Name} bread");
        }

        // The algorithm skeleton
        // i.e. The template method
        public void Make()
        {
            MixIngredients();
            Bake();
            Slice();
        }
    }
}
