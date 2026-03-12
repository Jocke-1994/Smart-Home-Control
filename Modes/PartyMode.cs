using System;
using System.Collections.Generic;

public class PartyMode : ISmartHomeMode
{
    public void Activate(List<IDevice> devices)
    {
        Console.WriteLine("\n*** Aktiverar Party Mode ***");
        foreach (var device in devices)
        {
            if (device is Light light) light.TurnOn();
            else if (device is Thermostat thermostat) thermostat.SetTemperature(22);
            else if (device is DoorLock doorLock) doorLock.TurnOff(); // TurnOff låser upp
        }
    }
}