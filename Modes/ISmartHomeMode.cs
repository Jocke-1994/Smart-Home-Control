using System.Collections.Generic;

public interface ISmartHomeMode
{
    // Tar emot en lista med enheter så att läget kan styra dem
    void Activate(List<IDevice> devices);
}