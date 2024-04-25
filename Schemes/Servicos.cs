using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace backend.Models;
[Index(nameof(identificador), IsUnique = false)]
public partial class Servico
{
  public String filename { get; set; }
  public String recurso { get; set; }
  [DataType(DataType.Date)]
  public DateOnly dia { get; set; }
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public Int64 serial { get; set; }
  public TipoStatus status { get; set; }
  public String? nome_do_cliente { get; set; }
  public String? endereco_destino { get; set; }
  public String? cidade_destino { get; set; }
  public String? codigo_postal { get; set; }
  [DataType(DataType.Time)]
  public TimeOnly? hora_inicio { get; set; }
  [DataType(DataType.Time)]
  public TimeOnly? hora_final { get; set; }
  [DataType(DataType.DateTime)]
  public DateTime? vencimento { get; set; }
  [DataType(DataType.Duration)]
  public TimeSpan? duracao_feito { get; set; }
  [DataType(DataType.Duration)]
  public TimeSpan? desloca_feito { get; set; }
  public String? tipo_atividade { get; set; }
  public Int64? servico { get; set; }
  public String? area_trabalho { get; set; }
  public String? codigos { get; set; }
  public String? id_viatura { get; set; }
  public Int32? id_motorista { get; set; }
  public Int32? id_ajudante { get; set; }
  public Int32? id_tecnico { get; set; }
  public String? observacao { get; set; }
  public String? bairro_destino { get; set; }
  public Int32? instalacao { get; set; }
  public String? complemento_destino { get; set; }
  public String? referencia_destino { get; set; }
  public String? tipo_servico { get; set; }
  public Double? debitos_cliente { get; set; }
  public TipoInstalacao? tipo_instalacao { get; set; }
  [DataType(DataType.Duration)]
  public TimeSpan? desloca_estima { get; set; }
  [DataType(DataType.Duration)]
  public TimeSpan? duracao_estima { get; set; }
  public String? motivo_indisponibilidade { get; set; }
  public String? identificador { get; set; }
  public String? abreviacao { get; set; }
  public DateTime? timestamp { get; set; } = null;
  /*
  0 = nenhum;
  1 = corte ["BB", "BD"]
  2 = religa ["B1", "BL", "BR"]
  3 = emergencia ["BE", "OM"]
  4 = inspeção ["B9", "BI", "BU"]
  5 = afericao ["B5", "B8", "BA", "BC", "BN", "BS", "BV"]
  5 = afericao [todos exceto os códigos de ligação]
  6 = ligacao ["B3", "BN", "BS", "BV"]
  6 = ligacao ["OJ10", "OSLN", "OSLQ", "OSLR", "OSLX", "RC68", "RC79"]
  */
  public Int16 id_processo { get; set; } = 0;
  // Se tiver algum dos códigos ["7.10", "7.11", "7.12", "18.0", "T.05"]
  public Boolean tem_inst_ramal { get; set; } = false;
  // Se tiver algum dos códigos ["6.16", "6.43", "18.0", "T.03"]
  public Boolean tem_inst_medidor { get; set; } = false;
  // Se tiver algum dos códigos ["7.15", "7.16", "7.17", "6.11"]
  public Boolean tem_ret_ramal { get; set; } = false;
  // Se tiver algum o código ["6.15"]
  public Boolean tem_ret_medidor { get; set; } = false;
  // Se houver texto INICIATIVA na descrição da nota;
  public Boolean tem_iniciativa { get; set; } = false;
  // Se tiver algum dos códigos abaixo, pega o número referente a normalização
  // ["N001", "N002", "N003", "N007", "N009", "N010", "N018", "N024", "N025"]
  public Int16 tem_normalizacao { get; set; } = 0;
  // Se tiver normalização ou o código ["6.24"]
  public Boolean tem_inspecao { get; set; } = false;
  // Se houver texto VISTORIA na descrição da nota;
  // Ou se tiver algum dos códigos ["7.24", "7.28", "7.39", "7.70"]
  public Boolean tem_vistoria { get; set; } = false;
  // Se houver texto FEST na descrição da nota;
  public Boolean tem_festiva { get; set; } = false;
  // Se tiver algum o código ["7.73"]
  public Boolean tem_miscelanea { get; set; } = false;
  // Se tiver algum o código ["6.37"]
  public Boolean tem_afericao { get; set; } = false;
  // Se tiver algum dos códigos ["V.01", "8.75", "15.4", "8.90", "7.70", "7.39", "7.07", "6.25"]
  public Boolean tem_visita { get; set; } = false;
  // Se tiver algum dos códigos ["M.01", "M.02"]
  public Boolean tem_lente { get; set; } = false;
  // Se tiver algum dos danos ["OAJI", "OAJC", "OSJD"]
  public Boolean tem_perito { get; set; } = false;
  public String? id_grupo_codes { get; set; }
}
public enum TipoInstalacao { Monofasico, Bifasico, Trifasico }
public enum TipoStatus {cancelado, concluido, deslocando, iniciado, rejeitado, pendente}
