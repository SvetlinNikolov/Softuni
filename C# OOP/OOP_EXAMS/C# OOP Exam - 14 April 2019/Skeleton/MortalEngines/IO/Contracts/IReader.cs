namespace MortalEngines.IO.Contracts
{
    using MortalEngines.Core.Contracts;
    using System.Collections.Generic;
    using System.Windows.Input;

    public interface IReader
    {
        //delete windows input please
        IList<ICommand> ReadCommands();
    }
}