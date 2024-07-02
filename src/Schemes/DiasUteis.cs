using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace backend.Models;
public class DiasUteis
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public Int32 id_dias_uteis { get; set; }
  public DateOnly referencia { get; set; }
  public Int32 dias_uteis { get; set; }
  public DiasUteis() {}
  public DiasUteis(DateOnly hoje)
  {
    this.referencia = hoje.AddDays(-(hoje.Day - 1));
    this.id_dias_uteis = (hoje.Year * 100) + hoje.Month;
    this.dias_uteis = this.qnt_dias_uteis(referencia);
  }
  private Int32 qnt_dias_uteis(DateOnly inicio)
  {
    var dias_uteis = 0;
    var dias_mes = DateTime.DaysInMonth(inicio.Year, inicio.Month);
    for (var dia = 1; dia <= dias_mes; dia++)
    {
      var data = new DateTime(inicio.Year, inicio.Month, dia);
      if(data.DayOfWeek == DayOfWeek.Sunday) continue;
      if(data.DayOfWeek == DayOfWeek.Saturday) continue;
      dias_uteis++;
    }
    return (Int32)dias_uteis;
  }
}
