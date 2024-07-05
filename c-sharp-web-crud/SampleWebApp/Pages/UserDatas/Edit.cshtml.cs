using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Data;
using SampleWebApp.Models;

namespace SampleWebApp.Pages.UserDatas
{
    public class EditModel : PageModel
    {
        private readonly SampleWebApp.Data.SampleWebAppContext _context;

        public EditModel(SampleWebApp.Data.SampleWebAppContext context)
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

            var user_data =  await _context.User_Data.FirstOrDefaultAsync(m => m.Id == id);
            if (user_data == null)
            {
                return NotFound();
            }
            User_Data = user_data;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(User_Data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_DataExists(User_Data.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool User_DataExists(int id)
        {
            return _context.User_Data.Any(e => e.Id == id);
        }
    }
}
