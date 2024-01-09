using CQRSDemo.Commands;
using CQRSDemo.Quries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers;


[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator mediator;

    public StudentsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<Student>> GetStudentListAsync()
    {
        var Student = await mediator.Send(new GetStudentListQuery());

        return Student;
    }

    [HttpGet("studentId")]
    public async Task<Student> GetStudentByIdAsync(int studentId)
    {
        var Student = await mediator.Send(new GetStudentByIdQuery() { Id = studentId });

        return Student;
    }

    [HttpPost]
    public async Task<Student> AddStudentAsync(Student Student)
    {
        var studentDetail = await mediator.Send(new CreateStudentCommand(
            Student.StudentName,
            Student.StudentEmail,
            Student.StudentAddress,
            Student.StudentAge));
        return studentDetail;
    }

    [HttpPut]
    public async Task<int> UpdateStudentAsync(Student Student)
    {
        var isStudentDetailUpdated = await mediator.Send(new UpdateStudentCommand(
           Student.Id,
           Student.StudentName,
           Student.StudentEmail,
           Student.StudentAddress,
           Student.StudentAge));
        return isStudentDetailUpdated;
    }

    [HttpDelete]
    public async Task<int> DeleteStudentAsync(int Id)
    {
        return await mediator.Send(new DeleteStudentCommand() { Id = Id });
    }
}