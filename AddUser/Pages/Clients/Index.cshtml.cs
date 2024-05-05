using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AddUser.Data;
using AddUser.Models;

namespace AddUser.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly AddUser.Data.AddUserContext _context;

        public IndexModel(AddUser.Data.AddUserContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Client = await _context.Client.ToListAsync();
        }
    }
}
