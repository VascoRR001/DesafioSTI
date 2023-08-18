using DesafioSTI.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioSTI.Services
{
    public class DoenteService
    {
        private IDbContextFactory<DesafioDbContexto> dbContextFactory;

        public DoenteService(IDbContextFactory<DesafioDbContexto> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public void AddDoente(Doente doente)
        {
            using(var context = dbContextFactory.CreateDbContext())
            {
                
                context.Doentes.Add(doente);
                context.SaveChanges();
            }
        }

    }
}
