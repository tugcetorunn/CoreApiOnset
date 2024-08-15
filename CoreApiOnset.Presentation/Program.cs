using CoreApiOnset.Presentation.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// proje 1. ad�m
builder.Services.AddControllers();

// swagger 1. ad�m swashbuckle �n nugetten y�klenmesi
// swagger 2. ad�m
builder.Services.AddEndpointsApiExplorer(); // api endpointlerimizin swagger arac�l���yla ke�fedilmesini sa�lar.
builder.Services.AddSwaggerGen(); // swagger belgelerini (json) otomatik olu�turur ve swagger kullan�c� aray�z�n� sa�lar.

// in memory db 2. ad�m dbcontext in tetiklenece�i kod yaz�l�r. (In  memory db ve ef core entegration)
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("ECommerceDb"));

// mediatr 5. ad�m mediatr �n sisteme entegre edilmesi
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(Program).Assembly)); // program i�erisindeki t�m handler lar�
                                                                                              // kay�t etmi� oluyoruz.
var app = builder.Build();

// proje 2. ad�m
app.MapControllers();

// swagger 3. ad�m
if (app.Environment.IsDevelopment()) // debug : localde �al��t���m�z� g�sterir. (IsDevelopment)
{                                    // release : kodu sunucuya publish etti�imizi ve art�k kodumuzun production ortamda �al��t���n� g�sterir. (IsProduction)
    app.UseSwagger(); // apilerin yapt��� i�lemleri ve bu i�lemlerin nas�l kullan�laca��n� a��klayan metodlard�r.
    app.UseSwaggerUI(); // apilerin g�rsel ayarlamalar�n� aktif eder.
}

app.Run();
