using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mobiquity.packer.Algorithm
{
    public interface ILargestCostAlgorithm
    {
        List<Item> FindItemsWithLargestTotalCost(List<Item> items, int packageWeight);
    }
}
