public interface ISubject
{
    void Attach(IObserver observer); // Lägg till en lyssnare
    void Detach(IObserver observer); // Ta bort en lyssnare
    void Notify();                   // Säg till alla lyssnare att något hänt
}