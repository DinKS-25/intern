using Demo.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Data
{
    public interface IBookData
    {
        IEnumerable<Book> GetAll();

        Book GetById(int id);

        IEnumerable<Book> Serach(string name);

        Book Update(Book book);

        Book Add(Book book);

        Book Delete(int id);

        int commit();
    }
}
