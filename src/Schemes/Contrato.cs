using System.ComponentModel.DataAnnotations;
namespace backend.Models;
public class Contrato
{
  [Key]
  public Double id_contrato { get; set; }
  public Int64 contrato { get; set; }
  public Int32 revisao { get; set; }
  public Int32 id_regional { get; set; }
  public Int32 id_processo { get; set; }
  [DataType(DataType.Date)]
  public DateOnly inicio_vigencia { get; set; }
  [DataType(DataType.Date)]
  public DateOnly final_vigencia { get; set; }
  public Contrato(Int64 contrato, Int32 revisao, DateOnly inicio_vigencia, DateOnly final_vigencia, Int32 id_regional, Int32 id_processo)
  {
    this.contrato = contrato;
    this.revisao = revisao;
    this.inicio_vigencia = inicio_vigencia;
    this.final_vigencia = final_vigencia;
    this.id_regional = id_regional;
    this.id_processo = id_processo;
    this.id_contrato = this.contrato + (this.revisao / 10);
  }
}
