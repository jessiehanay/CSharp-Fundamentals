class Library
{
    private readonly IBookRepository _repository;

    public Library(IBookRepository repository)
    {
        _repository = repository;
    }

    // Method to add book to library:
    public bool AddBook(Book book)
    {
        if (_repository.GetById(book.GetID()) != null)
        {
            Console.WriteLine($"A book with ID {book.GetID()} already exists in the library.");
            return false;
        }
        return _repository.Add(book);
    }

    // Method to borrow a book by ID:
    public bool BorrowBook(int id)
    {
        Book? book = _repository.GetById(id);
        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return false;
        }
        bool success = book.Borrow();
        if (success) _repository.Update(book);
        return success;
    }

    // Method to return a book by ID:
    public bool ReturnBook(int id)
    {
        Book? book = _repository.GetById(id);
        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return false;
        }
        bool success = book.Return();
        if (success) _repository.Update(book);
        return success;
    }

    // Method to print all books in library:
    public void PrintAllBooks()
    {
        foreach (Book book in _repository.GetAll())
        {
            book.PrintInfo();
        }
    }

    //PhysicalBook Report:
    public void PhysicalBookReport()
    {
        var parts = new System.Collections.Generic.List<string>();
        foreach (Book book in _repository.GetAll())
        {
            if (book is PhysicalBook physicalBook && physicalBook.GetAvailableCopies() == 0)
            {
                parts.Add(physicalBook.GetID().ToString());
                parts.Add(physicalBook.GetTitle());
            }
        }
        if (parts.Count > 0)
            Console.WriteLine(string.Join("; ", parts));
    }

    //AudioBook Report:
    public void AudioBookReport()
    {
        int total = 0;
        int longest = 0;
        foreach (Book book in _repository.GetAll())
        {
            if (book is AudioBook audioBook)
            {
                total += audioBook.GetDurationMinutes();
                if (audioBook.GetDurationMinutes() > longest)
                    longest = audioBook.GetDurationMinutes();
            }
        }
        Console.WriteLine($"{total}; {longest}");
    }


    //DigitalBook Report:
    public void DigitalBookReport()
    {
        double total = 0;
        double largest = 0;
        foreach (Book book in _repository.GetAll())
        {
            if (book is DigitalBook digitalBook)
            {
                total += digitalBook.GetFileSizeMB();
                if (digitalBook.GetFileSizeMB() > largest)
                    largest = digitalBook.GetFileSizeMB();
            }
        }
        Console.WriteLine($"{total}; {largest}");
    }
}
