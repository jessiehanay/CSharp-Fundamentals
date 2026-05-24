class AudioBook : Book
{
    private double durationMinutes;
    private string narrator;

    // Constructor:
    public AudioBook(string title, string author, int id, double durationMinutes, string narrator)
        : base(title, author, id)
    {
        this.durationMinutes = durationMinutes;
        this.narrator = narrator;
    }

    // Override PrintInfo method:
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Id: {id}, Title: {title}, Author: {author}, Duration (minutes): {durationMinutes}, Narrator: {narrator}");
    }

    //Get Duration method:
    public double GetDurationMinutes()
    {
        return this.durationMinutes;
    }
}
