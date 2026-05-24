using System.Collections;
using MySql.Data.MySqlClient;

//Repository implementation for MySQL database
public class MySqlBookRepository : IBookRepository 
{
    private readonly string _connectionString;

    public MySqlBookRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public bool Add(Book book)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString); //Connection to database
            conn.Open();

            //Finding the book object to insert into database:
            string sql;
            switch (book)
            {
                case PhysicalBook:
                    sql = @"INSERT INTO books (id, title, author, type, pages, available_copies)
                                  VALUES (@id, @title, @author, 'PHYSICAL', @pages, @availableCopies)";
                    break;
                case DigitalBook:
                    sql = @"INSERT INTO books (id, title, author, type, file_size_mb, format)
                                  VALUES (@id, @title, @author, 'DIGITAL', @fileSizeMB, @format)";
                    break;
                case AudioBook:
                    sql = @"INSERT INTO books (id, title, author, type, duration_minutes, narrator)
                                  VALUES (@id, @title, @author, 'AUDIO', @durationMinutes, @narrator)";
                    break;
                default:
                    throw new ArgumentException("Invalid input. Please try again.");
            }
           
            //Creating a command to execute the SQL statement with parameters:
            //Common parameters for all book types:
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", book.GetID());
            cmd.Parameters.AddWithValue("@title", book.GetTitle());
            cmd.Parameters.AddWithValue("@author", book.GetAuthor());

            //Type-specific parameters:
            if (book is PhysicalBook pb)
            {
                cmd.Parameters.AddWithValue("@pages", pb.GetPages());
                cmd.Parameters.AddWithValue("@availableCopies", pb.GetAvailableCopies());
            }
            else if (book is DigitalBook db)
            {
                cmd.Parameters.AddWithValue("@fileSizeMB", db.GetFileSizeMB());
                cmd.Parameters.AddWithValue("@format", db.GetFormat());
            }
            else if (book is AudioBook ab)
            {
                cmd.Parameters.AddWithValue("@durationMinutes", ab.GetDurationMinutes());
                cmd.Parameters.AddWithValue("@narrator", ab.GetNarrator());
            }

            cmd.ExecuteNonQuery();
            return true;
        }
        //Error handling for database operations:
        catch (MySqlException)
        {
            Console.WriteLine("Database error occurred. Operation failed.");
            return false;
        }
    }

    //Retrieving all books from the database and mapping them to the appropriate book types:
    public Book[] GetAll()
    {
        var books = new List<Book>(); //Creating a list to hold the retrieved books
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            using var cmd = new MySqlCommand("SELECT * FROM books", conn);
            using var reader = cmd.ExecuteReader();  

            while (reader.Read())
            {
                int id = reader.GetInt32("id");
                string title = reader.GetString("title");
                string author = reader.GetString("author");
                string type = reader.GetString("type");

                Book book;
                switch (type)
                {
                    case "PHYSICAL":
                        book = new PhysicalBook(
                            title, author, id,
                            reader.GetInt32("pages"),
                            reader.GetInt32("available_copies"));
                        break;
                    case "DIGITAL":
                        book = new DigitalBook(
                            title, author, id,
                            reader.GetDouble("file_size_mb"),
                            reader.GetString("format"));
                        break;
                    case "AUDIO":
                        book = new AudioBook(
                            title, author, id,
                            reader.GetInt32("duration_minutes"),
                            reader.GetString("narrator"));
                        break;
                    default:
                        throw new InvalidOperationException($"Unknown type: {type}");
                }
                books.Add(book);
            }
        }
        //Error handling for database operations:
        catch (MySqlException)
        {
            Console.WriteLine("Database error occurred. Operation failed.");
        }
        return books.ToArray();
    }

    //Retrieving a single book by its ID and mapping it to the appropriate book type:
    public Book? GetById(int id)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            using var cmd = new MySqlCommand("SELECT * FROM books WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (!reader.Read()) return null;
            
            //Common parameters for all book types:
            string title = reader.GetString("title");
            string author = reader.GetString("author");
            string type = reader.GetString("type");
            
            //Type-specific parameters:
            switch (type)
            {
                case "PHYSICAL":
                    return new PhysicalBook(title, author, id,
                        reader.GetInt32("pages"), reader.GetInt32("available_copies"));
                case "DIGITAL":
                    return new DigitalBook(title, author, id,
                        reader.GetDouble("file_size_mb"), reader.GetString("format"));
                case "AUDIO":
                    return new AudioBook(title, author, id,
                        reader.GetInt32("duration_minutes"), reader.GetString("narrator"));
                default:
                    return null;
            }
        }
        //Error handling for database operations:
        catch (MySqlException)
        {
            Console.WriteLine("Database error occurred. Operation failed.");
            return null;
        }
    }

    //Updating a book's available copies for physical books:
    public bool Update(Book book)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            if (book is PhysicalBook pb)
            {
                using var cmd = new MySqlCommand(
                    "UPDATE books SET available_copies = @copies WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@copies", pb.GetAvailableCopies());
                cmd.Parameters.AddWithValue("@id", book.GetID());
                cmd.ExecuteNonQuery();
            }
            return true;
        }
        //Error handling for database operations:
        catch (MySqlException)
        {
            Console.WriteLine("Database error occurred. Operation failed.");
            return false;
        }
    }

    //Deleting a book by its ID:
    public bool Delete(int id)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            using var cmd = new MySqlCommand("DELETE FROM books WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            return true;
        }
        //Error handling for database operations:
        catch (MySqlException)
        {
            Console.WriteLine("Database error occurred. Operation failed.");
            return false;
        }
    }
}
