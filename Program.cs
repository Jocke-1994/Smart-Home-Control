using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Skapa Facaden (Vårt enkla gränssnitt till det komplexa systemet)
        SmartHomeFacade homeHub = new SmartHomeFacade();

        // 2. Skapa enheter
        Light kitchenLight = new Light("Kökslampa");
        Thermostat livingRoomThermo = new Thermostat("Vardagsrumstermostat");
        DoorLock frontDoor = new DoorLock("Ytterdörr");

        // 3. Lägg till enheter i hubben (Facaden sköter alla Observers automatiskt!)
        homeHub.AddDevice(kitchenLight);
        homeHub.AddDevice(livingRoomThermo);
        homeHub.AddDevice(frontDoor);

        // 4. Kör en färdig rutin (Facade i praktiken)
        homeHub.MorningRoutine();

        // 5. Ändra läge (Strategy-mönstret via Facade)
        homeHub.SetMode(new EcoMode());

        // 6. Kör enskilda kommandon (Command-mönstret via Facade)
        homeHub.RunCommand(new TurnOffCommand(kitchenLight));

        // 7. Testa Undo (VG-kravet)
        Console.WriteLine("\n--- Testar Undo via Facade ---");
        homeHub.Undo();

        Console.WriteLine("\nSystemtest klart!");
        Console.ReadLine();
    }
}