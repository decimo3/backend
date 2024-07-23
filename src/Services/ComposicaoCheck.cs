using backend.Models;
namespace backend.Services;
public class ComposicaoCheck
{
  private Database database;
  public ComposicaoCheck(Database database)
  {
    this.database = database;
  }
  private Int32 CheckRegional(String? regional_texto)
  {
    if(regional_texto == null)
      throw new ArgumentNullException("A regional não foi coletada!");
    var regional = this.database.regional.Where(r => r.regional.ToLower() == regional_texto.ToLower()).SingleOrDefault();
    if(regional == null)
      throw new NullReferenceException("A regional informada não foi encontrada!");
    return regional.id_regional;
  }
  private Int32 CheckProcesso(Int32? id_atividade)
  {
    if(id_atividade == null || id_atividade == 0)
      throw new ArgumentNullException("A atividade não foi coletada!");
    var processo_atividade = this.database.processo_atividade.Where(p => p.id_atividade == id_atividade).SingleOrDefault();
    if(processo_atividade == null)
      throw new NullReferenceException("O processo não foi encontrado pela ativiadade informada!");
    return processo_atividade.id_processo;
  }
  private Double CheckContrato(Int32? id_regional, Int32? id_processo, DateOnly? dia)
  {
    if(id_regional == null || id_processo == null || dia == null)
      throw new ArgumentNullException("Está faltando informações para pesquisar o contrato!");
    var contrato = this.database.contrato.Where(c => c.id_regional == id_regional && c.id_processo == id_processo &&
      c.inicio_vigencia >= dia && c.final_vigencia <= dia).SingleOrDefault();
    if(contrato == null)
      throw new NullReferenceException("O contrato não pode ser encontrado pelos critérios informados!");
    return contrato.id_contrato;
  }
  private Int32 CheckFuncionario(String? nome_colaborador)
  {
    if(nome_colaborador == null)
      throw new ArgumentException("Não foi coletado o nome do colaborador!");
    var funcionario = database.funcionario.Where(o => o.nome_colaborador.ToLower() == nome_colaborador.ToLower()).SingleOrDefault();
    if(funcionario == null)
      throw new ArgumentException("Não foi encontrado o nome do colaborador no banco de dados! Verifique se o nome foi digitado corretamente.");
    return funcionario.matricula;
  }
  private void CheckFuncionario(Int32? matricula, String? nome_colaborador)
  {
    if(nome_colaborador == null)
      throw new ArgumentException("Não foi coletado o nome do colaborador!");

    Funcionario? funcionario = new();

    if(matricula == null)
      funcionario = database.funcionario.Where(o => o.nome_colaborador.ToLower() == nome_colaborador.ToLower()).SingleOrDefault();
    else
      funcionario = database.funcionario.Find(matricula);

    if(funcionario == null || (funcionario.nome_colaborador != nome_colaborador))
      throw new ArgumentException("O funcionário não foi encontrado ou o nome não condiz com a matrícula informada!");

    return;
  }
  // DONE - Checagem se atividade condiz com o banco de dados
  private Int32 CheckAtividade(String? atividade_texto)
  {
    if(atividade_texto == null)
      throw new ArgumentException("A atividade não foi encontrada!");
    var atividade = this.database.atividade.Where(a => a.atividade.ToLower() == atividade_texto.ToLower()).SingleOrDefault();
    if(atividade == null)
      throw new ArgumentException("Atividade informada não foi encontrada no banco de dados!");
    return atividade.id_atividade;
  }
  public List<Composicao> CheckComposicao(List<Composicao> composicoes)
  {
    foreach (var composicao in composicoes)
    {
      // TODO - Verifica se o eletricista líder é válido
      try
      {
        CheckFuncionario(composicao.id_motorista, composicao.motorista);
      }
      catch (System.Exception erro)
      {
        composicao.validacao.Add(erro.Message);
      }
      // TODO - Verifica se a composição pode ser UMPLA
      if(composicao.atividade != "LABORATÓRIO")
      {
        // TODO - Verifica se o eletricista auxiliar é válido
        try
        {
          CheckFuncionario(composicao.id_ajudante, composicao.ajudante);
        }
        catch (System.Exception erro)
        {
          composicao.validacao.Add(erro.Message);
        }
      }
      // TODO - Verifica o supervisor responsável é válido
      try
      {
        if(composicao.id_supervisor == null || composicao.id_supervisor == 0)
        {
          composicao.id_supervisor = CheckFuncionario(composicao.supervisor);
        }
        else
        {
          CheckFuncionario(composicao.id_supervisor, composicao.supervisor);
        }
      }
      catch (System.Exception erro)
      {
        composicao.validacao.Add(erro.Message);
      }
      // TODO - Verifica se tem controlador na composição
      if(composicao.controlador != null)
      {
        // TODO - Verifica o controlador responsável é válido
        try
        {
          composicao.id_controlador = CheckFuncionario(composicao.controlador);
        }
        catch (System.Exception erro)
        {
          composicao.validacao.Add(erro.Message);
        }
      }
      // TODO - Verifica se a atividade informada é válida
      try
      {
        composicao.id_atividade = CheckAtividade(composicao.atividade);
      }
      catch (System.Exception erro)
      {
        composicao.validacao.Add(erro.Message);
      }
      // TODO - Verifica se a redional informada é válida
      try
      {
        composicao.id_regional = CheckRegional(composicao.regional);
      }
      catch (System.Exception erro)
      {
        composicao.validacao.Add(erro.Message);
      }
      // TODO - Verifica o processo da compposição
      try
      {
        composicao.id_contrato = CheckProcesso(composicao.id_atividade);
      }
      catch (System.Exception erro)
      {
        composicao.validacao.Add(erro.Message);
      }
      // TODO - Verifica o contrato da compposição
      try
      {
        composicao.id_contrato = CheckContrato(composicao.id_regional, composicao.id_processo, composicao.dia);
      }
      catch (System.Exception erro)
      {
        composicao.validacao.Add(erro.Message);
      }
    }
    return composicoes;
  }
}
