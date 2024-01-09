using Microsoft.EntityFrameworkCore;

namespace CQRSDemo;

public class MyDbContext : DbContext
{
    //private readonly IConfiguration _configuration;
    //public MyDbContext(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //}

    public MyDbContext()
    {
        
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
    : base(options)
    { }

    public DbSet<Student> Students { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    // base.OnConfiguring(optionsBuilder);
    //    //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    //}
}

public class Student
{
    public int Id { get; set; }
    public string? StudentName { get; set; }
    public string? StudentEmail { get; set; }
    public string? StudentAddress { get; set; }
    public int StudentAge { get; set; }
}