using Xunit;
using backend.Models;
namespace TestAPI
{
  public partial class Testes
  {
    [Fact]
    public void DiasUteisTeste()
    {
      var text = System.IO.File.ReadAllText("./SampleData/DiasUteis.json");
      var dias = System.Text.Json.JsonSerializer.Deserialize<List<DiasUteis>>(text) ?? throw new NullReferenceException();
      foreach (var dia in dias)
      {
        // Arrange
        var hoje = dia.referencia;
        // Act
        var diasUteis = new DiasUteis(hoje);
        // Assert
        this.output.WriteLine($"Valor referencia esperado: {dia.referencia}, Valor referencia calculado: {diasUteis.referencia}");
        Assert.Equal(dia.referencia, diasUteis.referencia);
        this.output.WriteLine($"Valor identificador esperado: {dia.identificador}, Valor identificador calculado: {diasUteis.identificador}");
        Assert.Equal(dia.identificador, diasUteis.identificador);
        this.output.WriteLine($"Valor dias_uteis esperado: {dia.dias_uteis}, Valor dias_uteis calculado: {diasUteis.dias_uteis}");
        Assert.Equal(dia.dias_uteis, diasUteis.dias_uteis);
      }
    }
  }
}
