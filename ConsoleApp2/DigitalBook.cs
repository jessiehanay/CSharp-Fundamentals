class DigitalBook : Book
{
    private double fileSizeMB;
    private string format;

    // Constructor:
    public DigitalBook(string title, string author, int id, double fileSizeMB, string format): base(title, author, id)
    {
        this.fileSizeMB = fileSizeMB;
        this.format = format;
    }

    // Override PrintInfo method:
    public override void PrintInfo()
    {
        Console.WriteLine($"Type: Digital, Id: {id}, Title: {title}, Author: {author}, File Size (MB): {fileSizeMB}, Format: {format}");
    }

    public double GetFileSizeMB() => fileSizeMB;
    public string GetFormat() => format;
}