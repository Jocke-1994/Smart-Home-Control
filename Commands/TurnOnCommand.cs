public class TurnOnCommand : ICommand
{
    private readonly IDevice _device;

    public TurnOnCommand(IDevice device)
    {
        _device = device;
    }

    public void Execute()
    {
        _device.TurnOn();
    }

    public void Undo()
    {
        _device.TurnOff();
    }
}