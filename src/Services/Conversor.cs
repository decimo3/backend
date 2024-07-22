using System.Text.RegularExpressions;
namespace backend.Services;
public static class Conversor
{
  public static DateTime? GetDateTime(DateOnly? date, TimeOnly? time)
  {
    if ((date == null) || (time == null)) return null;
    return ((DateOnly)date).ToDateTime((TimeOnly)time).ToUniversalTime();
  }
  public static DateTime? GetDateTime(String timestamp)
  {
    var pattern = "([0-9]{2})/([0-9]{2})/([0-9]{2}) ([0-9]{2}):([0-9]{2})";
    var re = new System.Text.RegularExpressions.Regex(pattern);
    var replace = re.Replace(timestamp, "20$3-$2-$1 $4:$5");
    return DateTime.TryParse(replace, out DateTime dt) ? dt.ToUniversalTime() : null;
  }
  public static DateOnly? GetDateOnly(String date)
  {
    var pattern = (date.Length == 8) ? @"([0-9]{2})/([0-9]{2})/([0-9]{2})" : @"([0-9]{2})/([0-9]{2})/([0-9]{4})";
    var re = new System.Text.RegularExpressions.Regex(pattern);
    var replace = re.Replace(date, "20$3-$2-$1");
    return DateOnly.TryParse(replace, out DateOnly dt) ? dt: null;
  }
  public static TimeOnly? GetTimeOnly(String time)
  {
    return TimeOnly.TryParse(time, out TimeOnly to) ? to : null;
  }
  public static TimeSpan? GetTimeSpan(String time)
  {
    if (Double.TryParse(time, out Double tm))
      return TimeSpan.FromMinutes(tm);
    return TimeSpan.TryParse(time, out TimeSpan to) ? to : null;
  }
  public static Int32? GetNumberShort(String number)
  {
    return Int32.TryParse(number, out Int32 num) ? num : null;
  }
  public static Int32? GetNumberMiddle(String number)
  {
    return Int32.TryParse(number, out Int32 num) ? num : null;
  }
  public static Int64? GetNumberLong(String number)
  {
    return Int64.TryParse(number, out Int64 num) ? num : null;
  }
  public static Double? GetNumberDouble(String number)
  {
    return Double.TryParse(number.Replace('.',','), out Double num) ? num : null;
  }
  public static String? Abreviacao(String recurso)
  {
    var re1 = new System.Text.RegularExpressions.Regex("^([A-Z]{3,})");
    var re2 = new System.Text.RegularExpressions.Regex("([A-Z][a-z]{1,})");
    var re3 = new System.Text.RegularExpressions.Regex("([0-9]{3})");
    if(!re3.IsMatch(recurso)) return null;
    var abreviado = String.Empty;
    abreviado += re1.Match(recurso).Value;
    if(re2.Match(recurso).Value == "Vistoriador") abreviado += 'V';
    if(re2.Match(recurso).Value == "Religa") abreviado += 'R';
    if(re2.Match(recurso).Value == "Corte") abreviado += 'C';
    abreviado += re3.Match(recurso).Value;
    return abreviado;
  }
  public static String? Identificador(DateOnly? date, String? abreviado)
  {
    if(date is null) return null;
    if(String.IsNullOrEmpty(abreviado)) return null;
    DateOnly data = (DateOnly)date;
    return String.Concat(data.ToString("yyyyMMdd"), abreviado);
  }
  public static String? Concatenar(String? execucao, String? rejeicao)
  {
    if(String.IsNullOrEmpty(execucao) && String.IsNullOrEmpty(rejeicao)) return null;
    return String.IsNullOrEmpty(rejeicao) ? execucao : rejeicao;
  }
  public static String? GetTextPlate(String text)
  {
    return new Regex(@"^[0-9A-Z]{3}(-)?[0-9A-Z]{4}$").IsMatch(text)
      ? text.Replace("-", "") : null;
  }
  public static String? GetTextResource(String text)
  {
    return new Regex("^([A-Z]{4,})(?: - [A-z]{3,})?( [-|–] Equipe )([0-9]{3})$").IsMatch(text)
      ? text : null;
  }
}
