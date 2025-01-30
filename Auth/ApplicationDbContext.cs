using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Auth
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ToDoLists> ToDoLists { get; set; }
        public DbSet<TaskLists> TaskLists { get; set; }
        public DbSet<AssignedTask> AssignedTasks { get; set; }
        public DbSet<DeletedTask> DeletedTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // AssignToUserId and AssignedByAdminId foreign keys without cascade delete
            builder.Entity<AssignedTask>()
                .HasOne(a => a.AssignedByAdmin)
                .WithMany()
                .HasForeignKey(a => a.AssignedByAdminId)
                .OnDelete(DeleteBehavior.Restrict);  // No cascade

            builder.Entity<AssignedTask>()
                .HasOne(a => a.AssignedToUser)
                .WithMany()
                .HasForeignKey(a => a.AssignedToUserId)
                .OnDelete(DeleteBehavior.Restrict);  // No cascade

            // No cascading delete for ListId and UserId
            builder.Entity<TaskLists>()
                .HasOne(t => t.ToDoLists)
                .WithMany(l => l.TaskLists)
                .HasForeignKey(t => t.ListId)
                .OnDelete(DeleteBehavior.Restrict);  // No cascade delete

            builder.Entity<TaskLists>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);  // No cascade delete
        }
    }




}
