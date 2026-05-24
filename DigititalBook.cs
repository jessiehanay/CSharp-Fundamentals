class DigitalBook : Book
{
    private double fileSizeMB;
    private string format;

    // Constructor:
    public DigitalBook(string title, string author, int id, double fileSizeMB, string format)
        : base(title, author, id)
    {
        this.fileSizeMB = fileSizeMB;
        this.format = format;
    }

    // Override PrintInfo method:
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Id: {id}, Title: {title}, Author: {author}, File Size (MB): {fileSizeMB}, Format: {format}");
    }

    //Get File Size method:
    public double GetFileSizeMB()
    {
        return this.fileSizeMB;
    }   
}