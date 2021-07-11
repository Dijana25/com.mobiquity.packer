﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mobiquity.packer
{
    /*
     * A class which contains a static method that is responsible for parsing a single configuration line
     * and return an PackageConfiguration object 
     */
    public class PackageConfigurationParser
    {
        /*
         * Input: line that contains package capaity and available items
         * Output: PackageConfiguration object
         */
        public static PackageConfiguration ParsePackageConfiguration(string line)
        {
            PackageConfiguration configuration = null;
            string[] packageConfigParts = line.Split(Constants.CONFIG_DELIMITER);

            try
            {
                if (packageConfigParts.Length == 2)
                {
                    int packageCapacity = int.Parse(packageConfigParts[0]);
                    string[] itemsPart = packageConfigParts[1].Split(Constants.EMPTY_SPACE);

                    if (itemsPart.Length > 0)
                    {
                        List<Item> packageItemsList = new List<Item>();

                        foreach (var itemPart in itemsPart)
                        {
                            string[] itemElements = itemPart.Replace(Constants.LEFT_BRACKET, Constants.EMPTY_STRING).Replace(Constants.RIGHT_BRACKET, Constants.EMPTY_STRING).Split(Constants.ITEM_ELEMENTS_DELIMITER);

                            if (itemElements.Length == 3)
                            {
                                packageItemsList.Add(new Item(
                                    int.Parse(itemElements[0]),
                                    double.Parse(itemElements[1]),
                                    double.Parse(itemElements[2].Replace(Constants.EURO_SYMBOL, Constants.EMPTY_STRING))
                                    ));
                            }
                            else
                            {
                                packageItemsList.Clear();
                                break;
                            }
                        }

                        if (packageItemsList.Count > 0)
                            configuration = new PackageConfiguration(packageCapacity, packageItemsList);

                    }
                }
            }
            catch (Exception ex)
            {
                configuration = null;
            }

            return configuration;
        }
    }
}
