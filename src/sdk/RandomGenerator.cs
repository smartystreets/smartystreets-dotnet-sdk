using System;

namespace SmartyStreets
{
    // Wrap the system random number generator, Random, in an interface so
    // that it can be replaced with a pseudo random generator in the unit tests
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random generator = new Random();

        /// <summary>
        /// Returns a random integer that is less than the value passed in.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number returned</param>
        /// <returns>An integer that is greater than or equal to zero and less than maxValue.</returns>
        public int Next(int maxValue)
        {
            return generator.Next(maxValue);
        }
    }
}