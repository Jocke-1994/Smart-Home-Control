public class SetTemperatureCommand : ICommand
{
    private readonly Thermostat _thermostat;
    private readonly int _newTemperature;
    private int _previousTemperature; // Här sparar vi historiken!

    // Vi tar in specifikt en Thermostat här istället för IDevice, eftersom IDevice inte har SetTemperature()
    public SetTemperatureCommand(Thermostat thermostat, int newTemperature)
    {
        _thermostat = thermostat;
        _newTemperature = newTemperature;
    }

    public void Execute()
    {
        // 1. Spara den nuvarande temperaturen INNAN vi ändrar
        _previousTemperature = _thermostat.Temperature;

        // 2. Sätt den nya temperaturen
        _thermostat.SetTemperature(_newTemperature);
    }

    public void Undo()
    {
        // Återställ till den sparade temperaturen
        Logger.Instance.Log("Återställer temperaturen...");
        _thermostat.SetTemperature(_previousTemperature);
    }
}