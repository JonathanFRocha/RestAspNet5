using Microsoft.EntityFrameworkCore;
using RestCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestPerson.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options):base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
