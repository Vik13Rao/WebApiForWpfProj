using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Context
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
