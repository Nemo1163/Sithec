using Microsoft.Extensions.DependencyInjection;

namespace sitech.DependecyContainer.Configure
{
    public class DCFactory
    {

        protected static IServiceCollection _container;

        public static void CrateContainer<T>(IServiceCollection services) where T :DCFactory, new()
        {
            _container = services;
            T container = new T();
        }

    }
}
