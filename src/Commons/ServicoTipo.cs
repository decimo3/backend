using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Commons
{
  public class ServicoTipo
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public String id_servico_tipo { get; set; }
    public String servico_tipo { get; set; }
    public ServicoTipo(String id_servico_tipo, String servico_tipo)
    {
      this.id_servico_tipo = id_servico_tipo;
      this.servico_tipo = servico_tipo;
    }
  }
}
