using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NC.FizzBuzz.Core.Interfaces;
using NUnit.Framework;

namespace NC.FizzBuzz.FizzBuzzService.Tests
{
    [TestFixture]
    public class FizzBuzzAnalyzerUnitTests
    {
        private IFizzBuzzAnalyzer _fizzBuzzAnalyzer;

        [OneTimeSetUp]
        public void Setup()
        {
            _fizzBuzzAnalyzer = new FizzBuzzAnalyzer();
        }

        [TestCase(3)]
        [TestCase(9)]
        [TestCase(12)]
        public void Assert_FizzIsGenerated_Correctly(int fizzNumber)
        {
            var expectedResult = "Fizz";

            var result = _fizzBuzzAnalyzer.GetFizzBuzz(fizzNumber);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public void Assert_BuzzIsGenerated_Correctly(int buzzNumber)
        {
            var expectedResult = "Buzz";

            var result = _fizzBuzzAnalyzer.GetFizzBuzz(buzzNumber);
             
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(15)]
        [TestCase(30)]
        public void Assert_FizzBuzzIsGenerated_Correctly(int fizzBuzzNumber)
        { 
            var expectedResult = "FizzBuzz";

            var result = _fizzBuzzAnalyzer.GetFizzBuzz(fizzBuzzNumber);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void Assert_NumberIsGenerated_Correctly(int fizzBuzzNumber)
        {
            var expectedResult = fizzBuzzNumber.ToString();

            var result = _fizzBuzzAnalyzer.GetFizzBuzz(fizzBuzzNumber);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
