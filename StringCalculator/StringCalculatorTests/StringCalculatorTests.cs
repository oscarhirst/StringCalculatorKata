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
        [TestCase(9020, 223)]
        public void Calculate_GivenTwoCommaSeparatedNumbers_ReturnsSum(int input1, int input2)
        {
            Assert.AreEqual(input1 + input2, _calculator.Calculate($"{input1},{input2}"));
        }

        [TestCase(1, 5)]
        [TestCase(6, 32)]
        [TestCase(9020, 223)]
        public void Calculate_GivenTwoNewLineSeparatedNumbers_ReturnsSum(int input1, int input2)
        {
            Assert.AreEqual(input1 + input2, _calculator.Calculate($"{input1}{Environment.NewLine}{input2}"));
        }
    }
}
