using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NC.FizzBuzz.ConsoleApp.IoC;
using NC.FizzBuzz.ConsoleApp.Resources;
using NC.FizzBuzz.Core.Interfaces;
using StructureMap;

namespace NC.FizzBuzz.ConsoleApp
{
    class Program
    {
        /// <summary>
        /// Start the main program for FizzBuzz calculation
        /// </summary>
        /// <param name="args">args[0] = start, args[1] = end. Defaults to 1-100 if not set.</param>
        static void Main(string[] args)
        {
            var container = Container.For<ConsoleAppRegistry>();
            
            var app = container.GetInstance<IFizzBuzzApp>();
            var appLogger = container.GetInstance<IAppLogger>();
            var logger = appLogger.GetLogger("ConsoleApp.Program");

            try
            {
                app.Execute(args);
            }
            catch (Exception e)
            {
                logger.Error("Unhandled exception", e);
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }
    }
}
