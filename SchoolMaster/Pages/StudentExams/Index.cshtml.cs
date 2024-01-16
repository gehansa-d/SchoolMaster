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
    public class IndexModel : PageModel
    {
        private readonly SchoolMaster.Data.ApplicationDbContext _context;

        public IndexModel(SchoolMaster.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<StudentExam> StudentExam { get;set; } = default!;

        public async Task OnGetAsync()
        {
            StudentExam = await _context.StudentExams
                .Include(s => s.Exam)
                .Include(s => s.Student).ToListAsync();
        }
    }
}
