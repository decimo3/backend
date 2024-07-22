using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace backend.Models;
[Index(nameof(identificador), IsUnique = false)]
public partial class Servico
{
  [StringLength(50)]
  public String? filename { get; set; }
  [StringLength(50)]
  public String? recurso { get; set; }
  [DataType(DataType.Date)]
  public DateOnly? dia { get; set; }
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public Int64? serial { get; set; }
  public String? id_servico_situacao { get; set; }
  [StringLength(100)]
  public String? nome_do_cliente { get; set; }
  [StringLength(120)]
  public String? endereco_destino { get; set; }
  [StringLength(50)]
  public String? cidade_destino { get; set; }
  [StringLength(30)]
  public String? estado_destino { get; set; }
  [StringLength(15)]
  public Int32? codigo_postal { get; set; }
  [StringLength(0)]
  public Int64? telefone_cliente { get; set; }
  [StringLength(0)]
  public Int64? celular_cliente { get; set; }
  [StringLength(60)]
  public String? email_cliente { get; set; }
  [DataType(DataType.Time)]
  public TimeOnly? hora_inicio { get; set; }
  [DataType(DataType.Time)]
  public TimeOnly? hora_final { get; set; }
  [StringLength(13)]
  public String? inicio_final { get; set; }
  [DataType(DataType.DateTime)]
  public DateTime? inicio_do_sla { get; set; }
  [DataType(DataType.DateTime)]
  public DateTime? final_do_sla { get; set; }
  [DataType(DataType.DateTime)]
  public DateTime? criado_em { get; set; }
  [DataType(DataType.DateTime)]
  public DateTime? vencimento { get; set; }
  [DataType(DataType.Duration)]
  public TimeSpan? duracao_feito { get; set; }
  [DataType(DataType.Duration)]
  public TimeSpan? desloca_feito { get; set; }
  [StringLength(10)]
  public String? tipo_atividade { get; set; }
  [StringLength(50)]
  public String? tipo_atividade_1 { get; set; }
  public Int64? ordem_de_servico { get; set; }
  [StringLength(0)]
  public Int64? numero_da_conta { get; set; }
  [StringLength(100)]
  public String? habilidade_de_trabalho { get; set; }
  public Int32? area_trabalho { get; set; }
  [StringLength(15)]
  public String? primeira_operacao_manual { get; set; }
  [StringLength(50)]
  public String? primeira_operacao_manual_login { get; set; }
  [StringLength(50)]
  public String? primeira_operacao_manual_nome { get; set; }
  [StringLength(0)]
  public String? horario_em_rota { get; set; }
  [DataType(DataType.DateTime)]
  public DateTime? data_inicio_de_turno { get; set; }
  [StringLength(0)]
  public String? data_do_ro { get; set; }
  [DataType(DataType.Date)]
  public DateOnly? roteado_automaticamente_ate_o_momento { get; set; }
  public Int32? roteado_automaticamente_ate_o_recurso { get; set; }
  [StringLength(50)]
  public String? roteado_automaticamente_ate_o_recurso_nome { get; set; }
  public Int32? id_do_recurso { get; set; }
  public Int32? primeira_operacao_manual_executada_por_usuario { get; set; }
  [StringLength(50)]
  public String? usuario_conclusao { get; set; }
  public Double? coordenada_x { get; set; }
  public Double? coordenada_y { get; set; }
  [StringLength(10)]
  public String? exatidao_da_coordenada { get; set; }
  [StringLength(10)]
  public String? status_da_coordenada { get; set; }
  [StringLength(30)]
  public String? codigos_fechamento { get; set; }
  [StringLength(10)]
  public String? lg_ctrl_tipo_fechamento_ok { get; set; }
  [StringLength(5)]
  public String? cod_fechamento_preenchido { get; set; }
  [StringLength(30)]
  public String? cods_de_fechamento { get; set; }
  [StringLength(15)]
  public String? label_do_veiculo { get; set; }
  public Int32? id_matricula_lider { get; set; }
  public Int32? id_matricula_auxiliares { get; set; }
  public Int32? id_matricula_guarda { get; set; }
  [StringLength(1_000)]
  public String? observacao { get; set; }
  [StringLength(50)]
  public String? descricao_breve_do_conteudo_da_nota { get; set; }
  [StringLength(30)]
  public String? sub_bairro { get; set; }
  [StringLength(5)]
  public String? lg_flag_preech_fechamento { get; set; }
  [StringLength(0)]
  public String? codigos_de_fechamento_da_atividade_pai_v03 { get; set; }
  [StringLength(0)]
  public String? lg_ctrl_reprov_flag { get; set; }
  public Int64? numero_da_instalacao { get; set; }
  [StringLength(30)]
  public String? edificio { get; set; }
  [StringLength(15)]
  public String? complemento { get; set; }
  [StringLength(30)]
  public String? intervalo_de_tempo { get; set; }
  [StringLength(4)]
  public String? motivo_de_rejeicao { get; set; }
  [StringLength(2)]
  public String? tipo_de_nota_de_servico { get; set; }
  [DataType(DataType.DateTime)]
  public DateTime? tempo_de_reserva_da_atividade { get; set; }
  public Double? debitos_cliente { get; set; }
  [StringLength(500)]
  public String? balde_origem { get; set; }
  [StringLength(15)]
  public String? tipo_de_ligacao { get; set; }
  [StringLength(0)]
  public String? cliente_assinou_toi { get; set; }
  [StringLength(0)]
  public String? recusou_a_assinar_toi { get; set; }
  [StringLength(0)]
  public String? recusou_receber_toi { get; set; }
  [StringLength(0)]
  public String? autorizou_levantamento_de_carga { get; set; }
  [DataType(DataType.Duration)]
  public TimeSpan? desloca_estimado { get; set; }
  [DataType(DataType.Duration)]
  public TimeSpan? duracao_estimado { get; set; }
  [StringLength(30)]
  public String? abrangencia { get; set; }
  [StringLength(30)]
  public String? motivo_indisponibilidade { get; set; }
  public Int32? chi { get; set; }
  public Int32? tempo_interrompido { get; set; }
  public Int32? valor_compensacao_financeira { get; set; }
  [StringLength(30)]
  public String? identificador { get; set; }
  [StringLength(10)]
  public String? abreviacao { get; set; }
  public DateTime? timestamp { get; set; }
  [StringLength(50)]
  public String? codigos_concaternados { get; set; }
  /*
  0 = nenhum;
  1 = corte ["BB", "BD"]
  2 = religa ["B1", "BL", "BR"]
  3 = emergencia ["BE", "OM"]
  4 = inspeção ["B9", "BI", "BU"]
  5 = afericao ["B5", "B8", "BA", "BC", "BN", "BS", "BV"]
  5 = afericao [todos, exceto os códigos de ligação]
  6 = ligacao ["B3", "BN", "BS", "BV"]
  6 = ligacao ["OJ10", "OSLN", "OSLQ", "OSLR", "OSLX", "RC68", "RC79"]
  */
  public Int32 id_atividade { get; set; } = 0;
  public Int32 id_processo { get; set; } = 0;
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
  public Int32 tem_normalizacao { get; set; } = 0;
  // Se tiver normalização ou o código ["6.24"]
  public Boolean tem_inspecao { get; set; } = false;
  // Se houver texto VISTORIA na descrição da nota;
  // Ou se tiver algum dos códigos ["7.24", "7.28", "7.39", "7.70", "18.0"]
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
  // Se tiver algum código ["T.03"]
  public Boolean tem_caixa { get; set; } = false;
  public String? id_grupo_codes { get; set; }
}

