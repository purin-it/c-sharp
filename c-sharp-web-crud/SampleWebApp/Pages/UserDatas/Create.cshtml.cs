using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleWebApp.Data;
using SampleWebApp.Models;

namespace SampleWebApp.Pages.UserDatas
{
    public class CreateModel : PageModel
    {
        private readonly SampleWebApp.Data.SampleWebAppContext _context;

        public CreateModel(SampleWebApp.Data.SampleWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User_Data User_Data { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.User_Data.Add(User_Data);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
