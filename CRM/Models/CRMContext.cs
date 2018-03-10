using Microsoft.EntityFrameworkCore;

namespace CRM.Models
{
    public class CRMContext : DbContext
    {
        public CRMContext (DbContextOptions<CRMContext> options)
            : base(options)
        {
        }

        public DbSet<CRM.Models.Usuario> Usuario { get; set; }
          public DbSet<CRM.Models.Cliente> Cliente { get; set; }
            public DbSet<CRM.Models.Contacto> Contacto { get; set; }
              public DbSet<CRM.Models.Reunion> Reunion { get; set; }
                public DbSet<CRM.Models.Ticket> Ticket { get; set; }
    }
}