﻿namespace CommandPattern.Commands
{
    public class PlusCommand : ICommand
    {
        public PlusCommand(decimal value)
        {
            Value = value;
            Operator = '+';
        }

        public decimal Value { get; set; }
        public char Operator { get; set; }

        public decimal Execute(decimal current)
        {
            return current + Value;
        }

        public decimal UnExecute(decimal current)
        {
            return current - Value;
        }
    }
}
