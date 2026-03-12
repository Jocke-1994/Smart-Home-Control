using System.Collections.Generic;

public class Light : IDevice, ISubject
{
    // Listan med alla som vill ha uppdateringar
    private List<IObserver> _observers = new List<IObserver>();

    public string Name { get; }
    public bool IsOn { get; private set; }

    public Light(string name)
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
        IsOn = true;
        Logger.Instance.Log($"{Name} tändes.");
        Notify(); // <-- Säg till alla lyssnare att något hänt!
    }

    public void TurnOff()
    {
        IsOn = false;
        Logger.Instance.Log($"{Name} släcktes.");
        Notify(); // <-- Säg till alla lyssnare att något hänt!
    }
}