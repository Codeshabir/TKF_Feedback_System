using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tkf_Complaint_System.Areas.Identity.Data;

namespace Tkf_Complaint_System.Data;

public class Tkf_Complaint_SystemContext : IdentityDbContext<Tkf_Complaint_SystemUser>
{
    public Tkf_Complaint_SystemContext(DbContextOptions<Tkf_Complaint_SystemContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
