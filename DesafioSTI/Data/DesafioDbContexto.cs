using Microsoft.EntityFrameworkCore;

namespace DesafioSTI.Data
{
    public class DesafioDbContexto:DbContext
    {
        protected readonly IConfiguration configuration;

        public DesafioDbContexto(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(configuration.GetConnectionString("Desafio"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doente>().ToTable("Doente");
            modelBuilder.Entity<Consulta>().ToTable("Consulta");

            modelBuilder.Entity<Doente>();
            


            modelBuilder.Entity<Consulta>()
            .HasOne(c => c.Doente);
            
           

           /* modelBuilder.Entity<Doente>()
                .HasData(
                new Doente
                {
                   ID = 1,
                   NoDeProcesso=1,
                   Nome="Vasco",
                   DataNascimento =new DateTime(2001,07,07),
                   Sexo ="Masculino",
                   Consultas= new List<Consulta>() 
                }
                );
            modelBuilder.Entity<Consulta>()
                .HasData(
                new Consulta
                {
                    ID = 1,
                    Data = DateTime.Now,
                    Especialidade = "Oftalmologia",
                    
                }
                );*/

        }

        public DbSet<Doente> Doentes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

    }
}
