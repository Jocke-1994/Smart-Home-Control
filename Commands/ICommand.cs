public interface ICommand
{
    void Execute();
    void Undo(); // Krävs för VG-kravet!
}