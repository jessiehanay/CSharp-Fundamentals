using System.Collections;
class Library
{
    private ArrayList book_list;

    // Constructor:
    public Library()
    {
        this.book_list= new ArrayList();
        Console.WriteLine("Library created ");
    }

    // Method to add book to library:
    public void AddBook(Book book)
    {
        if (book == null)
        {
            Console.WriteLine("Cannot add a null book to the library.");
            return;
        }
        if (this.FindByID(book.GetID()) != null)
        {
            Console.WriteLine($"A book with ID {book.GetID()} already exists in the library.");
            return;
        }
        this.book_list.Add(book);
    }

    // Method to find a book by ID:
    Book? FindByID(int id)
    {
        foreach (Book book in this.book_list)
        {
            if (book.GetID() == id)
            {
                return book;
            }
        }
        return null;
    }
    
    // Method to borrow a book by ID:
    public bool BorrowBook(int id)
    {
        Book? book = FindByID(id);
        if (book == null)
        {
            Console.WriteLine($"Book with ID {id} not found.");
            return false;
        }
        if (book is not PhysicalBook physicalBook)
        {
            Console.WriteLine($"Error: Only physical books can be borrowed.");
            return false;
        }
        return book.Borrow();   
        
    }

    // Method to return a book by ID:
    public bool ReturnBook(int id)
    {
        Book? book = FindByID(id);
        if (book == null)
        {
            Console.WriteLine($"Book with ID {id} not found.");
            return false;
        }
        if (book is not PhysicalBook physicalBook)
        {
            Console.WriteLine($"Error: Only physical books can be returned.");
            return false;
        }
        return book.Return();
    }
    
    // Method to print all books in library:
    public void PrintAllBooks()
    {
        foreach (Book book in this.book_list)
        {
            book.PrintInfo();
        }
    }

    // PhysicalBook Report:
    public void PhysicalBookReport()
    {
        foreach (Book book in this.book_list)
        {
            if (book is PhysicalBook physicalBook)
            {
                if(physicalBook.GetAvailableCopies() == 0)
                {
                    Console.WriteLine($"{physicalBook.GetID()}; {physicalBook.GetTitle()}");
                }
            }
        }
 }

    // AudioBook Report:
   public void AudioBookReport()
    {
        double maxDurationMin = 0;    
        double totalDurationMin= 0;
        foreach (Book book in this.book_list)
        {
            if (book is AudioBook audioBook)
            {
                double durationMin= audioBook.GetDurationMinutes();
                totalDurationMin += durationMin;
                if (durationMin > maxDurationMin)
                {
                    maxDurationMin = durationMin; 
                }
            }
        }
        Console.WriteLine($"{totalDurationMin}; {maxDurationMin}");
    }

    // DigitalBook Report:
   public void DigitalBookReport()
    {
        double maxFileSize = 0;
        double totalFileSize = 0;
        foreach (Book book in this.book_list)
        {
            if (book is DigitalBook digitalBook)
            {
                double fileSize = digitalBook.GetFileSizeMB();
                totalFileSize += fileSize;
                if (fileSize > maxFileSize)
                {
                    maxFileSize = fileSize; 
                }
            }
        }
        Console.WriteLine($"{totalFileSize}; {maxFileSize}");
    }
}
