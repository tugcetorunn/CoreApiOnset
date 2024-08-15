using MediatR;

namespace CoreApiOnset.Presentation.Mediatrs.Commands
{
    public class DeleteProductCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
