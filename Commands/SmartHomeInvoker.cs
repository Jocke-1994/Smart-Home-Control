using System.Collections.Generic;
using System.Linq;

public class SmartHomeInvoker
{
    // Listan som bygger upp vår historik
    private readonly List<ICommand> _commandHistory = new List<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Add(command); // Spara i historiken!
    }

    // VG-kravet: Ångra det senaste vi gjorde
    public void UndoLastCommand()
    {
        if (_commandHistory.Count > 0)
        {
            var lastCommand = _commandHistory.Last();

            Logger.Instance.Log("Ångrar senaste kommandot...");
            lastCommand.Undo();

            _commandHistory.RemoveAt(_commandHistory.Count - 1);
        }
    }
    public void ReplayLastCommands(int count)
    {
        Console.WriteLine($"\n--- Replay av de {count} senaste kommandona ---");

        // Hämtar de sista 'count' kommandona från historiken
        var commandsToReplay = Enumerable.Reverse(_commandHistory).Take(count).Reverse().ToList();

        foreach (var cmd in commandsToReplay)
        {
            cmd.Execute();
        }
    }
}