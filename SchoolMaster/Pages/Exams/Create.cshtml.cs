using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMaster.Data;
using SchoolMaster.Models;

namespace SchoolMaster.Pages.Exams
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
            ViewData["Classes"] = new SelectList(_context.Classes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Exam Exam { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Exams.Add(Exam);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
