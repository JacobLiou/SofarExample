using CQRSDemo.Quries;
using CQRSDemo.Repositories;
using MediatR;

namespace CQRSDemo.Handlers;

public class GetStudentListHandler : IRequestHandler<GetStudentListQuery,List<Student>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentListHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<List<Student>> Handle(GetStudentListQuery query, CancellationToken cancellationToken)
    {
        return await _studentRepository.GetAllAsync();
    }
}