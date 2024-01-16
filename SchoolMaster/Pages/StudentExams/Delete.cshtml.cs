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
    public class DeleteModel : PageModel
    {
        private readonly SchoolMaster.Data.ApplicationDbContext _context;

        public DeleteModel(SchoolMaster.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentExam StudentExam { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentexam = await _context.StudentExams.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentexam = await _context.StudentExams.FindAsync(id);
            if (studentexam != null)
            {
                StudentExam = studentexam;
                _context.StudentExams.Remove(StudentExam);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
