using CoreApiOnset.Presentation.Data.Context;
using CoreApiOnset.Presentation.Data.Entities;
using CoreApiOnset.Presentation.Mediatrs.Commands;
using MediatR;

namespace CoreApiOnset.Presentation.Mediatrs.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly ApplicationDbContext context;
        public UpdateProductHandler(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            context.Products.Update(request.Product);
            var res = await context.SaveChangesAsync(cancellationToken);
            return res;
        }
    }
}
