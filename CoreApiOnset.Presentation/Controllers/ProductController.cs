using CoreApiOnset.Presentation.Data.Entities;
using CoreApiOnset.Presentation.Mediatrs.Commands;
using CoreApiOnset.Presentation.Mediatrs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// proje 3. adım (add comtroller - api - api controller empty)
namespace CoreApiOnset.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet] // mvc web projelerinde httpget (sadece get e özel) yazmasak da httpget olarak algılıyor fakat api da yazmak gerekiyor yoksa 500 hatası dönüyor.
        public async Task<IActionResult> GetProducts() // IActionResult -> Ok, Authorized, NotFound, BadRequest gibi dönüş türleri içerir.
        {
            // metodu çalıştıracak service kollarına ihtiyacımız var. bunun için önce mediatr yüklüyoruz.

            var request = new GetProductsQuery();
            var products = await mediator.Send(request);
            return Ok(products);

        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var newP = new CreateProductCommand() { Product = product };
            var res = await mediator.Send(newP);
            if (res > 0)
            {
                return Ok(product);
            }
            else 
            { 
                return BadRequest(); 
            }
            // guid nin otomatik oluşturulması için validator ekle... post request ekranına düşmesin.
        }

        [HttpGet("{id}")] 
        // bu metodu route suz yazdığımızda [httpget] program hata veriyor çünkü aynı controller içinde iki get metodu var metod isimlerine
        // bakmıyor. aralarındaki farkı göstermek için route eklememiz gerekiyor. iki benzer metodda parametreler farklı olduğu
        // için route u parametreye göre verebiliriz. route u httpget annotation ında veriyoruz.
        public async Task<IActionResult> GetProductById(Guid id) // [fromquery] ifadesini buraya verdiğimizde id girme alanı iki tane açılıyor.
        {                                                        // çünkü zaten [HttpGet("{id}")] burada parametre girme alanı açmış oluyoruz.
            var product = new GetProductByIdQuery() { Id = id };
            var res = await mediator.Send(product);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] Product product)
        {
            var newProduct = new UpdateProductCommand() { Product = product };
            var res = await mediator.Send(newProduct);

            if (res>0)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromQuery] Guid id)
        {
            var res = await mediator.Send(new DeleteProductCommand() { Id = id });

            if (res > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
} 
