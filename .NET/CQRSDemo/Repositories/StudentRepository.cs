
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.Repositories;

public class StudentRepository : IStudentRepository
{
    private MyDbContext _myDbContext;

    public StudentRepository(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    }

    public async Task<Student> AddAsync(Student t)
    {
        var result = _myDbContext.Students.Add(t);
        await _myDbContext.SaveChangesAsync();
        return result.Entity;
    }

    public Task<int> DeleteAsync(int Id)
    {
        return _myDbContext.Students.Where(c => c.Id == 1).ExecuteDeleteAsync();
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _myDbContext.Students.ToListAsync();
    }

    public async Task<Student> GetAsync(int Id)
    {
        var student = await _myDbContext.Students.Where(x => x.Id == Id).FirstOrDefaultAsync();
        return student ?? throw new ArgumentException();
    }

    public async Task<int> UpdateAsync(Student t)
    {
        _myDbContext.Students.Update(t);
        return await _myDbContext.SaveChangesAsync();
    }
}