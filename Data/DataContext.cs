using bookstore_management_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace bookstore_management_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }
        public DbSet<BookModels> Book { get; set; }
    }
}
