using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using backend.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyModel.Resolution;
using OfficeOpenXml;
namespace backend.Services;
public class FileManager
{
  private readonly IFormFile file;
  private readonly Database database;
  private readonly Stream stream;
  public FileManager(Database database, IFormFile file)
  {
    this.database = database;
    this.file = file;
    this.stream = this.file.OpenReadStream();
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
        writer.Write(' ');
        continue;
      }
      writer.Write(letra);
    }
    writer.Flush();
    memory.Position = 0;
    return new StreamReader(memory);
  }
  public List<Servico> Relatorio()
  {
    string ext = Path.GetExtension(file.FileName);
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
        if(!Int32.TryParse(values[21], out int nota)) continue;
        servicos.Add(new Servico {
          recurso = values[0],
          dia = DateOnly.Parse(values[1]),
          indentificador = Int32.Parse(values[2]),
          hora_inicio = TimeOnly.TryParse(values[12], out TimeOnly inicio) ? inicio : null,
          hora_final = TimeOnly.TryParse(values[13], out TimeOnly final) ? final : null,
          duracao_feito = TimeOnly.TryParse(values[17], out TimeOnly duracao) ? duracao : null,
          desloca_feito = TimeOnly.TryParse(values[18], out TimeOnly desloca) ? desloca : null,
          tipo_atividade = values[20],
          servico = nota,
          observacao = values[49],
          instalacao = Int32.TryParse(values[55], out int inst) ? inst : 0,
          tipo_servico = values[60],
          Desloca_estima = TimeOnly.TryParse("00:" + values[69], out TimeOnly desloca_est) ? desloca_est : null,
          duracao_estima = TimeOnly.TryParse("00:" + values[70], out TimeOnly duracao_est) ? duracao_est : null,
          codigos = (values[44] != String.Empty) ? values[44] : values[59].Split(' ')[0],
          status = (values[3] == "não concluído" && values[59].Split(' ')[0] == "20.5") ? "concluído" : values[3],
        });
      }
    }
    return servicos;
  }
  public List<Composicao> Composicao()
  {
    string ext = Path.GetExtension(file.FileName);
    if (ext != ".xlsx") throw new InvalidOperationException("Tipo de arquivo inválido!");
    var composicoes = new List<Composicao>();
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    using (var reader = new ExcelPackage(stream))
    {
      if(reader.Workbook.Worksheets.Count > 1)
      {
        throw new InvalidOperationException("O arquivo enviado tem mais de uma planilha!");
      }
      var worksheet = reader.Workbook.Worksheets[0];
      var colCount = worksheet.Dimension.Columns;
      if(colCount != 13)
      {
        var maisoumenos = (colCount > 13) ? "mais" : "menos";
        throw new InvalidOperationException($"O arquivo enviado tem colunas a {maisoumenos} que o padrão!");
      }
      var rowCount = worksheet.Dimension.Rows;
      string? temp, test;
      for(int row = 2; row < rowCount; row++)
      {
        var composicao = new Composicao();

        temp = worksheet.GetValue<string>(row, 1);
        test = this.is_valid(temp, row, "Dia", ExpectedType.Date);
        if (test == null)
        {
          try
          {
            composicao.dia = DateOnly.Parse(temp[0..9]);
          }
          catch
          {
            var a = Int32.Parse(temp);
            var b = DateTime.FromOADate(a);
            composicao.dia = DateOnly.FromDateTime(b);
          }
        }
        else composicao.validacao.Add(test);

        temp = worksheet.GetValue<string>(row, 2);
        test = this.is_valid(temp, row, "Adesivo", ExpectedType.Number);
        if (test == null) composicao.adesivo = Int32.Parse(temp);
        else composicao.validacao.Add(test);

        temp = worksheet.GetValue<string>(row, 3);
        test = this.is_valid(temp, row, "Placa", ExpectedType.Text);
        if (test == null) composicao.placa = temp.Replace("-", "").Replace(" ", "");
        else composicao.validacao.Add(test);

        temp = worksheet.GetValue<string>(row, 4);
        test = this.is_valid(temp, row, "Recurso", ExpectedType.Text);
        if(test == null) composicao.recurso = temp.Trim();
        else composicao.validacao.Add(test);

        temp = worksheet.GetValue<string>(row, 5);
        test = this.is_valid(temp, row, "Atividade", ExpectedType.Enum);
        if(test == null)
          composicao.atividade = Enum.Parse<Atividade>(temp
            .Replace("RELIGA POSTO", "AVANCADO")
            .Replace("RELIGA CAMINHÃO", "CAMINHAO")
            .Replace("EMERGÊNCIA", "EMERGENCIA"));
        else composicao.validacao.Add(test);

        var func = new Funcionario();

        temp = worksheet.GetValue<string>(row, 6);
        test = this.is_valid(temp, row, "Motorista", ExpectedType.Text);
        if(test == null)
        {
          composicao.motorista = temp.Trim();
          func.nome_colaborador = temp.Trim();
        }
        else composicao.validacao.Add(test);

        temp = worksheet.GetValue<string>(row, 7);
        test = this.is_valid(temp, row, "Mat. Mot.", ExpectedType.Number);
        if(test == null)
        {
          composicao.id_motorista = Int32.Parse(temp);
          func.matricula = Int32.Parse(temp);
        }
        else composicao.validacao.Add(test);

        func.funcao = TipoFuncionario.ELETRICISTA;
        if(!this.if_exist(func)) composicao.validacao.Add($"{func.matricula}: {func.nome_colaborador} não foi encontrado na lista ou nome não corresponde a matrícula!");

        func = new Funcionario();

        temp = worksheet.GetValue<string>(row, 8);
        test = this.is_valid(temp, row, "Ajudante", ExpectedType.Text);
        if (test == null)
        {
          composicao.ajudante = temp.Trim();
          func.nome_colaborador = temp.Trim();
        }
        else composicao.validacao.Add(test);

        temp = worksheet.GetValue<string>(row, 9);
        test = this.is_valid(temp, row, "Mat. Aju.", ExpectedType.Number);
        if(test == null)
        {
          composicao.id_ajudante = Int32.Parse(temp);
          func.matricula = Int32.Parse(temp);
        }
        else composicao.validacao.Add(test);

        func.funcao = TipoFuncionario.ELETRICISTA;
        if (!this.if_exist(func)) composicao.validacao.Add($"{func.matricula}: {func.nome_colaborador} não foi encontrado na lista ou nome não corresponde a matrícula!");

        temp = worksheet.GetValue<string>(row, 10);
        test = this.is_valid(temp, row, "Telefone", ExpectedType.Number);
        if(test == null)
        {
          temp = temp.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "");
          if(temp.Length == 9) temp = "21" + temp;
          if(temp.Length != 11) composicao.validacao.Add("A quantidade de dígitos do telefone está errada!");
          else composicao.telefone = Int64.Parse(temp);
        }
        else composicao.validacao.Add("O número de telefone não é válido!");

        func = new Funcionario();

        temp = worksheet.GetValue<string>(row, 11);
        test = this.is_valid(temp, row, "Mat. Sup.", ExpectedType.Number);
        if(test == null)
        {
          composicao.id_supervisor = Int32.Parse(temp);
          func.matricula = Int32.Parse(temp);
        }
        else composicao.validacao.Add(test);

        temp = worksheet.GetValue<string>(row, 12);
        test = this.is_valid(temp, row, "Supervisor", ExpectedType.Text);
        if(test == null)
        {
          composicao.supervisor = temp.Trim();
          func.nome_colaborador = temp.Trim();
        }
        else composicao.validacao.Add(test);

        func.funcao = TipoFuncionario.SUPERVISOR;
        if(!this.if_exist(func)) composicao.validacao.Add($"{func.matricula}: {func.nome_colaborador} não foi encontrado na lista ou nome não corresponde a matrícula!");

        temp = worksheet.GetValue<string>(row, 13);
        test = this.is_valid(temp, row, "Atividade", ExpectedType.Enum);
        if(test == null)
          composicao.regional = Enum.Parse<Regional>(temp
            .Replace("CAMPO GRANDE", "OESTE")
            .Replace("JACAREPAGUA", "OESTE"));
        else composicao.validacao.Add(test);

        composicoes.Add(composicao);
      }
    }
    return composicoes;
  }
  private string? is_valid(string? arg, int linha, string campo, ExpectedType expectedType)
  {
    if(arg == null) return "O valor não foi preenchido!";
    arg = arg.Trim();
    switch(expectedType)
    {
      case ExpectedType.Date:
        if (Int32.TryParse(arg, out Int32 diaExcel))
        {
          try
          {
              DateTime.FromOADate(diaExcel);
              return null;
          }
          catch
          {
              return "A data não pode ser reconhecida!";
          }
        }
        if(!DateOnly.TryParse(arg, out DateOnly diaTexto)) return "A data não pode ser reconhecida!";
      break;
      case ExpectedType.Time:
        if(!TimeOnly.TryParse(arg, out TimeOnly hrs)) return "A hora não pode ser reconhecida!";
      break;
      case ExpectedType.Number:
        arg = arg.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "");
        if(!Int64.TryParse(arg, out Int64 num)) return "A número contém caracteres inválidos!";
      break;
      case ExpectedType.Text:
        if(arg.Length < 5) return "O texto está incompleto ou vazio!";
      break;
      case ExpectedType.Enum:
        String[] enums = {"BAIXADA", "CAMPO GRANDE", "JACAREPAGUA", "CORTE", "RELIGA", "RELIGA POSTO", "RELIGA CAMINHÃO", "EMERGÊNCIA"};
        if(!enums.Contains(arg)) return "O texto encontrado não corresponde com o padrão!";
      break;
      case ExpectedType.Placa:
        var re = new System.Text.RegularExpressions.Regex("^[0-9A-Z]{3}-[0-9A-Z]{4}$");
        if (!re.IsMatch(arg)) return "O padrão da placa não está sendo obedecido! (I2E-AAAA)";
      break;
    }
    return null;
  }
  private bool if_exist(Funcionario funcionario)
  {
    var func = this.database.funcionario.Find(funcionario.matricula);
    if(func == null) return false;
    if(!(func.nome_colaborador == funcionario.nome_colaborador)) return false;
    if(!(func.funcao == funcionario.funcao)) return false;
    return true;
  }
  private enum ExpectedType {Text, Number, Date, Time, Enum, Placa}
}
