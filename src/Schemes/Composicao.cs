using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace backend.Models;
[Index(nameof(identificador), IsUnique = true)]
public class Composicao
{
  public String? identificador { get; set; }
  [DataType(DataType.Date)]
  public DateOnly? dia { get; set; }
  public Int32? adesivo { get; set; }
  public String? placa { get; set; }
  public String? recurso { get; set; }
  public Int32 id_atividade { get; set; }
  public String? motorista { get; set; }
  public Int32? id_motorista { get; set; }
  public String? ajudante { get; set; }
  public Int32? id_ajudante { get; set; }
  public Int64? telefone { get; set; }
  public Int32? id_supervisor { get; set; }
  public String? supervisor { get; set; }
  public Int32? id_regional { get; set; }
  public Int32? id_tipo_viatura { get; set; } = 1;
  [NotMapped]
  public List<string> validacao { get; set; } = new();
  public String? abreviacao { get; set; }
  public String? justificada { get; set; }
  public String? situacao { get; set; }
  public Int32? id_controlador { get; set; }
  public String? controlador { get; set; }
  public String? tecnico { get; set; }
  public Int32? id_processo { get; set; }
  public Int32? id_horario_equipe { get; set; }
  public Double id_contrato { get; set; }
  public String IsPesado(String atividade)
  {
    if(atividade.Contains("PESADO"))
    {
      this.id_tipo_viatura = 2;
      return atividade.Replace(" PESADO", "");
    }
    if(atividade.Contains("CAMINHÃO"))
    {
      this.id_tipo_viatura = 2;
      return atividade.Replace(" CAMINHÃO", "");
    }
    return atividade;
  }
  public String IsNoturno(String atividade)
  {
    if(atividade.Contains("POSTO"))
    {
      this.id_horario_equipe = 2;
      return atividade.Replace(" POSTO", "");
    }
    return atividade;
  }
  public String SanitizarAlavanca(String atividade)
  {
    return atividade.Replace(" OE", "")
                    .Replace(" BX", "")
                    .Replace(" OESTE", "")
                    .Replace(" EXTRAS", "")
                    .Replace(" LESTE", "");
  }
  public String SanitizarRegional(String regional)
  {
    return regional.Replace("CAMPO GRANDE", "OESTE")
                    .Replace("JACAREPAGUA", "OESTE");
  }
}

