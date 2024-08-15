using CoreApiOnset.Presentation.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// proje 1. adým
builder.Services.AddControllers();

// swagger 1. adým swashbuckle ýn nugetten yüklenmesi
// swagger 2. adým
builder.Services.AddEndpointsApiExplorer(); // api endpointlerimizin swagger aracýlýðýyla keþfedilmesini saðlar.
builder.Services.AddSwaggerGen(); // swagger belgelerini (json) otomatik oluþturur ve swagger kullanýcý arayüzünü saðlar.

// in memory db 2. adým dbcontext in tetikleneceði kod yazýlýr. (In  memory db ve ef core entegration)
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("ECommerceDb"));

// mediatr 5. adým mediatr ýn sisteme entegre edilmesi
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(Program).Assembly)); // program içerisindeki tüm handler larý
                                                                                              // kayýt etmiþ oluyoruz.
var app = builder.Build();

// proje 2. adým
app.MapControllers();

// swagger 3. adým
if (app.Environment.IsDevelopment()) // debug : localde çalýþtýðýmýzý gösterir. (IsDevelopment)
{                                    // release : kodu sunucuya publish ettiðimizi ve artýk kodumuzun production ortamda çalýþtýðýný gösterir. (IsProduction)
    app.UseSwagger(); // apilerin yaptýðý iþlemleri ve bu iþlemlerin nasýl kullanýlacaðýný açýklayan metodlardýr.
    app.UseSwaggerUI(); // apilerin görsel ayarlamalarýný aktif eder.
}

app.Run();
