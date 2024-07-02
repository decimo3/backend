using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Services;
namespace backend.Controllers;
[ApiController]
[Route("[controller]")]
public class ValoracaoController : ControllerBase
{
    private readonly Database _context;
    private readonly AlteracoesServico alteracaoLog;
    public ValoracaoController(Database context, IHttpContextAccessor httpContext, AlteracoesServico alteracaoLog)
    {
        _context = context;
        this.alteracaoLog = alteracaoLog;
        this.alteracaoLog.tabela = this.ToString()!;
        if(httpContext.HttpContext != null)
        {
          var funcionario = (Funcionario?)httpContext.HttpContext.Items["User"];
          if(funcionario != null) this.alteracaoLog.responsavel = funcionario.matricula;
        }
    }
    private bool ValoracaoExists(Int32 regional, Int32 viatura, Int32 atividade, String codigo)
    {
        return (_context.valoracao?.Any(e => e.id_regional == regional && e.id_tipo_viatura == viatura && e.id_atividade == atividade && e.codigo == codigo)).GetValueOrDefault();
    }
    [HttpPost]
    public async Task<ActionResult<Valoracao>> PostValoracao(Valoracao valoracao)
    {
        if(!this.alteracaoLog.is_ready()) return Unauthorized("Usuário não foi encontrado no contexto da solicitação!");
        if (_context.valoracao == null) return Problem("Entity set 'Database.valoracao'  is null.");
        if (ValoracaoExists(valoracao.id_regional, valoracao.id_tipo_viatura, valoracao.id_atividade, valoracao.codigo)) return Conflict();
        _context.valoracao.Add(valoracao);
        try
        {
            await _context.SaveChangesAsync();
            alteracaoLog.Registrar("POST", null, valoracao);
            return CreatedAtAction("GetValoracao", new { regional = valoracao.id_regional, viatura = valoracao.id_tipo_viatura, atividade = valoracao.id_atividade, codigo = valoracao.codigo }, valoracao);
        }
        catch (DbUpdateConcurrencyException erro)
        {
            return Problem(erro.InnerException!.Message);
        }
        catch (Exception erro)
        {
            return Problem(erro.Message);
        }
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Valoracao>>> Getvaloracao()
    {
        if (_context.valoracao == null) return NotFound();
        return await _context.valoracao.ToListAsync();
    }
    [HttpDelete("{regional}/{viatura}/{atividade}/{codigo}")]
    public async Task<IActionResult> DeleteValoracao(Int32 regional, Int32 viatura, Int32 atividade, String codigo)
    {
        if(!this.alteracaoLog.is_ready()) return Unauthorized("Usuário não foi encontrado no contexto da solicitação!");
        if (_context.valoracao == null) return NotFound();
        var valoracao = await _context.valoracao.FindAsync(regional, viatura, atividade, codigo);
        if (valoracao == null) return NotFound();
        _context.valoracao.Remove(valoracao);
        try
        {
            await _context.SaveChangesAsync();
            alteracaoLog.Registrar("DELETE", valoracao, null);
            return NoContent();
        }
        catch (DbUpdateConcurrencyException erro)
        {
            return Problem(erro.InnerException!.Message);
        }
        catch (Exception erro)
        {
            return Problem(erro.Message);
        }
    }
}
