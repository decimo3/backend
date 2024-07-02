using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace backend.Models;
public class Valoracao
{
  public Double id_contrato { get; set; }
  public Int32 id_regional { get; set; }
  public Int32 id_tipo_viatura { get; set; }
  public Int32 id_atividade { get; set; }
  public String codigo { get; set; }
  [Column(TypeName="money")]
  public Decimal valor { get; set; }
  public Valoracao(Int32 id_regional, Int32 id_tipo_viatura, Int32 id_atividade, String codigo, Decimal valor, Double id_contrato)
  {
    this.id_regional = id_regional;
    this.id_tipo_viatura = id_tipo_viatura;
    this.id_atividade = id_atividade;
    this.codigo = codigo;
    this.valor = valor;
    this.id_contrato = id_contrato;
  }
}
