using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace com.mobiquity.packer
{
    public class Packer
    {
        public static string pack(string filePath)
        {
            var lines = File.ReadLines(filePath);
            StringBuilder packedPackages = new StringBuilder();

            foreach (var line in lines)
            {
                var includedItems = processLine(line);
                packedPackages.AppendLine(includedItems);
            }
                
            return packedPackages.ToString();
        }

        public static string processLine(string line)
        {
            //here the line will be processed accordingly
            return line;
        }
    }
}
