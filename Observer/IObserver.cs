// Detta är för lyssnarna (t.ex. Dashboard, AuditLog)
public interface IObserver
{
    // Skickar med IDevice så lyssnaren vet VILKEN enhet som uppdaterades
    void Update(IDevice device);
}

// Detta är för prylarna (t.ex. Light) så de kan hantera sina lyssnare