using Atividade.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Atividade.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TarefaModel> Tarefas { get; set; }
        public DbSet<AtividadeModel> Atividades { get; set; }
    }

}