using MediatR;

namespace CQRSDemo.Quries;

public class GetStudentListQuery : IRequest<List<Student>>
{
    
}