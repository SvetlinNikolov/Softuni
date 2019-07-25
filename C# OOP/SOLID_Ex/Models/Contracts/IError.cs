using Logger.Models.Enumerations;

namespace Logger.Models.Contracts
{
    using System;

    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
