using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolMaster.Data;
using SchoolMaster.Models;

namespace SchoolMaster.Pages.StudentExams
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolMaster.Data.ApplicationDbContext _context;

        public DetailsModel(SchoolMaster.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public StudentExam StudentExam { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentexam = await _context.StudentExams
                .Include(s => s.Exam)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentexam == null)
            {
                return NotFound();
            }
            else
            {
                StudentExam = studentexam;
            }
            return Page();
        }
    }
}
