using Microsoft.Extensions.DependencyInjection;

namespace tests.Infrastructure
{
    public class Container
    {
        private readonly ServiceCollection serviceCollection;

        public Container()
        {
            this.serviceCollection = new ServiceCollection();
        }

        public void Register<T1, T2>()
            where T1 : class
            where T2 : class, T1
        {
            this.serviceCollection.AddTransient<T1, T2>();
        }

        public T Resolve<T>()
        {
            return this.serviceCollection.BuildServiceProvider().GetService<T>();
        }
    }
}
