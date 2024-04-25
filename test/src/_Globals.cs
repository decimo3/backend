using Xunit.Abstractions;
namespace TestAPI
{
  public partial class Testes
  {
    private readonly ITestOutputHelper output;
    public Testes(ITestOutputHelper output)
    {
      this.output = output;
    }
  }
}
