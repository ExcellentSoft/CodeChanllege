using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAPI.Model
{
    public class RegisterContext : DbContext
    {
        public RegisterContext() { }
        

        public RegisterContext(DbContextOptions<RegisterContext> options) : base(options)
        { }
        public DbSet<Usertb> Usertbs { get; set; }
    }
}
