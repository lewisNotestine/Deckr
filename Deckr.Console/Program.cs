using System;
using Deckr.Console.CommandLine;

namespace Deckr.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmdLine = new CmdLine(Deckr.GetDefault(), new DeckPrinter());
            CmdLineAction currentAction;
            do
            {
                cmdLine.PrintUsage();
                currentAction = cmdLine.TakeInstructions();
                cmdLine.ExecuteInstructions(currentAction);
            }
            while (currentAction != CmdLineAction.Quit);
        }
    }
}
