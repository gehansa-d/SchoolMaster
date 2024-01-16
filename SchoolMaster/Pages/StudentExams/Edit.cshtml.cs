using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMaster.Data;
using SchoolMaster.Models;

namespace SchoolMaster.Pages.StudentExams
{
    public class EditModel : PageModel
    {
        private readonly SchoolMaster.Data.ApplicationDbContext _context;

        public EditModel(SchoolMaster.Data.ApplicationDbContext context)
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

            var studentexam =  await _context.StudentExams.FirstOrDefaultAsync(m => m.Id == id);
            if (studentexam == null)
            {
                return NotFound();
            }
            StudentExam = studentexam;
           ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id");
           ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
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

            _context.Attach(StudentExam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExamExists(StudentExam.Id))
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

        private bool StudentExamExists(int id)
        {
            return _context.StudentExams.Any(e => e.Id == id);
        }
    }
}
