namespace PizzaCalories
{
    public static class Utilities
    {
        public const double BaseModifier = 2.0;
        //Dough - Flour Type
        public const double WhiteModifier = 1.5;
        public const double WholegrainModifier = 1.0;
        //Dough - Baking Technique
        public const double CrispyModifier = 0.9;
        public const double ChewyModifier = 1.1;
        public const double HomemadeModifier = 1.0;
        //Dough - Messages
        public const string ExceptionDough = "Invalid type of dough.";
        public const string ExceptionDoughWeight = "Dough weight should be in the range [1..200].";
        //Topping
        public const double MeatModifier = 1.2;
        public const double VeggiesModifier = 0.8;
        public const double CheeseModifier = 1.1;
        public const double SauceModifier = 0.9;
        //Topping - Messages
        public const string ExceptionTopping = "Cannot place {0} on top of your pizza.";
        public const string ExceptionToppingWeight = "{0} weight should be in the range [1..50].";
        //Pizza - Messages
        public const string ExceptionPizzaName = "Pizza name should be between 1 and 15 symbols.";
        public const string ExceptionToppingCount = "Number of toppings should be in range [0..10].";
    }
}
