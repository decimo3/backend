using backend.Models;
using NuGet.Protocol;
namespace backend.Services;
public class ComposicaoCheck
{
  public static List<Composicao> Check(Database database, List<Composicao> composicoes)
  {
    foreach (var composicao in composicoes)
    {
      var check_motorista = CheckFuncionario(database, composicao.id_motorista, composicao.motorista);
      if(check_motorista != null) composicao.validacao.Add(check_motorista);
      var check_ajudante = CheckFuncionario(database, composicao.id_ajudante, composicao.ajudante);
      if(check_ajudante != null) composicao.validacao.Add(check_ajudante);
      var check_supervisor = CheckFuncionario(database, composicao.id_supervisor, composicao.supervisor);
      if(check_supervisor != null) composicao.validacao.Add(check_supervisor);
    }
    return composicoes;
  }
  private static String? CheckFuncionario(Database database, Int32? matricula, String? nome_colaborador)
  {
    if(matricula == null)
    {
      var funcionario = CheckFuncionario(database, nome_colaborador);
      if(funcionario == null)
        return "O funcionário não foi encontrado com o nome informado!";
    }
    else
    {
      var funcionario = database.funcionario.Find(matricula);
      if(funcionario == null)
        return "O funcionário não foi encontrado com a matrícula informada!";
      if(funcionario.nome_colaborador != nome_colaborador)
        return "O nome do funcionario não condiz com a matrícula!";
    }
    return null;
  }
  private static Funcionario? CheckFuncionario(Database database, String? funcionario)
  {
    if(funcionario == null) return null;
    return database.funcionario.Where(o => o.nome_colaborador.ToLower() == funcionario.ToLower()).SingleOrDefault();
  }
}
