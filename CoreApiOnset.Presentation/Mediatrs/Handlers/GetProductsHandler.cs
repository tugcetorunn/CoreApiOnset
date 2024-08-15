using CoreApiOnset.Presentation.Data.Context;
using CoreApiOnset.Presentation.Data.Entities;
using CoreApiOnset.Presentation.Mediatrs.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreApiOnset.Presentation.Mediatrs.Handlers
{
    // mediatr 4. adım
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly ApplicationDbContext context;
        public GetProductsHandler(ApplicationDbContext _context)
        {
            context = _context;
        }
        // miras aldığımız IRequestHandler bu implementasyonu otomatik yapıyor.
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {                                                                        // cancellation token : bu işlemler web de sıkıntı çıkartırsa
                                                                                 // işlemi iptal ediyor.
            return await context.Products.ToListAsync();
        }
    }
}

// IRequestHandler<TRequest, TResponse>
// public class GetProductsQuery : IRequest<IEnumerable<Product>> diye yazdığımız yer;
// GetProductsQuery       : Request   (giren)
// IEnumerable<Product>   : Response  (çıkan)
