using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Commons
{
  public class ServicoFaseado
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Int32 id_faseado { get; set; }
    public String faseado { get; set; }
    public ServicoFaseado(Int32 id_faseado, String faseado)
    {
      this.id_faseado = id_faseado;
      this.faseado = faseado;
    }
  }
}
