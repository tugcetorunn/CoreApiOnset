using CoreApiOnset.Presentation.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreApiOnset.Presentation.Data.Context
{
    // in memory db 1. adım dbcontext class ı oluşturuldu. ef core yüklendi. context dolduruldu. (db set, constructor)
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // ne zaman bu context i çağırırsak hangi
                                                                                                    // database e ne ile bağlanacağımızın bilgi
                                                                                                    // sini tutan "options" base e gönderir.
                                                                                                    // bunu yazdığımızda context dışardan set
                                                                                                    // edilebilir, inject edilebilir oluyor.
                                                                                                    // örn. program.cs den connection string
                                                                                                    // bilgisini verip bu constructor la base e 
                                                                                                    // bu bilgiyi taşıyabiliyoruz. bu configuration
                                                                                                    // constructor ını oluşturduktan sonra da 
                                                                                                    // tanımladığımız options değişkenini bir yerde
                                                                                                    // gönderip db yi konfigüre etmeliyiz.
        {
            
        }
    }
}
