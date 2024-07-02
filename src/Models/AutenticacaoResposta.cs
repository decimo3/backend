namespace backend.Models;
public class AutenticacaoResposta
{
  public Int32 matricula { get; set; }
  public String nome_colaborador { get; set; }
  public Int32 role { get; set; }
  public String token { get; set; }
  public AutenticacaoResposta(Int32 mat, String nom, Int32 role, String token)
  {
    this.matricula = mat;
    this.nome_colaborador = nom;
    this.role = role;
    this.token = token;
  }
  public AutenticacaoResposta(Funcionario funcionario, String token)
  {
    this.matricula = funcionario.matricula;
    this.nome_colaborador = funcionario.nome_colaborador;
    this.role = funcionario.id_funcionario_funcao;
    this.token = token;
  }
}
