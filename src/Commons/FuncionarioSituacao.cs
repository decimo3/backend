using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Commons
{
  public class FuncionarioSituacao
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Int32 id_funcionario_situacao { get; set; }
    public String funcionario_situacao { get; set; }
    public FuncionarioSituacao(Int32 id_funcionario_situacao, String funcionario_situacao)
    {
      this.id_funcionario_situacao = id_funcionario_situacao;
      this.funcionario_situacao = funcionario_situacao;
    }
  }
}
