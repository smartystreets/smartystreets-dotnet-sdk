namespace SmartyStreets
{
    public class FakeRandomNumberGenerator : IRandomGenerator
    {
        private int nextNumber=1;

        public int Next(int maxValue)
        {
            return nextNumber;
        }

        public void SetNextRandomNumber(int nextNum)
        {
            nextNumber = nextNum;
        }
    }
}