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
            if (int.TryParse(input, out var singleNumber))
            {
                return singleNumber;
            }

            // req 3
            if (input.Contains(","))
            {
                var commaSeparatedNumbers = input.Split(',').Select(n =>
                {
                    if (!int.TryParse(n, out var number))
                    {
                        throw new InvalidOperationException();
                    }

                    return number;
                });

                if (commaSeparatedNumbers?.Any() ?? false)
                {
                    return commaSeparatedNumbers.Sum();
                }
            }

            // req 4
            return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Select(n =>
            {
                if (!int.TryParse(n, out var number))
                {
                    throw new InvalidOperationException();
                }

                return number;
            }).Sum();
        }
    }
}
