using Microsoft.Extensions.DependencyInjection;
using sitech.Data.DB;
using sitech.Data.DB.DBInterface;
using sitech.DependecyContainer.Configure;
using sitech.Services;
using sitech.Services.IServices;

namespace sitech.DependecyContainer
{
    public class DC : DCFactory
    {
        public DC()
        {
            _container.AddScoped<IHumanServices, HumanServices>();
            _container.AddScoped<IOperationsMathServices, OperationsMathServices>();
            _container.AddScoped<IConnectionServices, ConnectionServices>();
        }
    }
}
