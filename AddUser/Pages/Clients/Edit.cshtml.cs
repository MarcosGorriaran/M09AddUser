using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddUser.Data;
using AddUser.Models;

namespace AddUser.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly AddUser.Data.AddUserContext _context;

        public EditModel(AddUser.Data.AddUserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client =  await _context.Client.FirstOrDefaultAsync(m => m.DNI == id);
            if (client == null)
            {
                return NotFound();
            }
            Client = client;
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

            _context.Attach(Client).State = EntityState.Modified;
            Client.ModDate = DateTime.Now;
            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(Client.DNI))
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

        private bool ClientExists(string id)
        {
            return _context.Client.Any(e => e.DNI == id);
        }
    }
}
