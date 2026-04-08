// DatabaseManager.cs
using Microsoft.Data.Sqlite;

class DatabaseManager
{
    private const string ConnectionString = "Data Source=habitlogger.db";

    // ============================================================
    // INITIALISE DATABASE — unchanged from Step 2
    // ============================================================
    public void InitialiseDatabase()
    {
        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            string createTableSql = @"
                CREATE TABLE IF NOT EXISTS WaterIntake (
                    Id       INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date     TEXT    NOT NULL,
                    Quantity INTEGER NOT NULL
                )";

            using (SqliteCommand command = new SqliteCommand(createTableSql, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    // ============================================================
    // INSERT — adds a new entry to the database
    //
    // Notice we use @date and @quantity as placeholders.
    // We NEVER put userInput directly into the SQL string.
    // Parameters.AddWithValue() safely binds the values.
    // ============================================================
    public void InsertEntry(string date, int quantity)
    {
        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            string insertSql = @"
                INSERT INTO WaterIntake (Date, Quantity)
                VALUES (@date, @quantity)";

            using (SqliteCommand command = new SqliteCommand(insertSql, connection))
            {
                // Bind the actual values to the placeholders.
                // SQLite handles the escaping — no injection possible.
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@quantity", quantity);

                // ExecuteNonQuery for INSERT — no rows returned
                command.ExecuteNonQuery();
            }
        }
    }

    // ============================================================
    // SELECT ALL — reads every row from WaterIntake
    //
    // Returns a List<HabitEntry> — a list of C# objects.
    // DatabaseManager reads the data, maps each row into a
    // HabitEntry object, and returns the list.
    // It never prints anything — that's UserInterface's job.
    // ============================================================
    public List<HabitEntry> GetAllEntries()
    {
        // Start with an empty list — we'll fill it as we read rows
        List<HabitEntry> entries = new List<HabitEntry>();

        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            // SELECT * means "give me all columns"
            // ORDER BY Id makes results appear in insertion order
            string selectSql = "SELECT * FROM WaterIntake ORDER BY Id";

            using (SqliteCommand command = new SqliteCommand(selectSql, connection))
            {
                // ExecuteReader runs a SELECT and returns a reader.
                // Unlike ExecuteNonQuery, this gives us rows back.
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    // reader.Read() moves forward one row at a time.
                    // Returns true if a row was found, false when done.
                    while (reader.Read())
                    {
                        // Map each column to its C# type.
                        // GetInt32 reads an integer column.
                        // GetString reads a text column.
                        // The number is the column index (0-based).
                        int id       = reader.GetInt32(0);
                        string date  = reader.GetString(1);
                        int quantity = reader.GetInt32(2);

                        // Create a HabitEntry object for this row
                        // and add it to our list
                        entries.Add(new HabitEntry(id, date, quantity));
                    }
                }
            }
        }

        // Return the completed list to whoever called this method
        return entries;
    }
}