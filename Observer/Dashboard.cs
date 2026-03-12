public class Dashboard : IObserver
{
    public void Update(IDevice device)
    {
        Console.WriteLine($"[Dashboard] Live-uppdatering: {device.Name} har ändrats.");
    }
}