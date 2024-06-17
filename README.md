# HD-takehome
Take home challenge for Heron Data by Rez Riazi

Design decisions
// for transactions to be valid recurring, there should be at least 3 recurring transactions
// for word similarities I picked > 0.70 float just because it can be leniant enough, but still have to be similar

Function:
// 1- Group by Transaction.description
// 2- create clusters. same names are grouped together. grab singular ones, compare to rest of groups. clusters should have at least >=3
// 3- each cluster: order transactions by DateTime
// 4- filter clusters that confirm they’re recurring by checking time between each is the same (e.g transactions[0] and transactions[1] have time difference of 7 days, transactions[1] and transactions[2] should be 7 days). NOTE: this should take care of edge case of month transactions (30 vs 31) days.
// 5- Return remaining clusters. These are "recurring transactions"


// Edge cases: 
  // - "bad ones" added to clusters, so DateTime doesn't become recurring
	// february has either 28/29 days



Question 4 answers:
How would you measure the accuracy of your approach?  There are a few approaches. One is to make use of a confusion matrix which outlines true positives, false positives, true negatives, and false negatives. This will let us know where the algorithm is making mistakes and how accurate it is. The other approach is to have manual verification where a person would manually identify such transactions vs the algorithm. Finally the end user can report if there are any unexpected results 

How would you know whether solving this problem made a material impact on customers? 
I would measure the impact by how often the service is used. AKA how often is my API called.

How would you deploy your solution?  I would have both an API endpoint for those who want o integrate the work into their software, as well as a simple website where a typical user can upload a json with the specified schema and get back the transactions that are recurring presented to them.

What other approaches would you investigate if you had more time? 
Machine learning is definitely more suitable in solving this problem. Specifically clustering algorithms. And using python packages lol
