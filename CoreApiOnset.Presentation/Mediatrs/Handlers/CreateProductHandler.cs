using CoreApiOnset.Presentation.Data.Context;
using CoreApiOnset.Presentation.Data.Entities;
using CoreApiOnset.Presentation.Mediatrs.Commands;
using MediatR;

namespace CoreApiOnset.Presentation.Mediatrs.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly ApplicationDbContext context;
        public CreateProductHandler(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            context.Products.Add(request.Product);
            var affectedRows = await context.SaveChangesAsync(cancellationToken);
            return affectedRows;
        }
    }
}
