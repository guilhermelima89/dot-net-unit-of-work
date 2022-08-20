namespace Api.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task Commit();

    IPessoaRepository PessoaRepository { get; }
    ITelefonePessoaRepository TelefonePessoaRepository { get; }
    IEmailPessoaRepository EmailPessoaRepository { get; }
    ILogRepository LogRepository { get; }
}
