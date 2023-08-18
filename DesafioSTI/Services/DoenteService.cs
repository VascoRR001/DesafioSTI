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
        public void EditDoente(int id, Doente novoEstadoDoente)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var doenteExistente = context.Doentes.FirstOrDefault(d => d.ID == id);

                if (doenteExistente != null)
                {
                    
                    doenteExistente.NoDeProcesso = novoEstadoDoente.NoDeProcesso;
                    doenteExistente.Nome = novoEstadoDoente.Nome;
                    doenteExistente.DataNascimento = novoEstadoDoente.DataNascimento;
                    doenteExistente.Sexo = novoEstadoDoente.Sexo;

                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Doente não encontrado");
                }
            }
        }

        }
}
