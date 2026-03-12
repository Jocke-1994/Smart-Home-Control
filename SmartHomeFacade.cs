using System;
using System.Collections.Generic;

public class SmartHomeFacade
{
    private readonly List<IDevice> _devices = new List<IDevice>();
    private readonly SmartHomeInvoker _invoker = new SmartHomeInvoker();

    // Vi skapar våra observers här centralt
    private readonly Dashboard _dashboard = new Dashboard();
    private readonly AuditLog _auditLog = new AuditLog();
    private readonly MobileAppAlert _mobileApp = new MobileAppAlert();

    public void AddDevice(IDevice device)
    {
        _devices.Add(device);

        // Automatiskt koppla ALLA observers till varje ny enhet (VG-krav på smidighet!)
        if (device is ISubject subject)
        {
            subject.Attach(_dashboard);
            subject.Attach(_auditLog);
            subject.Attach(_mobileApp);
        }
        Logger.Instance.Log($"{device.Name} lades till i hubben.");
    }

    public void SetMode(ISmartHomeMode mode)
    {
        // Strategy-mönstret används här
        mode.Activate(_devices);
    }

    public void RunCommand(ICommand command)
    {
        // Command-mönstret används här
        _invoker.ExecuteCommand(command);
    }

    public void Undo() => _invoker.UndoLastCommand();

    // En "rutin" som döljer komplexitet (typiskt Facade-exempel)
    public void MorningRoutine()
    {
        Console.WriteLine("\n--- Startar Morgonrutin ---");
        foreach (var device in _devices)
        {
            if (device is Light light) _invoker.ExecuteCommand(new TurnOnCommand(light));
            if (device is Thermostat thermo) _invoker.ExecuteCommand(new SetTemperatureCommand(thermo, 21));
        }
    }
}