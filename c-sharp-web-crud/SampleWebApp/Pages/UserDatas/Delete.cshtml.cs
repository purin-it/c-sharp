using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Data;
using SampleWebApp.Models;

namespace SampleWebApp.Pages.UserDatas
{
    public class DeleteModel : PageModel
    {
        private readonly SampleWebApp.Data.SampleWebAppContext _context;

        public DeleteModel(SampleWebApp.Data.SampleWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User_Data User_Data { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_data = await _context.User_Data.FirstOrDefaultAsync(m => m.Id == id);

            if (user_data == null)
            {
                return NotFound();
            }
            else
            {
                User_Data = user_data;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_data = await _context.User_Data.FindAsync(id);
            if (user_data != null)
            {
                User_Data = user_data;
                _context.User_Data.Remove(User_Data);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
