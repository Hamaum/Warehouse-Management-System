using Microsoft.EntityFrameworkCore;
using Warehouse.Api.Models; // Importing the models namespace

namespace Warehouse.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // List of database tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WarehouseTask> Tasks { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Attendance> Attendances { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Отключаем каскадное удаление: User -> WarehouseTask
            modelBuilder.Entity<WarehouseTask>()
                .HasOne(t => t.CreatedByUser)
                .WithMany() // Если у User нет коллекции задач, оставляем пустым
                .HasForeignKey(t => t.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict); // Запрещаем каскадное удаление

            // Отключаем каскадное удаление: User -> WorkLog (тоже может вызвать цикл)
            modelBuilder.Entity<WorkLog>()
                .HasOne(w => w.User)
                .WithMany()
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}