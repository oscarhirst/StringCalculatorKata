// <copyright file="StringCalculator.cs" company="Corsham Science">
// Copyright (c) Corsham Science. All rights reserved.
// </copyright>
// based on exercise http://www.peterprovost.org/blog/2012/05/02/kata-the-only-way-to-learn-tdd/

namespace StringCalculator
{
    using System;
    using System.Linq;

    public class StringCalculator
    {
        public int Calculate(string input)
        {
            // req 1
            if (input == string.Empty)
            {
                return 0;
            }

            // req2
            if (int.TryParse(input, out var singleNumber) && IsKOrLess(singleNumber))
            {
                return ThrowIfNegative(singleNumber);
            }

            // req 3, 4 & 5
            string separator = null;
            if (input.Contains(","))
            {
                separator = ",";
            }
            else if (input.Contains(Environment.NewLine))
            {
                separator = Environment.NewLine;
            }

            if (separator != null)
            {
                return input.Split(new string[] { separator }, StringSplitOptions.None)
                    .Select(n =>
                    {
                        if (int.TryParse(n, out var number))
                        {
                            return IsKOrLess(number) ? ThrowIfNegative(number) : 0;
                        }

                        throw new InvalidOperationException();
                    }).Sum();
            }

            throw new InvalidOperationException();
        }

        // req 6
        private int ThrowIfNegative(int number) => number < 0 ? throw new InvalidOperationException() : number;

        // req 7
        private bool IsKOrLess(int number) => number <= 1000;
    }
}
