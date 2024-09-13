using System.Reflection.Metadata.Ecma335;

namespace PizzaCalories
{
    public class Dough
    {
        private readonly string flourType;
        private readonly string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            init
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(Utilities.ExceptionDough);
                }
                flourType = value;
            }
        }

        public string BakingTechnique
        {
            init
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(Utilities.ExceptionDough);
                }
                bakingTechnique = value;
            }
        }

        public double Weight
        {
            init
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(Utilities.ExceptionDoughWeight);
                }
                weight = value;
            }
        }

        public double Calories
        {
            get => CalculateCalories();
        }

        private double CalculateCalories()
        {
            double flourTypeModifier = flourType.ToLower() switch
            {
                "white" => Utilities.WhiteModifier,
                "wholegrain" => Utilities.WholegrainModifier
            };

            double bakingModifier = bakingTechnique.ToLower() switch
            {
                "crispy" => Utilities.CrispyModifier,
                "chewy" => Utilities.ChewyModifier,
                "homemade" => Utilities.HomemadeModifier
            };

            return Utilities.BaseModifier * weight * flourTypeModifier * bakingModifier;
        }
    }
}
