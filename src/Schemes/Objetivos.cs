using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace backend.Models;
public class Objetivos
{
  public Double id_contrato { get; set; }
  public Int32 id_regional { get; set; }
  public Int32 id_tipo_viatura { get; set; }
  public Int32 id_atividade { get; set; }
  [Column(TypeName="money")]
  public Int32 meta_apresentacao { get; set; }
  public Int32 meta_apresentacao_feriado { get; set; }
  public Int32 meta_execucoes { get; set; }
  public Decimal meta_producao { get; set; }
  public Objetivos(Int32 id_regional, Int32 id_tipo_viatura, Int32 id_atividade, Decimal meta_producao, Int32 meta_apresentacao, Int32 meta_apresentacao_feriado, Int32 meta_execucoes, Double id_contrato)
  {
    this.id_contrato = id_contrato;
    this.id_regional = id_regional;
    this.id_tipo_viatura = id_tipo_viatura;
    this.id_atividade = id_atividade;
    this.meta_producao = meta_producao;
    this.meta_apresentacao = meta_apresentacao;
    this.meta_apresentacao_feriado = meta_apresentacao_feriado;
    this.meta_execucoes = meta_execucoes;
  }
}
