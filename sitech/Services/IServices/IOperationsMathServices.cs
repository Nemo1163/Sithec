using sitech.Models;

namespace sitech.Services.IServices
{
    public interface IOperationsMathServices
    {
        OperationsMathModel OperationsMath(string operationType, decimal numberOne, decimal numberTwo);
    }
}
