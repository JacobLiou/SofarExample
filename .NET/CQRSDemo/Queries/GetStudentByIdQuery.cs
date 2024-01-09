using MediatR;

namespace CQRSDemo.Quries;

public class GetStudentByIdQuery : IRequest<Student>
{
    public int Id { get; set; }
}