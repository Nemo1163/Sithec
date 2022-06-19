namespace sitech.Data
{
    public class OperationsMathData
    {
        private decimal Result;
        private decimal NumberOne;
        private decimal NumberTwo;

        public OperationsMathData(decimal numberOne, decimal numberTwo)
        {
            this.NumberOne = numberOne;
            this.NumberTwo = numberTwo;
        }

        public decimal Plus()
        {
            Result = NumberOne + NumberTwo;

            return Result;
        }

        public decimal Minus()
        {
            Result = NumberOne - NumberTwo;
            return Result;
        }

        public decimal Times()
        {
            Result = NumberOne * NumberTwo;
            return Result;
        }

        public decimal DividedBy()
        {
            Result= NumberOne / NumberTwo;
            return Result;
        }
    }
}
