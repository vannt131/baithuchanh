using Microsoft.EntityFrameworkCore;

namespace ThucHanh.Models
{
    public class ThucHanhDbContext : DbContext 
    {
        public ThucHanhDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Exam> Exams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                StudentId = 1,
                Name = "Nghiêm Thị Vân",
                DateOfBirth = DateTime.Parse("01/13/2002"),
                Email = "nghjemthjvan@gmail.com",
                Address = "Yên Xá, Tân Triều, Thanh Trì, Hà Nội"
            });
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                StudentId = 2,
                Name = "Lã Thị Phương Thảo",
                DateOfBirth = DateTime.Parse("05/21/1996"),
                Email = "laphuongthao123@gmail.com",
                Address = "Trạch Xá, Hòa Lâm, Ứng Hòa, Hà Nội"
            });
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                StudentId = 3,
                Name = "Nguyễn Thúy Nga",
                DateOfBirth = DateTime.Parse("11/01/2001"),
                Email = "nganguyen2k1@gmail.com",
                Address = "Hùng Lô, Việt Trì, Phú Thọ"
            });

            modelBuilder.Entity<Subject>().HasData(new Subject()
            {
                SubjectId = 1,
                SubjectName = "Tin học văn phòng",
                SubjectCode = "MON001",
                Description = "Môn tin học văn phòng",
                StartDate = DateTime.Parse("11/01/2022"),
                EndDate = DateTime.Parse("12/01/2022")
            });
            modelBuilder.Entity<Subject>().HasData(new Subject()
            {
                SubjectId = 2,
                SubjectName = "Toán cao cấp",
                SubjectCode = "MON002",
                Description = "Mô tả môn toán cao cấp",
                StartDate = DateTime.Parse("12/01/2022"),
                EndDate = DateTime.Parse("12/31/2022")
            });
            modelBuilder.Entity<Subject>().HasData(new Subject()
            {
                SubjectId = 3,
                SubjectName = "Triết học Mac-Lenin",
                SubjectCode = "MON003",
                Description = "Mô tả Triết học Mác Lê-nin",
                StartDate = DateTime.Parse("01/01/2023"),
                EndDate = DateTime.Parse("02/05/2023")
            });
        }
    }
}
