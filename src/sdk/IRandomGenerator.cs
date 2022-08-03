namespace SmartyStreets
{
    public interface IRandomGenerator
    {
        /// <summary>
        /// Returns a random integer that is less than the value passed in.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number returned</param>
        /// <returns>An integer that is greater than or equal to zero and less than maxValue.</returns>
        int Next(int maxValue);
    }
}