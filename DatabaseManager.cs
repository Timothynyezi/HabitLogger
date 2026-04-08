
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
            using (SqliteCommand = new SqliteCommand(insertSql, connection))
            {
                // Bind the actual 
            }
        }
    }

}