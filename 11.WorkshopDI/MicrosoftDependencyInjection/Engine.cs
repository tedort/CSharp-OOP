using MicrosoftDependencyInjection.Loggers;

namespace MicrosoftDependencyInjection
{
    internal class Engine
    {
        private IRandomGenerator generator;
        private ILogger logger;

        public Engine(IRandomGenerator generator, ILogger logger)
        {
            this.Generator = generator;
            this.logger = logger;
        }

        internal IRandomGenerator Generator { get => generator; set => generator = value; }

        public void Print()
        {
            logger.Log("Printing a random number");
            Console.WriteLine(this.Generator.GetRandom());
        }
    }
}
