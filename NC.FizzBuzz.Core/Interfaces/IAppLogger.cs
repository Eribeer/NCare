using System;

namespace NC.FizzBuzz.Core.Interfaces
{
    public interface IAppLogger
    {
        IAppLogger GetLogger(string name);
        void Info(string message);
        void Error(string message);
        void Error(string message, Exception exception);
    }
}
