using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Core;
using Demo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages
{
    public class BookDetailsModel : PageModel
    {
        private readonly IBookData bookData;

        [TempData]
        public string message { get; set; }

        [BindProperty(SupportsGet = true)]
        public string bookName { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public BookDetailsModel(IBookData bookData)
        {
            this.bookData = bookData;
        }

        public void OnGet()
        {
            Books = bookData.Serach(bookName);
        }
    }
}
