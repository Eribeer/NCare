using NC.FizzBuzz.Core.Interfaces;
using NC.FizzBuzz.Core.Logger;
using NC.FizzBuzz.FizzBuzzService;
using StructureMap;

namespace NC.FizzBuzz.Bootstrap
{
    public class BootstrapRegistry : Registry
    {
        public BootstrapRegistry()
        {
            For<IAppLogger>().Use<Log4NetWrapper>();
            
            For<IFizzBuzzAnalyzer>().Use<FizzBuzzAnalyzer>();
        }
    }
}
