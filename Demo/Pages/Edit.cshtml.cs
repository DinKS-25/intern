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
    public class EditModel : PageModel
    {
        private readonly IBookData bookData;

        [BindProperty]
        public Book book { get; set; }

        public EditModel(IBookData bookData)
        {
            this.bookData = bookData;
        }
        public void OnGet(int? bookId)
        {
            if (bookId.HasValue)
            {
                book = bookData.GetById(bookId.Value);
            }
            else
            {
                book = new Book();
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (book.Id == 0)
                {
                    bookData.Add(book);
                    TempData["message"] = "Book Added";
                    bookData.commit();
                }

                else
                {
                    bookData.Update(book);
                    TempData["message"] = "Book Updated";
                    bookData.commit();
                }
                return (RedirectToPage("./Details",new { bookId = book.Id}));
            }
            else
            {
                return (Page());
            }
        }
    }
}
