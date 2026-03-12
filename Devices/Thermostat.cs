public class Thermostat : IDevice, ISubject

{
    private List<IObserver> _observers = new List<IObserver>();
    public string Name { get; }
    public int Temperature { get; private set; }
    public Thermostat(string name)
    {
        Name = name;
    }
    // --- ISubject implementation ---
    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this); // Skickar med sig själv (Light) till lyssnaren
        }
    }
    // -------------------------------
    public void TurnOn()
    {
        // För en termostat kanske "turning on" innebär att börja reglera temperaturen
        Logger.Instance.Log($"{Name} startade.");
        Notify();
    }
    public void TurnOff()
    {
        Logger.Instance.Log($"{Name} stoppades.");
        Notify();
    }
    public void SetTemperature(int temperature)
    {
        Temperature = temperature;
        Logger.Instance.Log($"{Name} ställdes in på {Temperature}°C.");
        Notify();
    }
}