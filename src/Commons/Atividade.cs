using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Commons
{
  public class Atividade
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Int32 id_atividade { get; set; }
    public String atividade { get; set; }
    public Atividade(Int32 id_atividade, String atividade)
    {
      this.id_atividade = id_atividade;
      this.atividade = atividade;
    }
  }
}
