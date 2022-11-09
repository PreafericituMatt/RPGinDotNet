using Microsoft.EntityFrameworkCore;
using RPGinDotNet.Models;

namespace RPGinDotNet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Character> Characters { get; set; }
    }
}
