using com.mobiquity.packer.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.mobiquity.packer
{
    /*
     * A class that contains a static method which uses dynamic programming
     * to solve the 0-1 Knapsack problem
     */
    public class LargestCostAlgorithmDP : ILargestCostAlgorithm
    {
        public List<Item> FindItemsWithLargestTotalCost(List<Item> items, int packageWeight)
        {                        
            /*
             * if exists at least one decimal weight in the items, multiply all weights and the capacity by 100
             *considering there won't be items with weights with more than 2 decimals regarding the examples
             */
            if (ExistItemsWithDecimalWeight(items))
            {
                packageWeight = packageWeight * 100;
                items.ForEach(i => i.Weight = i.Weight * 100);
            }

            /*
             * Items should be sorted first ascending, in order to satisfy the condition:
             * If there are more items with the same price, the one which weights less should be taken
             */
            items = items.OrderBy(i => i.Weight).ToList();

            /*
             * Build matrix subsetResult[][] using dynamic programming in bottom up manner
             */
            int index, weight, result;
            int[,] subsetResult = new int[items.Count + 1, packageWeight + 1];

            for (index = 0; index <= items.Count; index++)
            {
                for (weight = 0; weight <= packageWeight; weight++)
                {
                    if (index == 0 || weight == 0)
                    {
                        subsetResult[index, weight] = 0;
                    }
                    else if (items[index - 1].Weight <= weight)
                    {
                        int IncludedItemWeight = (int)(items[index - 1].Cost + subsetResult[index - 1, weight - ((int)items[index - 1].Weight)]);
                        subsetResult[index, weight] = Math.Max(IncludedItemWeight, subsetResult[index - 1, weight]);
                    }
                    else
                    {
                        subsetResult[index, weight] = subsetResult[index - 1, weight];
                    }
                }
            }

            /* 
             * The maximum sum of items is the value in the lower right corner of the matrix
             */ 
            result = subsetResult[items.Count, packageWeight];

            /*
             * Iterating the matrix in the reverse order, to find the items that were included in the max sum  
             */ 
            weight = packageWeight;
            List<Item> selectedItems = new List<Item>();
            
            for (index = items.Count; index > 0 && result > 0; index--)
            {
                if (result == subsetResult[index - 1, weight])
                {
                    continue;
                }
                else
                {
                    /*
                     * The i-th item was included
                     */
                    selectedItems.Add(items[index - 1]);

                    /* 
                     * Since this weight is included its value is deducted
                     */
                    result = (int)(result - items[index - 1].Cost);
                    weight = (int)(weight - items[index - 1].Weight);
                }
            }
            
            return selectedItems;            
        }

        private bool ExistItemsWithDecimalWeight(List<Item> items)
        {
            foreach (var item in items)
            {
                if (item.Weight != Math.Floor(item.Weight))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
