using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Commons
{
  public class ComposicaoHorario
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Int32 id_composicao_horario { get; set; }
    public String composicao_horario { get; set; }
    public ComposicaoHorario(Int32 id_composicao_horario, String composicao_horario)
    {
      this.id_composicao_horario = id_composicao_horario;
      this.composicao_horario = composicao_horario;
    }
  }
}
