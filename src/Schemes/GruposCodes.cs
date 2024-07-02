using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
  public class GrupoCodes
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Int32 id_grupo_codes { get; set; }
    public String codigos_grupo { get; set; }
    public Int32 codigos_mestre { get; set; }
    public GrupoCodes(Int32 id_grupo_codes, String codigos_grupo, Int32 codigos_mestre)
    {
      this.id_grupo_codes = id_grupo_codes;
      this.codigos_grupo = codigos_grupo;
      this.codigos_mestre = codigos_mestre;
    }
  }
}
