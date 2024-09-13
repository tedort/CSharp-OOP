using System;
using Chainblock.Contracts;
using Chainblock.Models.Enumerations;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private readonly int id;
        private string sender;
        private string receiver;
        private decimal amount;

        public Transaction(int id, string sender, string receiver, decimal amount)
        {
            Id = id;
            Status = TransactionStatus.New;
            Sender = sender;
            Receiver = receiver;
            Amount = amount;
        }

        public decimal Amount 
        {
            get => amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                amount = value;
            }
        }

        public string Receiver 
        { 
            get => receiver;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                receiver = value;
            } 
        }

        public string Sender 
        {
            get => sender;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                sender = value;
            }
        }

        public int Id
        {
            get => id;
            init
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid id");
                }
                id = value;
            }
        }

        public TransactionStatus Status { get; set; }
    }
}
