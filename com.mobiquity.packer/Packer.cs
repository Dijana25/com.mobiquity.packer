using com.mobiquity.packer.Algorithm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace com.mobiquity.packer
{
    public class Packer
    {
        private static ILargestCostAlgorithm algorithm = new LargestCostAlgorithmDP();

        /*
         * A method that finds the items with largest costs for a set of cases given in a file
         * Input: a valid absolute file path 
         * Output: a string containing the solutions for each case in separate lines         
         */
        public static string pack(string filePath)
        {
            StringBuilder packedPackages = new StringBuilder();            

            try
            {
                var lines = File.ReadLines(filePath);
                
                foreach (var line in lines)
                {
                    var includedItems = processLine(line);
                    packedPackages.Append(includedItems + Environment.NewLine);                    
                }
            }
            catch(IOException ex)
            {
                packedPackages.Clear();                   
            }

            return packedPackages.ToString();
        }

        /**
         * Input: a single test case line in the format: [capacity] : ([index],[weight],[€cost])
         * Output: a comma-separated list of items indexes, or '-' if no items in the solution    
         */
        public static string processLine(string line)
        {
            List<int> itemsIndexes = new List<int>();

            var configuration = PackageConfigurationParser.ParsePackageConfiguration(line);

            if (configuration == null)
            {
                throw new APIException("No valid configuration", line);
            }

            var selectedItems = algorithm.FindItemsWithLargestTotalCost(configuration.Items, configuration.Capacity);

            if (selectedItems.Count == 0)
            {
                return "-";
            }

            selectedItems = selectedItems.OrderBy(i => i.Index).ToList();
            foreach (var item in selectedItems)
            {
                itemsIndexes.Add(item.Index);
            }
            
            return string.Join(",", itemsIndexes);
        }
    }
}
