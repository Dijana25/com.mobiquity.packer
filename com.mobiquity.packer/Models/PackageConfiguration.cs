using System.Collections.Generic;

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
