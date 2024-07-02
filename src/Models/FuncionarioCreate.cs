using System.Text.Json.Serialization;

namespace backend.Models;
public class FuncionarioCreate
{
  public Int32 matricula { get; set; }
  public String nome_colaborador { get; set; }
  public DateOnly admissao { get; set; }
  public Int32 id_funcionario_funcao { get; set; }
  public Int32 id_regional { get; set; }
  public Int32 id_processo { get; set; }
  public Int32 id_funcionario_situacao { get; set; }
  [JsonConstructor]
  public FuncionarioCreate(Int32 matricula, String nome_colaborador, Int32 id_funcionario_funcao, DateOnly admissao, Int32 id_regional, Int32 id_processo)
  {
    this.nome_colaborador = nome_colaborador;
    this.matricula = matricula;
    this.id_funcionario_funcao = id_funcionario_funcao;
    this.admissao = admissao;
    this.id_regional = id_regional;
    this.id_processo = id_processo;
  }
}
