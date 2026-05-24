
string connectionString = "Server=127.0.0.1;Port=3306;Database=library_db;Uid=root;Pwd=RootPass123#;";
IBookRepository repository = new MySqlBookRepository(connectionString);
Library lib = new Library(repository);

// Main menu loop:
bool exit = false;
while (!exit)
{
    Console.WriteLine("Library Management System");
    Console.WriteLine("1. Add Physical Book");
    Console.WriteLine("2. Add Digital Book");
    Console.WriteLine("3. Add Audio Book");
    Console.WriteLine("4. List All Books");
    Console.WriteLine("5. Borrow Book");
    Console.WriteLine("6. Return Book");
    Console.WriteLine("7. Digital Book Report");
    Console.WriteLine("8. Audio Book Report");
    Console.WriteLine("9. Physical Book Report");
    Console.WriteLine("10. Exit");

    string choice = Console.ReadLine() ?? "";
    switch (choice)
    {
        case "1":
            AddPhysicalBookMenu(lib);
            break;
        case "2":
            AddDigitalBookMenu(lib);
            break;
        case "3":
            AddAudioBookMenu(lib);
            break;
        case "4":
            ListOfAllBooks(lib);
            break;
        case "5":
            BorrowBookMenu(lib);
            break;
        case "6":
            ReturnBookMenu(lib);
            break;
        case "7":
            DigitalBookReport(lib);
            break;
        case "8":
            AudioBookReport(lib);
            break;
        case "9":
            PhysicalBookReport(lib);
            break;
        case "10":
            exit = true;
            Console.WriteLine("Exiting Library Management System. Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
    Console.WriteLine("To exit press 10, to continue press any other valid key from the menu.");
}

//1:
static void AddPhysicalBookMenu(Library lib)
{
    try
    {
        Console.WriteLine("Enter Physical Book Details:");
        Console.Write("Title: ");
        string title = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(title)) 
        {
            throw new FormatException();
        }

        Console.Write("Author: ");
        string author = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(author)) 
        {
            throw new FormatException();
        }

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine() ?? "");

        Console.Write("Pages: ");
        int pages = int.Parse(Console.ReadLine() ?? "");

        Console.Write("Available Copies: ");
        int availableCopies = int.Parse(Console.ReadLine() ?? "");

        PhysicalBook physicalBook = new PhysicalBook(title, author, id, pages, availableCopies);
        if (lib.AddBook(physicalBook))
        {
            Console.WriteLine("Book added successfully");
        }
        else
        {
            Console.WriteLine("Error, book not added");
        }
    }
    //Handle format exceptions for invalid input:
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
}

//2:
static void AddDigitalBookMenu(Library lib)
{
    try
    {
        Console.WriteLine("Enter Digital Book Details:");
        Console.Write("Title: ");
        string title = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(title)) 
        {
            throw new FormatException();
        }

        Console.Write("Author: ");
        string author = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(author)) 
        {
            throw new FormatException();
        }

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine() ?? "");

        Console.Write("File Size (MB): ");
        double fileSizeMB = double.Parse(Console.ReadLine() ?? "");

        Console.Write("Format (e.g., PDF, EPUB): ");
        string format = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(format)) 
        {
            throw new FormatException();
        }

        DigitalBook digitalBook = new DigitalBook(title, author, id, fileSizeMB, format);
        if (lib.AddBook(digitalBook))
        {
            Console.WriteLine("Book added successfully");
        }
        else
        {
            Console.WriteLine("Error, book not added");
        }
    }
    //Handle format exceptions for invalid input:
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
}

//3:
static void AddAudioBookMenu(Library lib)
{
    try
    {
        Console.WriteLine("Enter Audio Book Details:");
        Console.Write("Title: ");
        string title = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(title)) 
        {
            throw new FormatException();
        }

        Console.Write("Author: ");
        string author = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(author)) 
        {
            throw new FormatException();
        }

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine() ?? "");

        Console.Write("Duration (minutes): ");
        int durationMinutes = int.Parse(Console.ReadLine() ?? "");

        Console.Write("Narrator: ");
        string narrator = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(narrator)) 
        {
            throw new FormatException();
        }

        AudioBook audioBook = new AudioBook(title, author, id, durationMinutes, narrator);
        if (lib.AddBook(audioBook))
        {
            Console.WriteLine("Book added successfully");
        }
        else
        {
            Console.WriteLine("Error, book not added");
        }
    }
    //Handle format exceptions for invalid input:
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
}

//4:
static void ListOfAllBooks(Library lib)
{
    Console.WriteLine("List of All Books In The Library:");
    lib.PrintAllBooks();
    Console.WriteLine("End of List.");
}

//5:
static void BorrowBookMenu(Library lib)
{
    try
    {
        Console.Write("Enter the ID of the book to borrow: ");
        int id = int.Parse(Console.ReadLine() ?? "");
        if (lib.BorrowBook(id))
        {
            Console.WriteLine("Book borrowed successfully");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
}

//6:
static void ReturnBookMenu(Library lib)
{
    try
    {
        Console.Write("Enter the ID of the book to return: ");
        int id = int.Parse(Console.ReadLine() ?? "");
        if (lib.ReturnBook(id))
        {
            Console.WriteLine("Book returned successfully");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
}

//7:
static void DigitalBookReport(Library lib)
{
    Console.WriteLine("Digital Book Report:");
    lib.DigitalBookReport();
}

//8:
static void AudioBookReport(Library lib)
{
    Console.WriteLine("Audio Book Report:");
    lib.AudioBookReport();
}

//9:
static void PhysicalBookReport(Library lib)
{
    Console.WriteLine("Physical Book Report:");
    lib.PhysicalBookReport();
}
