using Api.Data;
using Api.Interfaces;
using Api.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class EmailPessoaRepository : Repository<EmailPessoa>, IEmailPessoaRepository
{
    public EmailPessoaRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<EmailPessoa>> ObterEmailsPorPessoa(int pessoaId)
    {
        return await Context.EmailPessoa
            .Where(x => x.PessoaId == pessoaId)
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();
    }
}