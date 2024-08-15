using CoreApiOnset.Presentation.Data.Entities;
using MediatR;

namespace CoreApiOnset.Presentation.Mediatrs.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }    
    }
}
