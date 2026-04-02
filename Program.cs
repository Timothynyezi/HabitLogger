using System.Reflection.Metadata.Ecma335;

DatabaseManager db = new DatabaseManager();

db.InitialiseDatabase();

bool isRunning = true;

ShowWelcome();

while (isRunning)
{
    Console.Clear();
    Console.WriteLine("╔══════════════════════════════╗");
    Console.WriteLine("║       HABIT LOGGER           ║");
    Console.WriteLine("║    💧 Water Intake Tracker   ║");
    Console.WriteLine("╠══════════════════════════════╣");
    Console.WriteLine("║  1.  Log Water Intake        ║");
    Console.WriteLine("║  2.  View All Entries        ║");
    Console.WriteLine("║  3.  Update an Entry         ║");
    Console.WriteLine("║  4.  Delete an Entry         ║");
    Console.WriteLine("║  0.  Exit                    ║");
    Console.WriteLine("╚══════════════════════════════╝");
    Console.Write("\n  Choose an option: "); 

    string choice = Console.ReadLine()?.Trim();

    switch (choice)
    {
        case "1":
            LogEntry(db);
            break;
        case "2":
            ViewEntries(db);
            break;
        case "3":
            UpdateEntry(db);
            break;
        case "4":
            DeleteEntry(db);
            break;
        case "0":
            isRunning = false;
            ShowGoodby();
            break;
        default:
        Console.WriteLine("\n Invalid option. Please choose 0 -4.");

    }

    
}