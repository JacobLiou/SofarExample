using CQRSDemo.Commands;
using CQRSDemo.Repositories;
using MediatR;

namespace CQRSDemo.Handlers;

public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
{
    private readonly IStudentRepository _studentRepository;

    public UpdateStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
    {
        var studentDetails = await _studentRepository.GetAsync(command.Id);
        if (studentDetails == null)
            return default;

        studentDetails.StudentName = command.StudentName;
        studentDetails.StudentEmail = command.StudentEmail;
        studentDetails.StudentAddress = command.StudentAddress;
        studentDetails.StudentAge = command.StudentAge;

        return await _studentRepository.UpdateAsync(studentDetails);
    }
}