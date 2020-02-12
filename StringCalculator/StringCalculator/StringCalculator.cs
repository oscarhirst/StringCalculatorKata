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
            if (int.TryParse(input, out var number))
            {
                return number;
            }

            // req 3
            var inputs = input.Split(',');

            // var numbers = input.Split(',').Select(n =>
            // {
            //    if (!int.TryParse(n, out var number))
            //    {
            //        throw new InvalidOperationException();
            //    }
            //    return number;
            // });
            if (!int.TryParse(inputs[0], out var number1) || !int.TryParse(inputs[1], out var number2))
            {
                throw new InvalidOperationException();
            }

            return number1 * number2;
        }
    }
}
