using System.Collections;
using System.Collections.Generic;
using NFluent;
using NUnit.Framework;

namespace PrimeFactor
{
    public class PrimeFactorShould
    {
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void Return_prime_number_When_input_is_prime_number(int input)
        {
            var primeNumbers = PrimeFactorCalculator.Calculate(input);
            Check.That(primeNumbers).ContainsExactly(input);
        }

        [TestCaseSource("Source")]
        public void Return_prime_numbers_When_input_is_not_a_prime_number(int input, int[] expected)
        {
            var primeNumbers = PrimeFactorCalculator.Calculate(input);
            Check.That(primeNumbers).ContainsExactly(expected);
        }


        private static IEnumerable Source
        {
            get
            {
                yield return new TestCaseData(4, new int[] { 2, 2 });
                yield return new TestCaseData(6, new int[] { 2, 3 });
                yield return new TestCaseData(8, new int[] { 2, 2, 2 });
                yield return new TestCaseData(9, new int[] { 3, 3 });
                yield return new TestCaseData(10, new int[] { 2, 5 });
                yield return new TestCaseData(12, new int[] { 2, 2, 3 });
                yield return new TestCaseData(125, new int[] { 5, 5, 5 });
                yield return new TestCaseData(225, new int[] { 3, 3, 5, 5 });
            }
        }
    }

    public class PrimeFactorCalculator
    {
        public static IEnumerable<int> Calculate(int input)
        {
            var primerNumbers = new List<int>();
            for (int i = 2; i <= input; i++)
            {
                while (input % i == 0)
                {
                    primerNumbers.Add(i);
                    input /= i;
                }
            }

            return primerNumbers;
        }
    }
}
