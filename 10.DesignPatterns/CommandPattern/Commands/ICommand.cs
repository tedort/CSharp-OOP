namespace CommandPattern.Commands
{
    public interface ICommand
    {
        public decimal Execute(decimal current);

        public decimal UnExecute(decimal current);

        public decimal Value { get; set; }

        public char Operator { get; set; }
    }
}
