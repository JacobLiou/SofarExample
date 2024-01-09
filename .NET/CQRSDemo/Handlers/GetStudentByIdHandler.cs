using CQRSDemo.Quries;
using CQRSDemo.Repositories;
using MediatR;

namespace CQRSDemo.Handlers; 
 
 public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetAsync(query.Id);
        }
    }