using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using FuzzyStrings;

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
    public static class TransactionClass
    {
        // could also return as List<Transaction[]>
        public static Dictionary<string, List<Transaction>> IdentifyRecurringTransactions(List<Transaction> transactions)
        {


            // 1- Group by Transaction.description
            Dictionary<string, List<Transaction>> clustersDictionary = new Dictionary<string, List<Transaction>>();
            clustersDictionary = transactions.GroupBy(t => t.Description).ToDictionary();

            // 2- create clusters. same names are grouped together initially.
            foreach (var t in clustersDictionary)
            {
                // grab singular ones, compare to rest of groups. clusters should have at least >=3
                if (t.Value.Count == 1)
                {
                    foreach (var otherCluster in clustersDictionary)
                    {
                        // design decision: word similarity of > 0.70 needed to match words as same transactions
                        if (StringSimilarity(t.Key, otherCluster.Key) > 0.70f)
                        {
                            otherCluster.Value.Add(t.Value[0]);
                            clustersDictionary.Remove(t.Key);
                            break;
                        }
                    }
                }
            }



            // each cluster should have at least 3
            //sortedDictByTime.Filter(t => t.Count > 3);

            // 3- each cluster: order transactions by DateTime
            var sortedDictByTime = from entry in clustersDictionary orderby entry.Value ascending select DateTime;

            // 4- filter clusters that confirm they’re recurring by checking time between each is the same
            // (e.g transactions[0] and transactions[1] have time difference of 7 days, transactions[1] and transactions[2] should be 7 days). NOTE: this should take care of edge case of month transactions (30 vs 31) days.
            foreach (var t in sortedDictByTime)
            {
                int firstTimeDifference = DateTime.Subtract(t.Value[1], t.Value[0]);
                for (int i = 1; i < t.Value.Count; i++)
                {
                    if (DateTime.Subtract(t.Value[i], t.Value[i - 1]) != firstTimeDifference)
                    {
                        sortedDictByTime.Remove(t.Key);
                        break;
                    }
                }
            }
        }
            // 5- Return remaining clusters. These are "recurring transactions"
            return sortedDictByTime;

        }

    // this function gets 2 strings and calculates a "distance" vector which says how similar
    // they are to each other
    private static float StringSimilarity(string str1, string str2)
    {
        // *external library that string matches in C#*
        return 0;
    }

}
}