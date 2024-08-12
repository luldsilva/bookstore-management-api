using bookstore_management_api.Enum;

namespace bookstore_management_api.Models
{
    public class BookGenre
    {
        public GenreType Genre { get; private set; }

        public BookGenre(GenreType genre)
        {
            Genre = genre;
        }

        public override string ToString()
        {
            return Genre.ToString();
        }
    }
}
