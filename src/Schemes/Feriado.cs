using System.ComponentModel.DataAnnotations;
namespace backend.Models;
public class Feriado
{
  [Key]
  [DataType(DataType.Date)]
  public DateOnly dia { get; set; }
  public String descricao { get; set; }
  public Int32 referencia { get; set; }
  public Feriado(DateOnly dia, String descricao)
  {
    this.dia = dia;
    this.descricao = descricao;
    this.referencia = (dia.Year * 100) + dia.Month;
  }
}

