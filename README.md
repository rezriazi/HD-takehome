# HD-takehome
Take home challenge for Heron Data by Rez Riazi

Design decisions
// for transactions to be valid recurring, there should be at least 3 recurring transactions

Function:
// 1- Group by Transaction.description
// 2- create clusters. same names are grouped together. grab singular ones, compare to rest of groups. clusters should have at least >=3
// 3- each cluster: order transactions by DateTime
// 4- filter clusters that confirm they’re recurring by checking time between each is the same (e.g transactions[0] and transactions[1] have time difference of 7 days, transactions[1] and transactions[2] should be 7 days). NOTE: this should take care of edge case of month transactions (30 vs 31) days.
// 5- Return remaining clusters. These are "recurring transactions"


// Edge cases: 
  // - "bad ones" added to clusters, so DateTime doesn't become recurring
	// february has either 28/29 days
