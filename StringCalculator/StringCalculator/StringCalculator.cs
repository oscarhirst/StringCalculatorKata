// <copyright file="StringCalculator.cs" company="Corsham Science">
// Copyright (c) Corsham Science. All rights reserved.
// </copyright>
// based on exercise http://www.peterprovost.org/blog/2012/05/02/kata-the-only-way-to-learn-tdd/

using System.Net.Cache;

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
            if (int.TryParse(input, out var singleNumber))
            {
                return CheckIsNegative(singleNumber);
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
                            return CheckIsNegative(number);
                        }

                        throw new InvalidOperationException();
                    }).Sum();
            }

            throw new InvalidOperationException();
        }

        // req 6
        private int CheckIsNegative(int number) => number < 0 ? throw new InvalidOperationException() : number;
    }
}
