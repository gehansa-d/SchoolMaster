using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolMaster.Data;
using SchoolMaster.Models;

namespace SchoolMaster.Pages.Exams
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolMaster.Data.ApplicationDbContext _context;

        public DetailsModel(SchoolMaster.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Exam Exam { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams.FirstOrDefaultAsync(m => m.Id == id);
            if (exam == null)
            {
                return NotFound();
            }
            else
            {
                Exam = exam;
            }
            return Page();
        }
    }
}
