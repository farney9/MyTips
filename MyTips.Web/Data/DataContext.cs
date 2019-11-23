using Microsoft.EntityFrameworkCore;
using MyTips.Web.Data.Entities;

namespace MyTips.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Tip> Tips { get; set; }
    }
}
