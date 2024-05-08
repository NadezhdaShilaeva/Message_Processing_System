using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Subordinate> Subordinates { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<MessageSource> MessageSources { get; set; }
        public DbSet<EmailSource> EmailSources { get; set; }
        public DbSet<PhoneSource> PhoneSources { get; set; }
        public DbSet<MessengerSource> MessengerSources { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<EmailMessage> EmailMessages { get; set; }
        public DbSet<PhoneMessage> PhoneMessages { get; set; }
        public DbSet<MessengerMessage> MessengerMessages { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(builder =>
            {
                builder.HasMany(x => x.Accounts).WithMany(x => x.Employees);
            });

            modelBuilder.Entity<Manager>(builder =>
            {
                builder.HasMany(x => x.Accounts);
                builder.HasMany(x => x.Subordinates);
            });

            modelBuilder.Entity<Subordinate>(builder =>
            {
                builder.HasMany(x => x.Accounts);
            });

            modelBuilder.Entity<Account>(builder =>
            {
                builder.HasMany(x => x.Employees).WithMany(x => x.Accounts);
                builder.HasMany(x => x.MessageSources).WithMany(x => x.Accounts);
                builder.HasMany(x => x.Reports);
            });

            modelBuilder.Entity<MessageSource>(builder =>
            {
                builder.HasMany(x => x.Accounts).WithMany(x => x.MessageSources);
            });

            modelBuilder.Entity<EmailSource>(builder =>
            {
                builder.HasMany(x => x.Accounts);
                builder.HasMany(x => x.EmailMessages);
            });

            modelBuilder.Entity<PhoneSource>(builder =>
            {
                builder.HasMany(x => x.Accounts);
                builder.HasMany(x => x.PhoneMessages);
            });

            modelBuilder.Entity<MessengerSource>(builder =>
            {
                builder.HasMany(x => x.Accounts);
                builder.HasMany(x => x.MessengerMessages);
            });
        }
    }
}
