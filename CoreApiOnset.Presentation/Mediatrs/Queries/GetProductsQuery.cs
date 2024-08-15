using CoreApiOnset.Presentation.Data.Entities;
using MediatR;

namespace CoreApiOnset.Presentation.Mediatrs.Queries
{
    // mediatr 2. adım klasörleri oluşturma (mediatr, commands, queries, handlers)
    // mediatr 3. adım
    public class GetProductsQuery : IRequest<IEnumerable<Product>> // ıenumerable yerine list de yazılabilir.
    {
        // alacağı parametre varsa buraya yazılır.
    }
}
