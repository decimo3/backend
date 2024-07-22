using Xunit;
using backend.Models;
using backend.Services;
namespace TestAPI
{
  public class ServicoTeste
  {
    [Fact]
    public void ServicoFromArquivoTeste()
    {
      using var stream = new MemoryStream(File.ReadAllBytes("./SampleData/Servicos.csv"));
      var servicos = new backend.Services.FileManager(stream, "Servicos.csv").Relatorio() ?? throw new NullReferenceException();
      Assert.Equal(62, servicos.Count);
    }
  }
}
