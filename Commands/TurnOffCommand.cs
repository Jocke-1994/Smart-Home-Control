public class TurnOffCommand : ICommand
{
    private readonly IDevice _device;

    public TurnOffCommand(IDevice device)
    {
        _device = device;
    }

    public void Execute()
    {
        _device.TurnOff();
    }

    public void Undo()
    {
        _device.TurnOn();
    }
}