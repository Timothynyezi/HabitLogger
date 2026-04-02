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

    void ShowWelcome()
    {
    Console.Clear();
    Console.WriteLine("╔══════════════════════════════╗");
    Console.WriteLine("║     WELCOME TO               ║");
    Console.WriteLine("║      HABIT LOGGER            ║");
    Console.WriteLine("╠══════════════════════════════╣");
    Console.WriteLine("║  Track your daily water      ║");
    Console.WriteLine("║  intake. Data is stored in   ║");
    Console.WriteLine("║  a real SQLite database.     ║");
    Console.WriteLine("╚══════════════════════════════╝");
    Console.WriteLine("\n  Press any key to start...");
    Console.ReadKey();   
    }

    void ShowGoodby()
    {
    Console.Clear();
    Console.WriteLine("╔══════════════════════════════╗");
    Console.WriteLine("║          GOODBYE!            ║");
    Console.WriteLine("╠══════════════════════════════╣");
    Console.WriteLine("║  Your data is safely stored  ║");
    Console.WriteLine("║  in habitlogger.db           ║");
    Console.WriteLine("╚══════════════════════════════╝");
    Thread.Sleep(2000); 
    }

    void LogEntry(DatabaseManager database)
    {
        Console.Clear();
        Console.WriteLine( " Log Entry - coming in step 3");
        Console.ReadKey();
    }
    void UpdateEntry(DatabaseManager database)
    {
        Console.Clear();
        Console.WriteLine(" Update Entry - coming in step 4");
        Console.ReadKey();
    }
}