using Demo.Core;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Data
{
    public class InMemoryBooks : IBookData
    {
        private readonly List<Book> books;

        public InMemoryBooks()
        {
            books = new List<Book>()
            {
                new Book{Id = 1,Name = "C# int nutshell",Description="description about the book",Price = 123.32},
                new Book{Id = 2,Name = "data structures",Description="description about the book",Price = 21.32},
                new Book{Id = 3,Name = "Learn sql",Description="description about the book",Price = 25.23}
            };
        }

        public Book Add(Book book)
        {
            book.Id = books.Max(ele => ele.Id)+1;
            books.Add(book);
            return (book);
        }

        public int commit()
        {
            return 0;
        }

        public Book Delete(int bookId)
        {

            Book tempBook = books.SingleOrDefault(ele => ele.Id == bookId);
            if (tempBook != null)
            {
                books.Remove(tempBook);
            }
            return (tempBook);
        }

        public IEnumerable<Book> GetAll()
        {
            return (
                from r in books
                orderby r.Name
                select r
                    );
        }

        public Book GetById(int id)
        {
            return books.Find(item => item.Id == id);
        }

        public IEnumerable<Book> Serach(string name = null)
        {
            return (from r in books
                    where  string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                    orderby r.Name
                    select r
                );
        }

        public Book Update(Book book)
        {
            Book Lbook = books.SingleOrDefault(ele => ele.Id == book.Id);
            if(Lbook != null){
                Lbook.Name = book.Name;
                Lbook.Description = book.Description;
                Lbook.Price = book.Price;
            }
            
                return (Lbook);
            
            
        }
    }
}
