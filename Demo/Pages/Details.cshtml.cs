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
    public class DetailsModel : PageModel
    {
        public DetailsModel(IBookData bookData)
        {
            this.bookData = bookData;
        }

        [TempData]
        public string message { get; set; }
        public Book book { get; set; }
        private readonly IBookData bookData;

        [BindProperty(SupportsGet = true)]
        public int bookId { get; set; }


        public IActionResult OnGet()
        {
            book = bookData.GetById(bookId);
            if (book == null)
            {
                return (RedirectToPage("./NotFound"));
            }
            else
            {
                return (Page());
            }
        }

        public IActionResult OnPost()
        {

            book = bookData.Delete(bookId);
            if (book == null)
            {
                return (RedirectToPage("./NotFound"));
            }
            else
            {
                bookData.commit();
                TempData["message"] = "record deleted";
                return (RedirectToPage("./BookDetails"));
            }
        }
    }
}
