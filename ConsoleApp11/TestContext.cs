using System.Data;
using System.Linq;
using ConsoleApp11.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp11
{
    public class TestContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PersonStudySubject> PersonsStudySubjects { get; set; }
        public DbSet<StudySubject> StudySubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne<Address>()
                .WithMany()
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<StudySubject>()
                .HasOne<University>()
                .WithMany()
                .HasForeignKey(x => x.UniversityId);

            modelBuilder.Entity<StudySubject>()
                .HasOne<Person>()
                .WithMany()
                .HasForeignKey(x => x.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PersonStudySubject>()
                .HasOne<Person>()
                .WithMany()
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<PersonStudySubject>()
                .HasOne<StudySubject>()
                .WithMany()
                .HasForeignKey(x => x.SubjectId);

            modelBuilder.Entity<PersonStudySubject>()
                .HasKey(x => new { x.StudentId, x.SubjectId });

            modelBuilder.Entity<University>()
                .HasOne<Address>()
                .WithMany()
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.SetNull);

            //seeding
            var addresses = Address.Generate(100).ToArray();

            var persons = Person.Generate(350, addresses.Select(x => x.Id).ToArray()).ToArray();
            var universities = University.Generate(5, addresses.Select(x => x.Id).ToArray()).ToArray();

            var subjects = StudySubject.Generate(25, universities.Select(x => x.Id).ToArray(),
                persons.Select(x => x.Id).ToArray()).ToArray();

            var personsSubjects = PersonStudySubject.Generate(200, subjects.Select(x => x.Id).ToArray(),
                    persons.Select(x => x.Id).ToArray()).Select(x => (x.StudentId, x.SubjectId)).ToHashSet()
                .Select(x => new PersonStudySubject() { StudentId = x.StudentId, SubjectId = x.SubjectId });

            modelBuilder.Entity<Address>().HasData(addresses);
            modelBuilder.Entity<Person>().HasData(persons);
            modelBuilder.Entity<University>().HasData(universities);
            modelBuilder.Entity<StudySubject>().HasData(subjects);
            modelBuilder.Entity<PersonStudySubject>().HasData(personsSubjects);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SqlPracticeDB;Trusted_Connection=True;");
        }
    }
}