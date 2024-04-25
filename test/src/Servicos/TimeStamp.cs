using Xunit;
using backend.Models;
namespace TestAPI
{
  public partial class Testes
  {
    [Fact]
    public void TimestampTeste()
    {
      // Arrange
      var text = System.IO.File.ReadAllText("./SampleData/Servicos.json");
      var servicos = System.Text.Json.JsonSerializer.Deserialize<List<Servico>>(text) ?? throw new NullReferenceException();
      foreach (var servico in servicos)
      {
        var anterior = servico.timestamp ?? throw new NullReferenceException();
        servico.timestamp = null;
        // Act
        servico.Timestamp();
        // Assert
        Assert.Equal(anterior, servico.timestamp);
      }
    }
  }
}