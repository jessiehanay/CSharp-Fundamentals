class AudioBook : Book
{
    private int durationMinutes;
    private string narrator;

    // Constructor:
    public AudioBook(string title, string author, int id, int durationMinutes, string narrator): base(title, author, id)
    {
        this.durationMinutes = durationMinutes;
        this.narrator = narrator;
    }

    // Override PrintInfo method:
    public override void PrintInfo()
    {
        Console.WriteLine($"Type: Audio, Id: {id}, Title: {title}, Author: {author}, Duration (minutes): {durationMinutes}, Narrator: {narrator}");
    }

    public int GetDurationMinutes() => durationMinutes;
    public string GetNarrator() => narrator;
}