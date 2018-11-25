using NC.FizzBuzz.Bootstrap;
using NC.FizzBuzz.Core.Interfaces;
using StructureMap;

namespace NC.FizzBuzz.ConsoleApp.IoC
{
    public class ConsoleAppRegistry : Registry
    {
        public ConsoleAppRegistry()
        {
            IncludeRegistry<BootstrapRegistry>();

            For<IFizzBuzzApp>().Use<FizzBuzzApp>();
        }
    }
}
