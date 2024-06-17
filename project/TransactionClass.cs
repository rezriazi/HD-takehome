using System;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    // Summmary:
    // struct for Transaction, purpose being to convert python or external API to a
    // C# struct to use locally
    public struct Transaction
    {
        public DateTime DateTime;
        public string Description;
        public float Amount;

        public Transaction(DateTime dateTime, string description, float amount)
        {
            DateTime = dateTime;
            Description = description;
            Amount = amount;
        }
    }

    // Summary:
    // Transaction class where functions exist
    public class TransactionClass
    {

    }
}