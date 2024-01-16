using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMaster.Data;
using SchoolMaster.Models;

namespace SchoolMaster.Pages.StudentExams
{
    public class CreateModel : PageModel
    {
        private readonly SchoolMaster.Data.ApplicationDbContext _context;

        public CreateModel(SchoolMaster.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Exam"] = new SelectList(_context.Exams, "Id", "Name");
            ViewData["Student"] = new SelectList(_context.Students, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public StudentExam StudentExam { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StudentExams.Add(StudentExam);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
