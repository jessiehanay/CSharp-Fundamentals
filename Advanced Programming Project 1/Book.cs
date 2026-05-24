class Book 
{
    // Variables:
    protected string title;
    protected string author;
    protected int id;

     // Constructor:
    public Book(string title, string author, int id)
    {
        this.title = title;
        this.author = author;
        this.id = id;
    }

    // Method to print book info:
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Title: {title}; Author: {author}; ID: {id}");
    }

    // Method to borrow the book:
    public virtual bool Borrow()
    {
        if (this is PhysicalBook physicalBook)
        {
            physicalBook.Borrow();
            return true;
        }
        Console.WriteLine($"Book '{title}' borrowed.");
        return true;
    }

    // Method to return the book:
    public virtual bool Return()
    {
        Console.WriteLine($"Book '{title}' returned.");     
        return true;
    }

    //Method to get book ID
    public int GetID()
    {
        return this.id;         
    }

    //Method to get book title
    public string GetTitle()
    {
        return this.title;  
    }
}