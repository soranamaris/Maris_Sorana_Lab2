using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Maris_Sorana_Lab2.Data;
using Maris_Sorana_Lab2.Models;
using Maris_Sorana_Lab2.Models.ViewModels;

namespace Maris_Sorana_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Maris_Sorana_Lab2.Data.Maris_Sorana_Lab2Context _context;

        public IndexModel(Maris_Sorana_Lab2.Data.Maris_Sorana_Lab2Context context)
        {
            _context = context;
        }

        public IEnumerable<Book> books;
        public IList<Category> Category { get; set; } = default!;
        public CategoryIndexData CategoriesData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        { 
            
            books = new List<Book>();

            CategoriesData = new CategoryIndexData();
            CategoriesData.Categories = await _context.Category
            .Include(i => i.BookCategories)
            .ThenInclude(i => i.Book)
            .ThenInclude(c => c.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();
            
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoriesData.Categories.Where(i => i.ID == id.Value).Single();
                CategoriesData.BookCategories = category.BookCategories;
                foreach(BookCategory bookCategory in CategoriesData.BookCategories)
                {
                    Book book = bookCategory.Book;
                    books.Append(book);
                }
                CategoriesData.Books = books;
            }

        }
    }
}
