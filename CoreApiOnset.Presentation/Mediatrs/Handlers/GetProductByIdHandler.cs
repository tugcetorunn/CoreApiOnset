using CoreApiOnset.Presentation.Data.Context;
using CoreApiOnset.Presentation.Data.Entities;
using CoreApiOnset.Presentation.Mediatrs.Queries;
using MediatR;

namespace CoreApiOnset.Presentation.Mediatrs.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly ApplicationDbContext context;
        public GetProductByIdHandler(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await context.Products.FindAsync(request.Id);
        }
    }
}
