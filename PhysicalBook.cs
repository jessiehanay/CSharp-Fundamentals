class PhysicalBook : Book
{
   private int pages;
   private int availableCopies;

    // Constructor:
   public PhysicalBook(string title, string author, int id, int pages, int availableCopies)
       : base(title, author, id)
   {
       this.pages = pages;
       this.availableCopies = availableCopies;
   }
   
    // Override PrintInfo method:   
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Id: {id}, Title: {title}, Author: {author}, Pages: {pages}, Available Copies: {availableCopies}");
    }

    // Override Borrow method:
    public override bool Borrow()
    {
        if (this.availableCopies <= 0)
        {
            Console.WriteLine($"No available copies of '{title}' to borrow.");
            return false;
        }
        Console.WriteLine($"Book '{title}' borrowed.");
        this.availableCopies--;
        return true;
    }

    // Override Return method:
    public override bool Return()
    {
        Console.WriteLine($"Book '{title}' returned.");
        this.availableCopies++;
        return true;
   }

   // Method to get available copies
    public int GetAvailableCopies()
    {
        return this.availableCopies;
    }
}

