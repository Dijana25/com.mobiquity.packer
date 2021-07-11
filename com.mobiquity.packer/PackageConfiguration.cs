using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mobiquity.packer
{
    public class PackageConfiguration
    {
        public int Capacity { get; set; }
        public List<Item> Items { get; set; }

        public PackageConfiguration()
        {
        }

        public PackageConfiguration(int capacity, List<Item> items)
        {
            Capacity = capacity;
            Items = items;
        }
    }
}
