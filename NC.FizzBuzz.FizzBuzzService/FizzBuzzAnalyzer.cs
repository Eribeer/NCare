using NC.FizzBuzz.Core.Interfaces;

namespace NC.FizzBuzz.FizzBuzzService
{
    public class FizzBuzzAnalyzer : IFizzBuzzAnalyzer
    {
        private const int DividerFizz = 3;
        private const int DividerBuzz = 5;

        public string GetFizzBuzz(int checkNumber)
        {
            var isFizz = checkNumber % DividerFizz == 0;
            var isBuzz = checkNumber % DividerBuzz == 0;

            if (isFizz && isBuzz)
            {
                return "FizzBuzz";
            }

            if (isFizz)
            {
                return "Fizz";
            }

            if (isBuzz)
            {
                return "Buzz";
            }

            return checkNumber.ToString();
        }
    }
}
