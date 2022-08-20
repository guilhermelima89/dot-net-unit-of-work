using Api.Models;

namespace Api.Interfaces;

public interface IEmailPessoaRepository : IRepository<EmailPessoa>
{
    Task<List<EmailPessoa>> ObterEmailsPorPessoa(int pessoaId);
}