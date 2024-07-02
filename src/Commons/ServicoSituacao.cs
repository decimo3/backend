using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Commons
{
  public class ServicoSituacao
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Int32 id_servico_situacao { get; set; }
    public String servico_situacao { get; set; }
    public ServicoSituacao(Int32 id_servico_situacao, String servico_situacao)
    {
      this.id_servico_situacao = id_servico_situacao;
      this.servico_situacao = servico_situacao;
    }
  }
}
