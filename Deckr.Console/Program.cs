using System;
using Deckr.Console.CommandLine;

namespace Deckr.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setting the encoding makes printing work on Windows & Non-windows envts.
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            var cmdLine = new CmdLine(Deckr.GetDefault(), new ConsoleWrapper());
            CmdLineAction currentAction;
            do
            {
                cmdLine.DisplayOptions();
                currentAction = cmdLine.TakeInstructions();
                cmdLine.ExecuteInstructions(currentAction);
            }
            while (currentAction != CmdLineAction.Quit);
        }
    }
}
