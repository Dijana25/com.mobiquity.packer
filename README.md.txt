** Package Challenge **

Introduction: You want to send your friend a package with different things. 
Each thing you put inside the package has such parameters as index number, weight and cost. The 
package has a weight limit. Your goal is to determine which things to put into the package so that the 
total weight is less than or equal to the package limit and the total cost is as large as possible. 

You would prefer to send a package which weighs less in case there is more than one package with the same price. 

Input	sample:
Your API should accept as its only argument a path to a filename. The input file contains several lines. Each line is one test case. 
Each line contains the weight that the package can take (before the colon) and the list of items you need to choose. 
Each item is enclosed in parentheses where the 1st number is a item’s index number, the 2ndis its weight and the 3rd is its cost. 
E.g.
81 : (1,53.38,€45) (2,88.62,€98) (3,78.48,€3) (4,72.30,€76) (5,30.18,€9) (6,46.34,€48)
8 : (1,15.3,€34)
75 : (1,85.31,€29) (2,14.55,€74) (3,3.98,€16) (4,26.24,€55) (5,63.69,€52) (6,76.25,€75) (7,60.02,€74) (8,93.18,€35) (9,89.95,€78)
56 : (1,90.72,€13) (2,33.80,€40) (3,43.15,€10) (4,37.97,€16) (5,46.81,€36) (6,48.77,€79) (7,81.80,€45) (8,19.36,€79) (9,6.76,€64)

Output	sample:
For each set of items that you put into a package provide a new row in the output string (items’ index numbers are separated by comma). 
E.g. 
4
-
2,7
8,9

Additional constraints:
1. Max weight that a package can take is ≤ 100
2. There might be up to 15 items you need to choose from
3. Max weight and cost of an item is ≤ 100

*******************************************************************

** Description of the solution: **

The main problem in the challenge is to determine which items to include in a collection
so that the total weight is less than or equal to a given limit and the value(cost) is as large as possible.
Because for each item we have an opportunity to take it or not (the items are not divisible), we can 
use the 0-1 Knapsack problem. 
For this problem there are 2 solutions: recursive way and dynamic programming solution.
Both solutions work with computing sub problems.

1. In the recursive way, the function computes same subproblems again and again (there are redundant subproblems)
and the time complexity of this recursive solution in O(2^n) (where n is the number of items).

2. With dynamic programic approach we also consider solving subproblems, but the re-computation of same subproblems
is avoided by creating a temporary matrix in a bottom-up manner where the results are stored and retrieved.
The temporary matrix has N rows (where N is the number of items) and W columns (where W is the limit weight).
Here the complexity is O(NxW).

That is why I decided to take the second approach in order to avoid repeating computations in general,
so the algorithm will be more suitable for most cases.

