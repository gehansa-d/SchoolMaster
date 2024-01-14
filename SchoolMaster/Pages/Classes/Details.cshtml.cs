using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolMaster.Data;
using SchoolMaster.Models;

namespace SchoolMaster.Pages.Classes
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolMaster.Data.ApplicationDbContext _context;

        public DetailsModel(SchoolMaster.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Class Class { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _class = await _context.Classes.FirstOrDefaultAsync(m => m.Id == id);
            if (_class == null)
            {
                return NotFound();
            }
            else
            {
                Class = _class;
            }
            return Page();
        }
    }
}
