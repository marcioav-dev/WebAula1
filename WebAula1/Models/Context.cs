using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAula1.Models
{
    public class Context : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public Context(DbContextOptions<Context> opcoes) : base(opcoes)
        {

        }
    }
}
