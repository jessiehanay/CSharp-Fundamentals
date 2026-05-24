
Library lib = new Library();

// Main menu loop:
bool exit = false;
while (!exit)
{
    Console.WriteLine("Library Management System");
    Console.WriteLine("1. Add Physical Book");
    Console.WriteLine("2. Add Digital Book");
    Console.WriteLine("3. Add Audio Book");
    Console.WriteLine("4. Show All Books");
    Console.WriteLine("5. Borrow Book");
    Console.WriteLine("6. Return Book");
    Console.WriteLine("7. Digital Book Report");
    Console.WriteLine("8. Audio Book Report");
    Console.WriteLine("9. Physical Book Report");
    Console.WriteLine("10. Exit");

    Console.Write("Enter your choice: ");
    string? choice = Console.ReadLine();
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
    Console.WriteLine("Enter Physical Book Details:");
    Console.Write("Title: ");
    string? title = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(title))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

    Console.Write("Author: ");
    string? author = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(author))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

    Console.Write("ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

    Console.Write("Pages: ");
    if (!int.TryParse(Console.ReadLine(), out int pages))
    {
        Console.WriteLine("Error, book not added");
        return;
    }
    
    Console.Write("Available Copies: ");
    if (!int.TryParse(Console.ReadLine(), out int availableCopies))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

    PhysicalBook physicalBook = new PhysicalBook(title, author, id, pages, availableCopies);
    lib.AddBook(physicalBook);
    Console.WriteLine("Physical book added successfully.");
}

//2:
static void AddDigitalBookMenu(Library lib)
{
    Console.WriteLine("Enter Digital Book Details:");
    Console.Write("Title: ");
    string? title = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(title))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

     Console.Write("Author: ");
    string? author = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(author))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

    Console.Write("ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

    Console.Write("File Size (MB): ");
    if (!double.TryParse(Console.ReadLine(), out double fileSizeMB))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

    Console.Write("Format (e.g., PDF, EPUB): ");
    string? format = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(format))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

    DigitalBook digitalBook = new DigitalBook(title, author, id, fileSizeMB, format);
    lib.AddBook(digitalBook);
    Console.WriteLine("Digital book added successfully.");
}

//3:
static void AddAudioBookMenu(Library lib)
{
    Console.WriteLine("Enter Audio Book Details:");
    Console.Write("Title: ");
    string? title = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(title))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

    Console.Write("Author: ");
    string? author = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(author))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

    Console.Write("ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

    Console.Write("Duration (minutes): ");
    if (!double.TryParse(Console.ReadLine(), out double durationMinutes))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

    Console.Write("Narrator: ");
    string? narrator = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(narrator))
    {
        Console.WriteLine("Error, book not added");
        return;
    }

    AudioBook audioBook = new AudioBook(title, author, id, durationMinutes, narrator);
    lib.AddBook(audioBook);
    Console.WriteLine("Audio book added successfully.");
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
    Console.Write("Enter the ID of the book to borrow: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Book ID must be a number");
        return;
    }
    lib.BorrowBook(id);
}

//6:
static void ReturnBookMenu(Library lib)
{
    Console.Write("Enter the ID of the book to return: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Book ID must be a number");
        return;
    }
    lib.ReturnBook(id);
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
