using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace com.mobiquity.packer.test
{
    /*
     * Unit tests for Packer class
     */
    [TestFixture]
    public sealed class PackerTests
    {
        private string inputFilePath = @"..\..\..\Resources\example_input";
        private string outputFilePath = @"..\..\..\Resources\example_output";
        private List<string> inputConfigLines;
        private List<string> outputLines;

        /*
         * Read and store both example files from the Resource folder
         */
        [SetUp]
        public void Setup()
        {                        
            inputConfigLines = ReadLinesFromFilePath(inputFilePath);
            outputLines = ReadLinesFromFilePath(outputFilePath);
        }

        [Test]
        public void Test_Check_If_Files_AreRead_Correctly()
        {
            Assert.IsNotNull(inputConfigLines);
            Assert.IsTrue(inputConfigLines.Count > 0);
            Assert.IsNotNull(outputLines);
            Assert.IsTrue(outputLines.Count > 0);
        }

        /*
         * Check if the output string(list of items indexes put in the package) generated from pack method
         * is same as the example provided
         */
        [Test]
        public void Test_Packer_Pack()
        {
            var outputString = Packer.pack(inputFilePath);

            var outputLinesAsString = string.Join("\n", outputLines);            
            Assert.AreEqual(outputString, outputLinesAsString);
        }

        private List<string> ReadLinesFromFilePath(string filePath)
        {
            var lines = File.ReadLines(filePath);          
            return new List<string>(lines);
        }
    }
}