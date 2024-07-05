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
    public class DetailsModel : PageModel
    {
        private readonly SampleWebApp.Data.SampleWebAppContext _context;

        public DetailsModel(SampleWebApp.Data.SampleWebAppContext context)
        {
            _context = context;
        }

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
    }
}
