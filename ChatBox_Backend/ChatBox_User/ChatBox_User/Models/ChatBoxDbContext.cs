using Microsoft.EntityFrameworkCore;
using ChatBox_User.Models.Entities;

namespace ChatBox_User.Models
{
    public class ChatBoxDbContext : DbContext
    {
        // Code First Migration 資料庫 context
        public ChatBoxDbContext(DbContextOptions<ChatBoxDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<EmailLog> EmailLogs { get; set; }
        public DbSet<ResetToken> ResetTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 確保不會有重複的 email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
