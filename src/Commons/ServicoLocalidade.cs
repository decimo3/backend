using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Commons
{
  public class ServicoLocalidade
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Int32 id_servico_localidade { get; set; }
    public String servico_localidade { get; set; }
    public ServicoLocalidade(Int32 id_servico_localidade, String servico_localidade)
    {
      this.id_servico_localidade = id_servico_localidade;
      this.servico_localidade = servico_localidade;
    }
  }
}
