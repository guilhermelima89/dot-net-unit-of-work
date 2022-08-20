using Api.Interfaces;
using Api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{

    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] PessoaViewModel request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _pessoaService.Update(request);

        return Ok();
    }
}