// <copyright file="StringCalculatorTests.cs" company="Corsham Science">
// Copyright (c) Corsham Science. All rights reserved.
// </copyright>

namespace StringCalculatorTests
{
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

        [Test]
        public void Calculate_GivenEmptyString_Returns0()
        {
            Assert.AreEqual(0, _calculator.Calculate(string.Empty));
        }
    }
}
