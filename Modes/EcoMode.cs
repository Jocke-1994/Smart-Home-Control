using System;
using System.Collections.Generic;

public class EcoMode : ISmartHomeMode
{
    public void Activate(List<IDevice> devices)
    {
        Console.WriteLine("\n*** Aktiverar Eco Mode ***");

        foreach (var device in devices)
        {
            if (device is Light light) light.TurnOff();
            else if (device is Thermostat thermostat) thermostat.SetTemperature(18); // Sparar energi
            else if (device is DoorLock doorLock) doorLock.TurnOn(); // TurnOn låser dörren i vår nuvarande logik
        }
    }
}