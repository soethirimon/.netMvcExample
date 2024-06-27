using Microsoft.EntityFrameworkCore;
using MVCExample.Web.Features.Blog;
using MVCExample.Web.Features.Student;

namespace MVCExample.Web.EFDbContext;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<BlogDataModel> Blog { get; set; }

    public DbSet<StudentDataModel> Student { get; set; }
    
}