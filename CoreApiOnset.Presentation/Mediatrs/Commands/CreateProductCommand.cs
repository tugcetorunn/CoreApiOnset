using CoreApiOnset.Presentation.Data.Entities;
using MediatR;

namespace CoreApiOnset.Presentation.Mediatrs.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public Product Product { get; set; }
    }
}
