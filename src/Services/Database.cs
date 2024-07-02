using backend.Models;
using backend.Commons;
using Microsoft.EntityFrameworkCore;
namespace backend.Services;
public class Database : DbContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if(System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
    {
      dotenv.net.DotEnv.Fluent().WithEnvFiles(".env").Load();
      optionsBuilder.EnableSensitiveDataLogging();
      optionsBuilder.EnableDetailedErrors();
    }
      var dbhost = System.Environment.GetEnvironmentVariable("PGHOST");
      if(dbhost is null) throw new InvalidOperationException("Environment variable PGHOST is not set!");
      var dbport = System.Environment.GetEnvironmentVariable("PGPORT");
      if(dbport is null) throw new InvalidOperationException("Environment variable PGPORT is not set!");
      var dbuser = System.Environment.GetEnvironmentVariable("PGUSER");
      if(dbuser is null) throw new InvalidOperationException("Environment variable PGUSER is not set!");
      var dbpass = System.Environment.GetEnvironmentVariable("PGPASSWORD");
      if(dbpass is null) throw new InvalidOperationException("Environment variable PGPASSWORD is not set!");
      var dbbase = System.Environment.GetEnvironmentVariable("PGDATABASE");
      if(dbbase is null) throw new InvalidOperationException("Environment variable PGDATABASE is not set!");
      var stringconnection = new Npgsql.NpgsqlConnectionStringBuilder()
      {
        Host = dbhost,
        Port = Int32.Parse(dbport),
        Username = dbuser,
        Password = dbpass,
        Database = dbbase
      };
      optionsBuilder.UseNpgsql(stringconnection.ConnectionString);
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Composicao>().HasKey(o => new {o.dia, o.recurso});
    modelBuilder.Entity<Objetivos>().HasKey(o => new {o.id_regional, o.id_tipo_viatura, o.id_atividade});
    modelBuilder.Entity<Valoracao>().HasKey(o => new {o.id_regional, o.id_tipo_viatura, o.id_atividade, o.codigo});
  }
  public DbSet<Composicao> composicao { get; set; }
  public DbSet<Servico> relatorio { get; set; }
  public DbSet<Funcionario> funcionario { get; set; }
  public DbSet<Valoracao> valoracao { get; set; }
  public DbSet<Objetivos> objetivo { get; set; }
  public DbSet<Contrato> contrato { get; set; }
  public DbSet<Feriado> feriado { get; set; }
  public DbSet<RelatorioEstatisticas> relatorioEstatisticas { get; set; }
  public DbSet<Alteracao> alteracao { get; set; }
  public DbSet<DiasUteis> dias_uteis { get; set; }
  public DbSet<Regional> regional { get; set; }
  public DbSet<Atividade> atividade { get; set; }
  public DbSet<ViaturaTipo> viatura_tipo { get; set; }
  public DbSet<ComposicaoHorario> composicao_horario { get; set; }
  public DbSet<ServicoSituacao> servico_situacao { get; set; }
  public DbSet<ServicoFaseado> servico_faseado { get; set; }
  public DbSet<ServicoTipo> servico_tipo { get; set; }
  public DbSet<ServicoLocalidade> servico_localidade { get; set; }
  public DbSet<Processo> processo { get; set; }
  public DbSet<FuncionarioSituacao> funcionario_situacao { get; set; }
  public DbSet<FuncionarioFuncao> funcionario_funcao { get; set; }
  public DbSet<ProcessoAtividade> processo_atividade { get; set; }
}
