class HabitEntry
{
    public int Id { get; set; }
    public string Date { get; set; }
    public int Quantity { get; set;}

    public HabitEntry(int id, string date, int quantity)
    {
        Id = id;
        Date = date;
        Quantity = quantity;
    }
}