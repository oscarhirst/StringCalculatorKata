// <copyright file="StringCalculatorTests.cs" company="Corsham Science">
// Copyright (c) Corsham Science. All rights reserved.
// </copyright>

namespace StringCalculatorTests
{
    using System;
    using NUnit.Framework;
    using StringCalculator;

    public class StringCalculatorTests
    {
        private StringCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new StringCalculator();
        }

        [TestCase("    ")]
        [TestCase("blablabla")]
        [TestCase("34343434abcdefgh999")]
        public void Calculate_GivenNonNumericString_ThrowsInvalidOperationException(string input)
        {
            Assert.Throws(typeof(InvalidOperationException), () => { _calculator.Calculate(input); });
        }

        [TestCase("  ,  ")]
        [TestCase("blablaNLbla")]
        [TestCase("34343,434ab,cdefgh,999")]
        public void Calculate_GivenDelimitedNonNumericValues_ThrowsInvalidOperationException(string input)
        {
            Assert.Throws(typeof(InvalidOperationException), () => { _calculator.Calculate(input.Replace("NL", Environment.NewLine)); });
        }

        [Test]
        public void Calculate_GivenNumericValuesDelimitedInconsistently_ThrowsInvalidOperationException()
        {
            Assert.Throws(typeof(InvalidOperationException), () => { _calculator.Calculate($"10{Environment.NewLine}123,1024,900002"); });
        }

        [TestCase("-2")]
        [TestCase("5,-6,200")]
        [TestCase("1000NL-3004NL-256")]
        public void Calculate_GivenANegativeNumber_ThrowsInvalidOperationException(string input)
        {
            Assert.Throws(typeof(InvalidOperationException), () => { _calculator.Calculate(input.Replace("NL", Environment.NewLine)); });
        }

        [Test]
        public void Calculate_GivenEmptyString_Returns0()
        {
            Assert.AreEqual(0, _calculator.Calculate(string.Empty));
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(9)]
        public void Calculate_GivenSingleNumber_ReturnsInput(int input)
        {
            Assert.AreEqual(input, _calculator.Calculate(input.ToString()));
        }

        [TestCase(1, 5)]
        [TestCase(6, 32)]
        [TestCase(920, 223)]
        public void Calculate_GivenTwoCommaSeparatedNumbers_ReturnsSum(int input1, int input2)
        {
            Assert.AreEqual(input1 + input2, _calculator.Calculate($"{input1},{input2}"));
        }

        [TestCase(1, 5)]
        [TestCase(6, 32)]
        [TestCase(920, 223)]
        public void Calculate_GivenTwoNewLineSeparatedNumbers_ReturnsSum(int input1, int input2)
        {
            Assert.AreEqual(input1 + input2, _calculator.Calculate($"{input1}{Environment.NewLine}{input2}"));
        }

        [TestCase(1, 5, 9, true)]
        [TestCase(6, 32, 2)]
        [TestCase(220, 223, 935, true)]
        [TestCase(363, 273, 5)]
        public void Calculate_GivenThreeNewLineOrCommaSeparatedNumbers_ReturnsSum(int input1, int input2, int input3, bool useComma = false)
        {
            var separator = useComma ? "," : Environment.NewLine;
            Assert.AreEqual(input1 + input2 + input3, _calculator.Calculate($"{input1}{separator}{input2}{separator}{input3}"));
        }

        [Test]
        public void Calculate_IgnoresNumbersOver1000()
        {
            var lessThanAK1 = 5;
            var lessThanAK2 = 273;

            Assert.AreEqual(lessThanAK1 + lessThanAK2, _calculator.Calculate($"{lessThanAK1},{lessThanAK2},{4078}"));
            Assert.AreEqual(lessThanAK1 + lessThanAK2, _calculator.Calculate($"{lessThanAK1}{Environment.NewLine}{4078}{Environment.NewLine}{lessThanAK2}"));
        }
    }
}
