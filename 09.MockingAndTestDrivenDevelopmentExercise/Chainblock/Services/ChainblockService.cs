using System;
using Chainblock.Contracts;
using System.Collections.Generic;
using Chainblock.Models.Enumerations;

namespace Chainblock.Services
{
    public class ChainblockService : IChainblock
    {
        private Dictionary<int, ITransaction> transactions;

        public ChainblockService()
        {
            transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (transactions.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException();
            }

            transactions.Add(tx.Id, tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction transaction = GetById(id);
            if (transaction == null)
            {
                throw new InvalidOperationException();
            }

            transaction.Status = newStatus;
        }

        public bool Contains(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }

            return transactions.ContainsKey(id);
        }

        public ITransaction GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }

            if (transactions.ContainsKey(id))
            {
                return transactions[id];
            }

            return default;
        }

        public void RemoveTransactionById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            transactions.Remove(id);
        }
    }
}
