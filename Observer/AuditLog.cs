public class AuditLog : IObserver
{
    public void Update(IDevice device)
    {
        Console.WriteLine($"[Audit] Säkerhetslogg: Statusändring registrerad på '{device.Name}'.");
    }
}