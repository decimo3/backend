using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Commons
{
  public class ViaturaTipo
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Int32 id_viatura_tipo { get; set; }
    public String viatura_tipo { get; set; }
    public ViaturaTipo(Int32 id_viatura_tipo, String viatura_tipo)
    {
      this.id_viatura_tipo = id_viatura_tipo;
      this.viatura_tipo = viatura_tipo;
    }
  }
}
