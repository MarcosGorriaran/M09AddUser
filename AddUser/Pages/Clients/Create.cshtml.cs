using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AddUser.Data;
using AddUser.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AddUser.Pages.Clients
{
    public class CreateModel : PageModel
    {
        const string ErrorDuplicateKey = "There is another client with the same DNI";
        private readonly AddUser.Data.AddUserContext _context;
        public string ErrorMsg { get; set; }

        private CreateModel(AddUser.Data.AddUserContext context, string errorMsg)
        {
            _context = context;
            ErrorMsg = errorMsg;
        }
        public CreateModel(AddUser.Data.AddUserContext context):this(context,string.Empty) { }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Client.Add(Client);
            try
            {
                await _context.SaveChangesAsync();
                ErrorMsg = string.Empty;
            }
            catch(DbUpdateException error)
            {
                ErrorMsg = ErrorDuplicateKey;
                
                return Page();
            }
            
            

            return RedirectToPage("./Index");
        }
    }
}
