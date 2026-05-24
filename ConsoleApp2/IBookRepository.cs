//Interface for book repository:
public interface IBookRepository
{
    bool Add(Book book);
    Book? GetById(int id);
    Book[] GetAll();
    bool Update(Book book);
    bool Delete(int id);
}
