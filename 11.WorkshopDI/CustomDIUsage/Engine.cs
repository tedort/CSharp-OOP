namespace CustomDIUsage
{
    class Engine
    {
        private IRandomGenerator randomGenerator;

        public Engine(IRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public void Something()
        {

        }
    }
}
