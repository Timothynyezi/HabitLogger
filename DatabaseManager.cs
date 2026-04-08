
using System.Data;
using Microsoft.Data.Sqlite;

class DatabaseManager
{
    private const string ConnectionString = "Data Source=habitlogger.db";

    public void InitialiseDatabase()
    {
        // 'using' here is not the same as 'using' at the top.
        // Here it's a 'using statement' that ensures the
        // connection is closed and memory freed automatically
        // when the block ends — even if an error occurs.
        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            // SQL to create the table.
            // We store this as a string and pass it to SQLite.
            string createTableSql = @"
                CREATE TABLE IF NOT EXISTS WaterIntake (
                    Id       INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date     TEXT    NOT NULL,
                    Quantity INTEGER NOT NULL
                )";

            // SqliteCommand links a SQL string to a connection.
            // Think of it as the messenger that carries your
            // SQL instruction to the database and runs it.
            using (SqliteCommand command = new SqliteCommand(createTableSql, connection))
            {
                // ExecuteNonQuery runs SQL that doesn't return
                // rows — CREATE, INSERT, UPDATE, DELETE all use this.
                // SELECT uses a different method (coming later).
                command.ExecuteNonQuery();
            }
        }
    }public void InsertEntry(string date, int quantity)
    {
        using(SqliteConnection connection = new SqliteConnection(connection))
        {
            connection.Open();

            string insertSql = @"
                INSERT INTO WaterIntake (Date, Quantity)
                VALUES (@date, @quantity)";
            using (SqliteCommand command = new SqliteCommand(insertSql, connection))
            {
                // Bind the actual values to the placeholders.
                //SQLite handles the escaping - no injection possible.
                 command.Parameters.AddWithValue("@date", date);
                 command.Parameters.AddWithValue(@"quantity", quantity);

                 // ExecuteNonQuery for INSERT - no rows returned
                 command.ExecuteNonQuery();
            }
        }
    }
    /* SELECT ALL - READS every row from WaterIntake
     // Returns a List<HabitEntry> — a list of C# objects.
    // DatabaseManager reads the data, maps each row into a
    // HabitEntry object, and returns the list.
    // It never prints anything — that's UserInterface's job.
    */

    public List<HabitEntry> GetAllEntries()
    {
        // Start with an empty list - to be filled as we record
        List<HabitEntry> entries = new List<HabitEntry>();

        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            string selectSql = "SELECT * FROM WaterIntake ORDER BY Id";

            using (SqliteCommand command = new SqliteCommand(selectSql, connection))
            {
                
            }   
        }
    }
}