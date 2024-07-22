using backend.Models;
using OfficeOpenXml;
namespace backend.Services;
public class FileManager
{
  private readonly String filename;
  private readonly Database database;
  private readonly Stream stream;
  public FileManager(Database database, Stream stream, String filename)
  {
    this.database = database;
    this.stream = stream;
    this.filename = filename;
  }
  private StreamReader Sanitizacao()
  {
    var reader = new StreamReader(stream);
    var memory = new MemoryStream();
    var writer = new StreamWriter(memory);
    int character = 0;
    bool insideField = false;
    while ((character = reader.Read()) != -1)
    {
      var letra = (char)character;
      if (letra == '"') insideField = !insideField; // inverte a variável
      if (letra == '\n' && insideField == true)
      {
        writer.Write(' ');
        continue;
      }
      if (letra == ',' && insideField == true)
      {
        writer.Write('.');
        continue;
      }
      if (letra == '–' && insideField == true)
      {
        writer.Write('-');
        continue;
      }
      writer.Write(letra);
    }
    writer.Flush();
    memory.Position = 0;
    using (var fileStream = new FileStream(@$"D:/RELATORIOS/{filename}", FileMode.Create, FileAccess.Write))
    {
      memory.CopyTo(fileStream);
    }
    memory.Position = 0;
    return new StreamReader(memory, System.Text.Encoding.UTF8);
  }
  public List<Servico> Relatorio()
  {
    string ext = Path.GetExtension(filename);
    if (ext != ".csv") throw new InvalidOperationException("Tipo de arquivo inválido!");
    using var streamsanitizado = Sanitizacao();
    var servicos = new List<Servico>();
    {
      while (!streamsanitizado.EndOfStream)
      {
        var line = streamsanitizado.ReadLine();
        if(line == null) continue;
        line = line.Replace("\"", "");
        var values = line.Split(',');
        if(values[0] == "Recurso") continue;
        var servico = new Servico();
        servico.filename = filename;
        servico.recurso = values[0];
        servico.dia = Conversor.GetDateOnly(values[1]);
        servico.serial = Conversor.GetNumberMiddle(values[2]);
        servico.id_servico_situacao = this.database.servico_situacao.Where(s => s.servico_situacao == values[3]).Single().id_servico_situacao;
        servico.nome_do_cliente = values[4];
        servico.endereco_destino = values[5];
        servico.cidade_destino = values[6];
        servico.estado_destino = values[7];
        servico.codigo_postal = Conversor.GetNumberMiddle(values[8]);
        servico.telefone_cliente = Conversor.GetPhoneNumber(values[9]);
        servico.celular_cliente = Conversor.GetPhoneNumber(values[10]);
        servico.email_cliente = values[11];
        servico.hora_inicio = Conversor.GetTimeOnly(values[12]);
        servico.hora_final = Conversor.GetTimeOnly(values[13]);
        servico.inicio_final = values[14];
        servico.criado_em = Conversor.GetDateTime(values[15]);
        servico.vencimento = Conversor.GetDateTime(values[16]);
        servico.duracao_feito = Conversor.GetTimeSpan(values[17]);
        servico.desloca_feito = Conversor.GetTimeSpan(values[18]);
        servico.tipo_atividade = values[19];
        servico.tipo_atividade_1 = values[20];
        servico.ordem_de_servico = Conversor.GetNumberLong(values[21]);
        servico.numero_da_conta = Conversor.GetNumberLong(values[22]);
        servico.habilidade_de_trabalho = values[23];
        servico.area_trabalho = Conversor.GetLocationNumber(values[24]);
        servico.primeira_operacao_manual = values[25];
        servico.primeira_operacao_manual_login = values[26];
        servico.primeira_operacao_manual_nome = values[27];
        servico.horario_em_rota = values[28];
        servico.data_inicio_de_turno = Conversor.GetDateTime(values[29]);
        servico.data_do_ro = values[30];
        servico.roteado_automaticamente_ate_o_momento = Conversor.GetDateOnly(values[31]);
        servico.roteado_automaticamente_ate_o_recurso = Conversor.GetNumberShort(values[32]);
        servico.roteado_automaticamente_ate_o_recurso_nome = values[33];
        servico.id_do_recurso = Conversor.GetNumberShort(values[34]);
        servico.primeira_operacao_manual_executada_por_usuario = Conversor.GetNumberShort(values[35]);
        servico.usuario_conclusao = values[36];
        servico.coordenada_x = Conversor.GetNumberDouble(values[37]);
        servico.coordenada_y = Conversor.GetNumberDouble(values[38]);
        servico.exatidao_da_coordenada = values[39];
        servico.status_da_coordenada = values[40];
        servico.codigos_fechamento = values[41];
        servico.lg_ctrl_tipo_fechamento_ok = values[42];
        servico.cod_fechamento_preenchido = values[43];
        servico.cods_de_fechamento = values[44];
        servico.label_do_veiculo = values[45];
        servico.id_matricula_lider = Conversor.GetNumberMiddle(values[46]);
        servico.id_matricula_auxiliares = Conversor.GetNumberMiddle(values[47]);
        servico.id_matricula_guarda = Conversor.GetNumberMiddle(values[48]);
        servico.observacao = values[49];
        servico.descricao_breve_do_conteudo_da_nota = values[50];
        servico.sub_bairro = values[51];
        servico.lg_flag_preech_fechamento = values[52];
        servico.codigos_de_fechamento_da_atividade_pai_v03 = values[53];
        servico.lg_ctrl_reprov_flag = values[54];
        servico.numero_da_instalacao = Conversor.GetNumberLong(values[55]);
        servico.edificio = values[56];
        servico.complemento = values[57];
        servico.intervalo_de_tempo = values[58];
        servico.motivo_de_rejeicao = values[59].Split(' ').First();
        servico.tipo_de_nota_de_servico = values[60];
        servico.tempo_de_reserva_da_atividade = Conversor.GetDateTime(values[61]);
        servico.debitos_cliente = Conversor.GetNumberDouble(values[62]);
        servico.balde_origem = values[63];
        servico.tipo_de_ligacao = values[64];
        servico.cliente_assinou_toi = values[65];
        servico.recusou_a_assinar_toi = values[66];
        servico.recusou_receber_toi = values[67];
        servico.autorizou_levantamento_de_carga = values[68];
        servico.desloca_estimado = Conversor.GetTimeSpan(values[69]);
        servico.duracao_estimado = Conversor.GetTimeSpan(values[70]);
        servico.abrangencia = values[71];
        servico.motivo_indisponibilidade = values[72];
        servico.chi = Conversor.GetNumberShort(values[73]);
        servico.tempo_interrompido = Conversor.GetNumberShort(values[74]);
        servico.valor_compensacao_financeira = Conversor.GetNumberShort(values[75]);
        servico.codigos_concaternados = Conversor.Concatenar(servico.cods_de_fechamento, servico.motivo_de_rejeicao);
        servico.abreviacao = Conversor.Abreviacao(servico.recurso);
        servico.identificador = Conversor.Identificador(servico.dia, servico.abreviacao);
        servico.timestamp = Conversor.GetDateTime(servico.dia, servico.hora_final);
        var atividade = this.database.servico_tipo.Find(servico.tipo_de_nota_de_servico);
        if(atividade != null) servico.id_atividade = this.database.atividade.Where(a => a.atividade == atividade.servico_tipo).Single().id_atividade;
        var processo = this.database.processo_atividade.Find(servico.id_atividade);
        if(processo != null) servico.id_processo = processo.id_processo;
        if(servico.codigos_concaternados == "20.5") servico.id_servico_situacao = this.database.servico_situacao.Where(s => s.servico_situacao == "concluído").Single().id_servico_situacao;
        servicos.Add(servico);
      }
    }
    return servicos;
  }
  public List<Composicao> Composicao()
  {
    var temp = String.Empty;
    var composicoes = new List<Composicao>();
    if (Path.GetExtension(filename) != ".xlsx")
      throw new InvalidOperationException("Tipo de arquivo inválido!");
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    using (var reader = new ExcelPackage(stream))
    {
      if(reader.Workbook.Worksheets.Count > 1)
        throw new InvalidOperationException("O arquivo enviado tem mais de uma planilha!");
      var worksheet = reader.Workbook.Worksheets[0];
      var colCount = worksheet.Dimension.Columns;
      var primeira_linha = new List<String>();
      primeira_linha[0] = colCount.ToString();
      for(int col = 1; col <= colCount; col++)
      {
        temp = worksheet.GetValue<String>(1, col);
        if (temp == null || temp == String.Empty) continue;
        primeira_linha[col] = temp.ToLower();
      }
      var cabecalho = Cabecalho(primeira_linha);
      var rowCount = worksheet.Dimension.Rows;
      for(int row = 2; row <= rowCount; row++)
      {
        var composicao = new Composicao();


        temp = worksheet.GetValue<string>(row, cabecalho["data"]);
        composicao.dia = Conversor.GetDateOnly(temp);
        if(composicao.dia == null)
          composicao.validacao.Add($"A data informada ({temp}) é inválida!");


        temp = worksheet.GetValue<string>(row, cabecalho["adesivo"]);
        composicao.adesivo = Conversor.GetNumberMiddle(temp);
        if(composicao.adesivo == null)
          composicao.validacao.Add($"O adesivo informado ({temp}) é inválido!");

        temp = worksheet.GetValue<string>(row, cabecalho["placa"]);
        composicao.placa = Conversor.GetTextPlate(temp);
        if(composicao.placa == null)
          composicao.validacao.Add($"A placa informada ({temp}) é inválida!");

        temp = worksheet.GetValue<string>(row, cabecalho["recurso"]);
        composicao.recurso = Conversor.GetTextResource(temp);
        if(composicao.recurso == null)
          composicao.validacao.Add($"O recurso informado ({temp}) é inválido!");

        temp = worksheet.GetValue<string>(row, cabecalho["atividade"]);
        temp = composicao.SanitizarAlavanca(temp);
        temp = composicao.IsPesado(temp);
        temp = composicao.IsNoturno(temp);
        var atividade = this.database.atividade.Where(a => a.atividade == temp).SingleOrDefault();
        if(atividade != null)
          composicao.id_atividade = atividade.id_atividade;
        else
          composicao.validacao.Add($"A atividade informada ({temp}) é inválida!");

        temp = worksheet.GetValue<string>(row, cabecalho["motorista"]);
        composicao.motorista = temp;

        temp = worksheet.GetValue<string>(row, cabecalho["id_motorista"]);
        composicao.id_motorista = Conversor.GetNumberMiddle(temp);
        if(composicao.id_motorista == null)
          composicao.validacao.Add($"A matrícula 1 informada ({temp}) é inválida!");

        if(!this.if_exist(composicao.id_motorista, composicao.motorista))
          composicao.validacao.Add($"{composicao.id_motorista}: {composicao.motorista} não foi encontrado na lista ou nome não corresponde a matrícula!");

        temp = worksheet.GetValue<string>(row, cabecalho["ajudante"]);
        composicao.ajudante = temp;

        temp = worksheet.GetValue<string>(row, cabecalho["id_ajudante"]);
        composicao.id_ajudante = Conversor.GetNumberMiddle(temp);
        if(composicao.id_ajudante == null)
          composicao.validacao.Add($"A matrícula 2 informada ({temp}) é inválida!");

        if (!this.if_exist(composicao.id_ajudante, composicao.ajudante))
          composicao.validacao.Add($"{composicao.id_ajudante}: {composicao.ajudante} não foi encontrado na lista ou nome não corresponde a matrícula!");

        temp = worksheet.GetValue<string>(row, cabecalho["telefone"]);
        composicao.telefone = Conversor.GetPhoneNumber(temp);
        if(composicao.telefone == null)
          composicao.validacao.Add($"O telefone informado ({temp}) é inválido!");
        }

        temp = worksheet.GetValue<string>(row, cabecalho["supervisor"]);
        composicao.supervisor = temp;

        if (cabecalho.TryGetValue("id_supervisor", out Int32 coluna))
        {
          temp = worksheet.GetValue<string>(row, coluna);
          if(Int32.TryParse(temp, out Int32 id_supervisor))
          {
            composicao.id_supervisor = id_supervisor;
          }
          else
          {
            composicao.validacao.Add($"A matrícula sup. informada ({temp}) é inválida!");
          }
        }
        else
        {
          var id_supervisor = this.if_exist(composicao.supervisor);
          composicao.id_supervisor = id_supervisor;
        }
        if(!this.if_exist(composicao.id_supervisor, composicao.supervisor))
          composicao.validacao.Add($"{composicao.id_supervisor}: {composicao.supervisor} não foi encontrado na lista ou nome não corresponde a matrícula!");

        temp = worksheet.GetValue<string>(row, cabecalho["regional"]);
        temp = composicao.SanitizarRegional(temp);
        composicao.id_regional = this.database.regional.Where(r => r.regional == temp).Single().id_regional;

        if (cabecalho.TryGetValue("controlador", out coluna))
        {
          temp = worksheet.GetValue<string>(row, coluna);
          composicao.controlador = temp;
          var id_controlador = this.if_exist(composicao.controlador);
          composicao.id_controlador = id_controlador;
          if(composicao.id_controlador == 0)
            composicao.validacao.Add($"{composicao.id_controlador}: {composicao.controlador} não foi encontrado na lista ou nome não corresponde a matrícula!");
        }

        composicao.justificada = cabecalho.TryGetValue("justificada", out coluna) ? worksheet.GetValue<string>(row, coluna) : null;
        composicao.situacao = cabecalho.TryGetValue("situacao", out coluna) ? worksheet.GetValue<string>(row, coluna) : null;
        composicao.tecnico = cabecalho.TryGetValue("tecnico", out coluna) ? worksheet.GetValue<string>(row, coluna) : null;

        if((composicao.dia != DateOnly.MinValue) && (composicao.recurso != null))
        {
          composicao.abreviacao = Conversor.Abreviacao(composicao.recurso);
          composicao.identificador = Conversor.Identificador(composicao.dia, composicao.abreviacao);
        }

        // composicao.id_processo = this.is_setor(composicao.atividade);

        composicoes.Add(composicao);
      }
    }
    return composicoes;
  }
  private bool if_exist(Int32? matricula, String? nome_colaborador)
  {
    if(matricula == null || nome_colaborador == null) return false;
    var func = this.database.funcionario.Find(matricula);
    if(func == null) return false;
    if(!(func.nome_colaborador.ToLower() == nome_colaborador.ToLower())) return false;
    return true;
  }
  private Int32 if_exist(String? funcionario)
  {
    if(funcionario == null) return 0;
    var func = this.database.funcionario.Where(o => o.nome_colaborador.ToLower() == funcionario.ToLower()).SingleOrDefault();
    if(func == null) return 0;
    return func.matricula;
  }
  private enum ExpectedType {Text, Number, Date, Time, Enum, Placa}
  private String abreviacao(String recurso)
  {
    var re1 = new System.Text.RegularExpressions.Regex("^([A-Z]{3,})");
    var re2 = new System.Text.RegularExpressions.Regex("([A-Z][a-z]{1,})");
    var re3 = new System.Text.RegularExpressions.Regex("([0-9]{3})");
    if(!re3.IsMatch(recurso)) return String.Empty;
    var abreviado = "";
    recurso = recurso.Replace('–', '-');
    abreviado += re1.Match(recurso).Value;
    if(re2.Match(recurso).Value == "Religa") abreviado += 'R';
    if(re2.Match(recurso).Value == "Corte") abreviado += 'C';
    abreviado += re3.Match(recurso).Value;
    return abreviado;
  }
  private Dictionary<String, Int32> Cabecalho(List<String> primeira_linha)
  {
    Dictionary<String, Int32> cabecalho = new();
    var apontador = 1;
    do
    {
      switch(primeira_linha[apontador])
      {
        case null: break;
        case "data": cabecalho.Add("data", apontador); break;
        case "recurso": cabecalho.Add("recurso", apontador); break;
        case "serviço": cabecalho.Add("recurso", apontador); break;
        case "bdi": cabecalho.Add("recurso", apontador); break;
        case "placa": cabecalho.Add("placa", apontador); break;
        case "adesivo light": cabecalho.Add("adesivo", apontador); break;
        case "justificada": cabecalho.Add("justificada", apontador); break;
        case "regional": cabecalho.Add("regional", apontador); break;
        case "área de atuação": cabecalho.Add("regional", apontador); break;
        case "situação": cabecalho.Add("situacao", apontador); break;
        case "atividade": cabecalho.Add("atividade", apontador); break;
        case "alavanca": cabecalho.Add("atividade", apontador); break;
        case "matrícula 01": cabecalho.Add("id_motorista", apontador); break;
        case "executor 01": cabecalho.Add("motorista", apontador); break;
        case "matrícula 02": cabecalho.Add("id_ajudante", apontador); break;
        case "executor 02": cabecalho.Add("ajudante", apontador); break;
        case "telefone": cabecalho.Add("telefone", apontador); break;
        case "telefone equipe": cabecalho.Add("telefone", apontador); break;
        case "matricula sup": cabecalho.Add("id_supervisor", apontador); break;
        case "supervisor empreiteira": cabecalho.Add("supervisor", apontador); break;
        case "qtr": cabecalho.Add("controlador", apontador); break;
        case "técnico light": cabecalho.Add("tecnico", apontador); break;
        default: throw new InvalidOperationException("O nome da coluna não foi reconhecido!");
      }
      apontador += 1;
    } while (apontador < primeira_linha.Count);
    return cabecalho;
  }
}
