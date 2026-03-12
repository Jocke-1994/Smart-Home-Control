public sealed class Logger
{
    // Den enda instansen av loggern skapas här
    private static readonly Logger _instance = new Logger();

    // Privat konstruktor är nyckeln - ingen annan kod kan skriva "new Logger()"
    private Logger() { }

    // Den globala åtkomstpunkten som alla andra klasser använder
    public static Logger Instance => _instance;

    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {DateTime.Now:HH:mm:ss}: {message}");
    }
}