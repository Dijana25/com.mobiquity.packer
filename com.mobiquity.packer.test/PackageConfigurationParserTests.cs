using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mobiquity.packer.test
{
    /*
     * Unit tests for PackageConfigurationParser class
     */
    [TestFixture]
    public sealed class PackageConfigurationParserTests
    {
        private string packageConfigLine;            

        [SetUp]
        public void Setup()
        {
            packageConfigLine = "81 : (1,53.38,€45) (2,88.62,€98) (3,78.48,€3) (4,72.30,€76) (5,30.18,€9) (6,46.34,€48)";
        }

        [Test]
        public void Test_Check_In_ConfigurationLine_IsParsed_Correctly()
        {
            int packagaCapacity = 81;
            Item item1 = new Item(1, 53.38, 45);
            Item item2 = new Item(2, 88.62, 98);
            Item item3 = new Item(3, 78.48, 3);
            Item item4 = new Item(4, 72.30, 76);
            Item item5 = new Item(5, 30.18, 9);
            Item item6 = new Item(6, 46.34, 48);

            List<Item> itemsList = new List<Item>() { item1, item2, item3, item4, item5, item6 };
            PackageConfiguration packageConfiguration= new PackageConfiguration(packagaCapacity, itemsList);

            var result = PackageConfigurationParser.ParsePackageConfiguration(packageConfigLine);

            Assert.AreEqual(packageConfiguration.Capacity, result.Capacity);
            Assert.AreEqual(packageConfiguration.Items.Count, result.Items.Count);

            for (int i = 0; i < result.Items.Count; i++)
            {
                Assert.AreEqual(result.Items[i].Index, packageConfiguration.Items[i].Index);
                Assert.AreEqual(result.Items[i].Weight, packageConfiguration.Items[i].Weight);
                Assert.AreEqual(result.Items[i].Cost, packageConfiguration.Items[i].Cost);
            }
        }
    }
}
