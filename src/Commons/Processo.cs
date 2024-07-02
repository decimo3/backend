using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Commons
{
  public class Processo
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Int32 id_processo { get; set; }
    public String processo { get; set; }
    public Processo(Int32 id_processo, String processo)
    {
      this.id_processo = id_processo;
      this.processo = processo;
    }
  }
}
