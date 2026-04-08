
using System.Reflection.Metadata;

DatabaseManager db = new DatabaseManager();

// Runs on every startup — creates the database and table
// if they don't already exist. Safe to call every time.
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
            ShowGoodbye();
            break;
        default:
            Console.WriteLine("\n  ⚠️  Invalid option. Please choose 0 - 4.");
            Thread.Sleep(1500);
            break;
    }
}

// ============================================================
// WELCOME SCREEN
// ============================================================
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

// ============================================================
// GOODBYE SCREEN
// ============================================================
void ShowGoodbye()
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

// ============================================================
// PLACEHOLDER METHODS — filled in Steps 3 and 4
// ============================================================
void LogEntry(DatabaseManager database)
{
    Console.Clear();
    Console.WriteLine("╔══════════════════════════════╗");
    Console.WriteLine("║       LOG WATER INTAKE       ║");
    Console.WriteLine("╚══════════════════════════════╝");

    UserInterface ui = new UserInterface();

    string date     = ui.GetDate();
    int quantity    = ui.GetQuantity();

    // Pass the clean values to DatabaseManager to save
    database.InsertEntry(date, quantity);

    Console.WriteLine("\n   Entry saved successfully!");
    Console.WriteLine("\n  Press any key to return...");
    Console.ReadKey();


}

void ViewEntries(DatabaseManager database)
{
    // Ask DatabaseManager for the data
    List<HabitEntry> entries = database.GetAllEntries();

    // Pass the data to UserInterface to display
    UserInterface ui = new UserInterface();
    ui.DisplayEntries(entries);

    Console.WriteLine("\n  Press any key to return...");
    Console.ReadKey();
}

void UpdateEntry(DatabaseManager database)
{
    Console.Clear();
    Console.WriteLine("  Update Entry — coming in Step 4");
    Console.ReadKey();
}

void DeleteEntry(DatabaseManager database)
{
    Console.Clear();
    Console.WriteLine("  Delete Entry — coming in Step 4");
    Console.ReadKey();
}