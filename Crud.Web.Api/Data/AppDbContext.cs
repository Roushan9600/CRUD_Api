using Crud.Web.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Web.Api.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {
        }

        public DbSet<Users> Users { get; set; }
    }
}
