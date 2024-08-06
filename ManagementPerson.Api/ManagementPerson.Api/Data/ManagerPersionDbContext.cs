using ManagementPerson.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementPerson.Api.Data
{
    public class ManagerPersionDbContext : DbContext
    {
        public ManagerPersionDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                        .HasOne(p => p.Address)
                        .WithMany()
                        .HasForeignKey(p => p.AddressId);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var students = ChangeTracker.Entries<Student>().Where(e => e.State == EntityState.Added);

            foreach (var entry in students)
            {
                var student = entry.Entity;
                var maxStudentNumber = Students
                    .OrderByDescending(s => s.StudentNumber)
                    .FirstOrDefault()?.StudentNumber;

                if (maxStudentNumber == null)
                {
                    student.StudentNumber = "00001";
                }
                else
                {
                    var nextStudentNumber = int.Parse(maxStudentNumber) + 1;
                    student.StudentNumber = nextStudentNumber.ToString("D5");
                }
            }


            return base.SaveChanges();
        }
    }
}
