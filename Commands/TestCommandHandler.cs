using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace backend.Commands
{
    public class TestCommandHandler : IRequestHandler<TestCommand, int>
    {
        public Task<int> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(13);
        }
    }
}