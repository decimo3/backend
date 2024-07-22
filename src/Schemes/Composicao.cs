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
  public String? atividade { get; set; }
  public String? motorista { get; set; }
  public Int32? id_motorista { get; set; }
  public String? ajudante { get; set; }
  public Int32? id_ajudante { get; set; }
  public Int64? telefone { get; set; }
  public Int32? id_supervisor { get; set; }
  public String? supervisor { get; set; }
  public Int32? id_regional { get; set; }
  public String? regional { get; set; }
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
  public void IsPesado()
  {
    if(this.atividade == null) return;
    if(this.atividade.Contains("PESADO"))
    {
      this.id_tipo_viatura = 2;
      this.atividade = this.atividade.Replace(" PESADO", "");
    }
    if(this.atividade.Contains("CAMINHÃO"))
    {
      this.id_tipo_viatura = 2;
      this.atividade = this.atividade.Replace(" CAMINHÃO", "");
    }
  }
  public void IsNoturno()
  {
    if(this.atividade == null) return;
    if(this.atividade.Contains("POSTO"))
    {
      this.id_horario_equipe = 2;
      this.atividade = this.atividade.Replace(" POSTO", "");
    }
  }
  public void SanitizarAlavanca()
  {
    if(this.atividade == null) return;
    String[] exclusoes = {" OE", " BX", " OESTE", " EXTRAS", " LESTE", " PROJETO"};
    foreach (var exclusao in exclusoes)
    {
      this.atividade = this.atividade.Replace(exclusao, "");
    }
  }
  public void SanitizarRegional()
  {
    if(this.regional == null) return;
    this.regional = this.regional.Replace("CAMPO GRANDE", "OESTE");
    this.regional = this.regional.Replace("JACAREPAGUA", "OESTE");
  }
}

