using System.Collections.Generic;

public class DoorLock : IDevice, ISubject
{
    // Listan med lyssnare
    private List<IObserver> _observers = new List<IObserver>();

    public string Name { get; }
    public bool IsLocked { get; private set; }

    public DoorLock(string name)
    {
        Name = name;
    }

    // --- ISubject-koden ---
    public void Attach(IObserver observer) => _observers.Add(observer);

    public void Detach(IObserver observer) => _observers.Remove(observer);

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }
    // ----------------------

    public void TurnOn()
    {
        IsLocked = true;
        Logger.Instance.Log($"{Name} låstes.");
        Notify(); // <-- Här säger vi till lyssnarna!
    }

    public void TurnOff()
    {
        IsLocked = false;
        Logger.Instance.Log($"{Name} låstes upp.");
        Notify(); // <-- Här säger vi till lyssnarna!
    }
}