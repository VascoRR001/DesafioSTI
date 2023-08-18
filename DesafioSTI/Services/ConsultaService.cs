using DesafioSTI.Data;
using Microsoft.EntityFrameworkCore;


namespace DesafioSTI.Services
{
    public class ConsultaService
    {
        private readonly IDbContextFactory<DesafioDbContexto> _dbContextFactory;

        public ConsultaService(IDbContextFactory<DesafioDbContexto> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddConsulta(int doenteID, DateTime data, string especialidade)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var doente = context.Doentes.FirstOrDefault(d => d.ID == doenteID);

                if (doente == null)
                {
                    Console.WriteLine("Doente não encontrado.");
                    return;
                }

                var consulta = new Consulta
                {
                    Data = data,
                    Especialidade = especialidade,
                    Doente = doente
                };

                context.Consultas.Add(consulta);
                context.SaveChanges();
                Console.WriteLine("Consulta adicionada com sucesso.");
            }
        }
    }
}
