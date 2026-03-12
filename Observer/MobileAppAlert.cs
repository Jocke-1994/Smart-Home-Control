public class MobileAppAlert : IObserver
{
    public void Update(IDevice device)
    { 
            Logger.Instance.Log($"[Mobilapp] Pushnotis: {device.Name} ändrade status.");
    }
}