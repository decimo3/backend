using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Commons
{
  public class Regional
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Int32 id_regional { get; set; }
    public String regional { get; set; }
    public Regional(Int32 id_regional, String regional)
    {
      this.id_regional = id_regional;
      this.regional = regional;
    }
  }
}
