using CoreApiOnset.Presentation.Data.Context;
using CoreApiOnset.Presentation.Mediatrs.Commands;
using MediatR;

namespace CoreApiOnset.Presentation.Mediatrs.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly ApplicationDbContext context;
        public DeleteProductHandler(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.Id);

            var affectedRow = 0;
            if (product != null)
            {
                context.Products.Remove(product);
                affectedRow = await context.SaveChangesAsync();
            }

            return affectedRow;
        }
    }
}
