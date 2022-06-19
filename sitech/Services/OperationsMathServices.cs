using sitech.Data;
using sitech.Models;
using sitech.Services.IServices;

namespace sitech.Services
{
    public class OperationsMathServices : IOperationsMathServices
    {
        public OperationsMathModel OperationsMath(string operationType, decimal numberOne, decimal numberTwo)
        {
            return Operations(operationType, numberOne, numberTwo);
        }

        public OperationsMathModel Operations(string operationType, decimal numberOne, decimal numberTwo)
        {

            decimal result = 0m;



            OperationsMathData operationsMath = new OperationsMathData(numberOne, numberTwo);

            switch (operationType.ToLower())
            {
                case "plus":
                    result = operationsMath.Plus();
                    break;

                case "minus":
                    result = operationsMath.Minus();
                    break;

                case "times":
                    result = operationsMath.Times();
                    break;

                case "dividedBy":
                    result = operationsMath.DividedBy();
                    break;
            };

            return new OperationsMathModel()
            {
                NumberOne = numberOne,
                NumberTwo = numberTwo,
                Result = result
            };
        }
    }
}
