public interface IDevice
{
    string Name { get; }
    void TurnOn();
    void TurnOff();
}
//Thermostat och andra enheter kan implementera IDevice på liknande sätt,
//och alla kommer att använda samma Logger-instans för att logga sina aktiviteter.

//Doorlock ska implementeras på samma saätt