using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace com.mobiquity.packer
{
    public class Packer
    {
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
            catch(APIException ex)
            {
                packedPackages.Clear();                   
            }

            return packedPackages.ToString();
        }

        public static string processLine(string line)
        {
            List<int> itemsIndexes = new List<int>();

            var configuration = PackageConfigurationParser.ParsePackageConfiguration(line);

            if (configuration == null)
            {
                throw new APIException("No correct configuration");
            }

            var selectedItems = LargestCostAlgorithm.FindItemsWithLargestTotalCost(configuration.Items, configuration.Capacity);

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
