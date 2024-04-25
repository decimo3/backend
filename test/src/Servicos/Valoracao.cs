using Xunit;
using backend.Models;
namespace TestAPI
{
  public partial class Testes
  {
    [Fact]
    public void ValoracaoTeste()
    {
      // Arrange
      var text = System.IO.File.ReadAllText("./SampleData/Servicos.json");
      var servicos = System.Text.Json.JsonSerializer.Deserialize<List<Servico>>(text) ?? throw new NullReferenceException();
      foreach (var servico in servicos)
      {
        var anterior = servico.id_grupo_codes ?? throw new NullReferenceException();
        servico.id_grupo_codes = String.Empty;
        // Act
        servico.Valoracao();
        // Assert
        this.output.WriteLine($"Valor esperado: {anterior}, Valor atual: {servico.id_grupo_codes}");
        Assert.Equal(anterior, servico.id_grupo_codes);
      }
    }
  }
}