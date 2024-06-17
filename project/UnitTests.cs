using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


// NOTE: USED CHAT GPT to help make structure of code!! I modified the amounts, etc.

[TestFixture]
public class TransactionAnalyzerTests
{
    [Test]
    public void IdentifyRecurringTransactions_ShouldIdentifyMonthlyRecurringTransactions()
    {
        var transactions = new List<Transaction>
        {
            new Transaction { Description = "Spotify", Amount = -14.99m, Date = new DateTime(2021, 1, 29) },
            new Transaction { Description = "Spotify", Amount = -14.99m, Date = new DateTime(2020, 12, 29) },
            new Transaction { Description = "Spotify", Amount = -14.99m, Date = new DateTime(2020, 11, 29) }
        };

        var result = TransactionClass.IdentifyRecurringTransactions(transactions);

        Assert.AreEqual(1, result.Count);
        Assert.IsTrue(result.Any(group => group.All(t => t.Description == "Spotify")));
    }

    [Test]
    public void IdentifyRecurringTransactions_ShouldNotIdentifyNonRecurringTransactions()
    {
        var transactions = new List<Transaction>
        {
            new Transaction { Description = "Spotify", Amount = -14.99m, Date = new DateTime(2021, 1, 27) },
            new Transaction { Description = "Spotify", Amount = -14.99m, Date = new DateTime(2020, 12, 20) },
            new Transaction { Description = "Spotify", Amount = -14.99m, Date = new DateTime(2020, 11, 29) }
        };

        var result = TransactionClass.IdentifyRecurringTransactions(transactions);

        Assert.AreEqual(0, result.Count);
    }

    [Test]
    public void IdentifyRecurringTransactions_ShouldIdentifyMultipleRecurringTransactions()
    {
        var transactions = new List<Transaction>
        {
            new Transaction { Description = "Spotify", Amount = -14.99m, Date = new DateTime(2021, 1, 29) },
            new Transaction { Description = "Spotify", Amount = -14.99m, Date = new DateTime(2020, 12, 29) },
            new Transaction { Description = "Spotify", Amount = -14.99m, Date = new DateTime(2020, 11, 29) },
            new Transaction { Description = "Netflix", Amount = -9.99m, Date = new DateTime(2021, 1, 15) },
            new Transaction { Description = "Netflix", Amount = -9.99m, Date = new DateTime(2020, 12, 15) },
            new Transaction { Description = "Netflix", Amount = -9.99m, Date = new DateTime(2020, 11, 15) }
        };

        var result = TransactionClass.IdentifyRecurringTransactions(transactions);

        Assert.AreEqual(2, result.Count);
        Assert.IsTrue(result.Any(group => group.All(t => t.Description == "Spotify")));
        Assert.IsTrue(result.Any(group => group.All(t => t.Description == "Netflix")));
    }

    [Test]
    public void IdentifyRecurringTransactions_ShouldReturnEmptyForNoRecurringTransactions()
    {
        var transactions = new List<Transaction>
        {
            new Transaction { Description = "Spotify", Amount = -14.99m, Date = new DateTime(2021, 1, 29) },
            new Transaction { Description = "Netflix", Amount = -9.99m, Date = new DateTime(2020, 12, 15) },
            new Transaction { Description = "Amazon Prime", Amount = -12.99m, Date = new DateTime(2020, 11, 29) }
        };

        var result = TransactionClass.IdentifyRecurringTransactions(transactions);

        Assert.IsEmpty(result);
    }
}