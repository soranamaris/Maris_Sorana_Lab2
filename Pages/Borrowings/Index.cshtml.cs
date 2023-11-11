using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Maris_Sorana_Lab2.Data;
using Maris_Sorana_Lab2.Models;

namespace Maris_Sorana_Lab2.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Maris_Sorana_Lab2.Data.Maris_Sorana_Lab2Context _context;

        public IndexModel(Maris_Sorana_Lab2.Data.Maris_Sorana_Lab2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Borrowing != null)
            {
                Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .Include(b => b.Member).ToListAsync();
            }
        }
    }
}
