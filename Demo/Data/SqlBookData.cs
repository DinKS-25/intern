using Demo.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Data
{
    public class SqlBookData : IBookData
    {
        private readonly DemoDbContext db;

        public SqlBookData(DemoDbContext db)
        {
            this.db = db;
        }
        public Book Add(Book book)
        {
            db.Add(book);
            return (book);
        }

        public int commit()
        {
            return (db.SaveChanges());
        }

        public Book Delete(int id)
        {
            Book tempbook = GetById(id);
            if (tempbook!=null)
            {
                db.book.Remove(tempbook);
            }
            return (tempbook);
        }

        public IEnumerable<Book> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Book GetById(int id)
        {
            return (db.book.Find(id));
        }

        public IEnumerable<Book> Serach(string name)
        {
            var query = from r in db.book
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return (query);
        }

        public Book Update(Book book)
        {
            var entity = db.book.Attach(book);
            entity.State = EntityState.Modified;
            return (book);
        }
    }
}
