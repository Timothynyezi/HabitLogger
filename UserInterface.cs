// UserInterface.cs

// ============================================================
// USERINTERFACE CLASS
// Single responsibility: handle all console input and output.
// It asks the user for input, validates it, and returns
// clean values. It also displays data it receives.
// It never touches the database directly.
// ============================================================
class UserInterface
{
    // ============================================================
    // GET DATE FROM USER
    // Asks for a date and validates the format is dd-MM-yyyy.
    // Returns the validated date string.
    //
    // DateTime.TryParseExact checks BOTH that the input is a
    // real date AND that it matches our exact expected format.
    // ============================================================
    public string GetDate()
    {
        Console.WriteLine("\n  Enter the date (dd-MM-yyyy):");
        Console.Write("  → ");

        string input = Console.ReadLine()?.Trim();

        // TryParseExact validates the format strictly.
        // "dd-MM-yyyy" means: 2-digit day, 2-digit month, 4-digit year
        // Example: 06-03-2026 ✅    6/3/26 ❌    March 6 ❌
        //
        // 'out _' discards the parsed DateTime — we only want
        // to validate the format, not use the DateTime object itself.
        // We store dates as strings in SQLite for simplicity.
        while (!DateTime.TryParseExact(
            input,
            "dd-MM-yyyy",
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None,
            out _))
        {
            Console.WriteLine("  ⚠️  Invalid date. Use format dd-MM-yyyy");
            Console.WriteLine("  Example: 06-03-2026");
            Console.Write("  → ");
            input = Console.ReadLine()?.Trim();
        }

        return input;
    }

    // ============================================================
    // GET QUANTITY FROM USER
    // Asks for a positive whole number and validates it.
    // Returns the validated quantity as an int.
    // ============================================================
    public int GetQuantity()
    {
        Console.WriteLine("\n  Enter number of glasses of water:");
        Console.Write("  → ");

        string input = Console.ReadLine()?.Trim();
        int quantity;

        // Must be a valid integer AND greater than zero
        bool isValid = int.TryParse(input, out quantity) && quantity > 0;

        while (!isValid)
        {
            Console.WriteLine("  ⚠️  Please enter a positive whole number.");
            Console.Write("  → ");
            input = Console.ReadLine()?.Trim();
            isValid = int.TryParse(input, out quantity) && quantity > 0;
        }

        return quantity;
    }

    // ============================================================
    // GET ID FROM USER
    // Used for Update and Delete — asks which record to act on.
    // ============================================================
    public int GetId()
    {
        Console.WriteLine("\n  Enter the ID of the entry:");
        Console.Write("  → ");

        string input = Console.ReadLine()?.Trim();
        int id;

        bool isValid = int.TryParse(input, out id) && id > 0;

        while (!isValid)
        {
            Console.WriteLine("  ⚠️  Please enter a valid ID number.");
            Console.Write("  → ");
            input = Console.ReadLine()?.Trim();
            isValid = int.TryParse(input, out id) && id > 0;
        }

        return id;
    }

    // ============================================================
    // DISPLAY ALL ENTRIES
    // Receives a list of HabitEntry objects and prints them.
    // UserInterface only displays — it never fetches data itself.
    // ============================================================
    public void DisplayEntries(List<HabitEntry> entries)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║         ALL WATER ENTRIES            ║");
        Console.WriteLine("╠══════════════════════════════════════╣");

        if (entries.Count == 0)
        {
            Console.WriteLine("║  No entries found.                   ║");
            Console.WriteLine("║  Log some water intake first!        ║");
        }
        else
        {
            // Print column headers
            Console.WriteLine("║  ID   │ Date         │ Glasses       ║");
            Console.WriteLine("╠══════════════════════════════════════╣");

            // Loop through each entry and display it.
            // PadRight keeps columns aligned regardless of value width.
            foreach (HabitEntry entry in entries)
            {
                string id       = entry.Id.ToString().PadRight(5);
                string date     = entry.Date.PadRight(12);
                string quantity = entry.Quantity.ToString().PadRight(5);

                Console.WriteLine($"║  {id} │ {date} │ {quantity}         ║");
            }

            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine($"║  Total entries: {entries.Count.ToString().PadRight(21)}║");
        }

        Console.WriteLine("╚══════════════════════════════════════╝");
    }
}