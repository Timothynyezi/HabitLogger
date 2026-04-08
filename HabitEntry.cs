// HabitEntry.cs

// ============================================================
// HABITENTRY CLASS
// Represents a single row in the WaterIntake database table.
// Every time we read a record from the database we map it
// into one of these objects — this is called a "model".
//
// Think of it like the GameRecord class from the Math Game
// except instead of holding game results it holds
// one database row.
// ============================================================
class HabitEntry
{
    // Maps directly to the columns in the WaterIntake table:
    // Id       → INTEGER PRIMARY KEY AUTOINCREMENT
    // Date     → TEXT NOT NULL
    // Quantity → INTEGER NOT NULL

    public int Id { get; set; }
    public string Date { get; set; }
    public int Quantity { get; set; }

    // Constructor — used when reading rows FROM the database
    // and mapping them into C# objects
    public HabitEntry(int id, string date, int quantity)
    {
        Id = id;
        Date = date;
        Quantity = quantity;
    }
}