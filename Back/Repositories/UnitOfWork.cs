using Api.Data;
using Api.Interfaces;

namespace Api.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    private IPessoaRepository _pessoaRepository;
    public IPessoaRepository PessoaRepository => _pessoaRepository ??= new PessoaRepository(_context);

    private ILogRepository _logRepository;
    public ILogRepository LogRepository => _logRepository ??= new LogRepository(_context);

    private IEmailPessoaRepository _emailPessoaRepository;
    public IEmailPessoaRepository EmailPessoaRepository => _emailPessoaRepository ??= new EmailPessoaRepository(_context);

    private ITelefonePessoaRepository _telefonePessoaRepository;
    public ITelefonePessoaRepository TelefonePessoaRepository => _telefonePessoaRepository ??= new TelefonePessoaRepository(_context);

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
