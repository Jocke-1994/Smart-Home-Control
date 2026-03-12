using System;
using System.Collections.Generic;

public class NormalMode : ISmartHomeMode
{
    public void Activate(List<IDevice> devices)
    {
        Console.WriteLine("\n*** Aktiverar Normal Mode ***");
        foreach (var device in devices)
        {
            if (device is Light light) light.TurnOn();
            else if (device is Thermostat thermostat) thermostat.SetTemperature(20);
            else if (device is DoorLock doorLock) doorLock.TurnOn(); // TurnOn låser dörren
        }
    }
}