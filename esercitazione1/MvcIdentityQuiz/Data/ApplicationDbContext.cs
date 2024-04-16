using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MvcIdentityQuiz.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
{
	base.OnModelCreating(builder);

	builder.Entity<AppUser>(entity =>
	{

		entity.Property(e => e.Stato)
			.HasColumnName("Stato");
	});
}
}
