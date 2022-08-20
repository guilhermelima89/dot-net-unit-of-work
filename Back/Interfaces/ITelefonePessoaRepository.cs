using Api.Models;

namespace Api.Interfaces;

public interface ITelefonePessoaRepository : IRepository<TelefonePessoa>
{
    Task<List<TelefonePessoa>> ObterTelefonesPorPessoa(int pessoaId);
}