using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Commons
{
  public class FuncionarioFuncao
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Int32 id_funcionario_funcao { get; set; }
    public String funcionario_funcao { get; set; }
    public FuncionarioFuncao(Int32 id_funcionario_funcao, String funcionario_funcao)
    {
      this.id_funcionario_funcao = id_funcionario_funcao;
      this.funcionario_funcao = funcionario_funcao;
    }
  }
}
