using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AddUser.Models;

namespace AddUser.Data
{
    public class AddUserContext : DbContext
    {
        public AddUserContext (DbContextOptions<AddUserContext> options)
            : base(options)
        {
        }

        public DbSet<AddUser.Models.Client> Client { get; set; } = default!;
    }
}
