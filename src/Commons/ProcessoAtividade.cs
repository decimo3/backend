using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Commons
{
  public class ProcessoAtividade
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Int32 id_atividade { get; set; }
    public Int32 id_processo { get; set; }
    public ProcessoAtividade(Int32 id_atividade, Int32 id_processo)
    {
      this.id_atividade = id_atividade;
      this.id_processo = id_processo;
    }
  }
}
