using DesafioSTI.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioSTI.Services
{
    public class DoenteConsultaService
    {
        private readonly IDbContextFactory<DesafioDbContexto> _dbContextFactory;

        public DoenteConsultaService(IDbContextFactory<DesafioDbContexto> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void RegistarIdaConsulta(int doenteID, int consultaID)
        {
            
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var consulta = context.Consultas.FirstOrDefault(c => c.ID == consultaID);
                var doente = context.Doentes.FirstOrDefault(d => d.ID == doenteID);

                if (consulta == null || doente == null)
                {
                    throw new Exception("Consulta ou doente não encontrado.");
                }

                consulta.frequentada = true; // Marcar a consulta como frequentada
                //context.Consultas.Update(consulta);
                context.SaveChanges();

                
            }
        }
        public bool VerificarIdaConsulta(int consultaID)
        {
            
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var consulta = context.Consultas.FirstOrDefault(c => c.ID == consultaID);

                if (consulta == null)
                {
                    throw new Exception("Consulta não encontrada.");
                }

                // Verificar se o doente compareceu à consulta (frequentada é true)
                return consulta.frequentada.HasValue && consulta.frequentada.Value;
            }
        }
        public DoenteRelatorio GerarRelatorio(int doenteID)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var numeroConsultas = context.Consultas
                    .Count(c => c.Doente.ID == doenteID);

                var doente = context.Doentes
                    .FirstOrDefault(d => d.ID == doenteID);

                if (doente == null)
                {
                    throw new Exception("Doente não encontrado.");
                }

                var relatorio = new DoenteRelatorio
                {
                    Doente = doente,
                    NumeroConsultas = numeroConsultas
                };

                return relatorio;
            }
        }

    }
}
