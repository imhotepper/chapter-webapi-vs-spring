using Microsoft.EntityFrameworkCore;

namespace api.Model
{
    public class AppDb: DbContext
    {
        public AppDb(DbContextOptions<AppDb> options): base(options){}

        public DbSet<Todo> Todos { get; set; }
    }
}