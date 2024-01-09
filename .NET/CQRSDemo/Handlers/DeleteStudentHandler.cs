using CQRSDemo.Commands;
using CQRSDemo.Repositories;
using MediatR;

namespace CQRSDemo.Handlers;

public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
{
    private readonly IStudentRepository _studentRepository;

    public DeleteStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<int> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
    {
        var studentDetails = await _studentRepository.GetAsync(command.Id);
        if (studentDetails == null)
            return default;

        return await _studentRepository.DeleteAsync(command.Id);
    }
}