using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MergeRequestService.Models;

namespace MergeRequestService.Models
{
    public class MergeRequestContext : IdentityDbContext
    {
        public MergeRequestContext(DbContextOptions<MergeRequestContext> options)
            : base(options)
        {
        }

        public DbSet<MergeRequest> MergeRequests { get; set; }

        public DbSet<MergeRequestService.Models.MergeRequestMail> MergeRequestMail { get; set; }
    }
}