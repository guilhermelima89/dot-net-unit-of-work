using Api.Data;
using Api.Interfaces;
using Api.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class TelefonePessoaRepository : Repository<TelefonePessoa>, ITelefonePessoaRepository
{
    public TelefonePessoaRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<TelefonePessoa>> ObterTelefonesPorPessoa(int pessoaId)
    {
        return await Context.TelefonePessoa
            .Where(x => x.PessoaId == pessoaId)
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();
    }
}