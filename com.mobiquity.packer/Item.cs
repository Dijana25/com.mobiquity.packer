﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mobiquity.packer
{
    public class Item
    {
        public int Index { get; set; }
        public double Weight { get; set; }
        public double Cost { get; set; }

        public Item(int index, double weight, double cost)
        {
            Index = index;
            Weight = weight;
            Cost = cost;
        }
    }
}
