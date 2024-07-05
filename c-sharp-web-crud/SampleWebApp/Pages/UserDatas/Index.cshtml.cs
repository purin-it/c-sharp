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
    public class IndexModel : PageModel
    {
        private readonly SampleWebApp.Data.SampleWebAppContext _context;

        public IndexModel(SampleWebApp.Data.SampleWebAppContext context)
        {
            _context = context;
        }

        public IList<User_Data> User_Data { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User_Data = await _context.User_Data.ToListAsync();
        }
    }
}
