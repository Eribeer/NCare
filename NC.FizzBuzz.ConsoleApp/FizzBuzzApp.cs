using System;
using System.Configuration;
using NC.FizzBuzz.ConsoleApp.Resources;
using NC.FizzBuzz.Core.Interfaces;

namespace NC.FizzBuzz.ConsoleApp
{
    internal class FizzBuzzApp : IFizzBuzzApp
    {
        private readonly IFizzBuzzAnalyzer _fizzBuzzAnalyzer;
        private readonly IAppLogger _appLogger;

        public FizzBuzzApp(IFizzBuzzAnalyzer fizzBuzzAnalyzer, IAppLogger appLogger)
        {
            _fizzBuzzAnalyzer = fizzBuzzAnalyzer;
            _appLogger = appLogger.GetLogger(GetType().FullName);
        }

        /// <summary>
        /// Start the main program for FizzBuzz calculation
        /// </summary>
        /// <param name="args">args[0] = start, args[1] = end. Defaults to 1-100 if not set.</param>
        public void Execute(string[] args)
        {
            int fizzBuzzStart;
            int fizzBuzzEnd;

            var gotInputParameters = GetInputParameters(args, out fizzBuzzStart, out fizzBuzzEnd);

            if (!gotInputParameters)
            {
                Console.WriteLine(ConsoleTexts.WelcomeInfo);

                var input = Console.ReadLine() ?? "";
                gotInputParameters = GetInputParameters(input.Split(' '), out fizzBuzzStart, out fizzBuzzEnd);
            }

            if (!gotInputParameters)
            {
                GetDefaultValues(out fizzBuzzStart, out fizzBuzzEnd);
                _appLogger.Info("No user input, proceeding with default values");
            }

            OutputFizzBuzz(fizzBuzzStart, fizzBuzzEnd);
        }

        private void OutputFizzBuzz(int fizzBuzzStart, int endFizzBuzzPos)
        {
            Console.WriteLine(ConsoleTexts.ExecutingFizzBuzz, fizzBuzzStart, endFizzBuzzPos);

            for (var i = fizzBuzzStart; i <= endFizzBuzzPos; i++)
            {
                Console.WriteLine(_fizzBuzzAnalyzer.GetFizzBuzz(i));
            }
        }

        private bool GetInputParameters(string[] args, out int fizzBuzzStart, out int fizzBuzzEnd)
        {
            var inputParseSuccess = false;

            fizzBuzzStart = 0;
            fizzBuzzEnd = 0;

            if (args.Length == 2)
            {
                inputParseSuccess = int.TryParse(args[0], out fizzBuzzStart) 
                    & int.TryParse(args[1], out fizzBuzzEnd);
            }

            return inputParseSuccess;
        }

        private void GetDefaultValues(out int fizzBuzzStart, out int fizzBuzzEnd)
        {
            if (!int.TryParse(ConfigurationManager.AppSettings["Default.StartPos"], out fizzBuzzStart))
            {
                throw new ArgumentException("Missing or misconfigured app settings: Default.StartPos");
            }

            if (!int.TryParse(ConfigurationManager.AppSettings["Default.EndPos"], out fizzBuzzEnd))
            {
                throw new ArgumentException("Missing or misconfigured app settings: Default.EndPos");
            }
        }
    }
}
