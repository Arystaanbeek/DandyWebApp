using Microsoft.EntityFrameworkCore;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<UserModel> Users { get; set; } = null!;
}
