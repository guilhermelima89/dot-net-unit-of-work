using Api.Data;
using Api.Interfaces;
using Api.Models;
using Data.Repositories;

namespace Api.Repositories;

public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
{
    public PessoaRepository(ApplicationDbContext context) : base(context)
    {
    }

}
