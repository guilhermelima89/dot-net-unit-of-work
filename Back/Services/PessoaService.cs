using Api.Interfaces;
using Api.Models;
using Api.ViewModel;

namespace Api.Services;

public class PessoaService : IPessoaService
{
    private readonly IUnitOfWork _unitOfWork;

    public PessoaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Update(PessoaViewModel request)
    {
        var pessoa = await _unitOfWork.PessoaRepository.GetByIdAsync(1);

        if (pessoa is null) return false;

        await AdicionarEmail(pessoa.Id, request.Email);
        await AdicionarTelefone(pessoa.Id, request.Telefone);
        AdicionarLog(pessoa.Nome);

        await _unitOfWork.Commit();

        return true;
    }

    private async Task AdicionarEmail(int pessoaId, string email)
    {
        var meusEmails = await _unitOfWork.EmailPessoaRepository.ObterEmailsPorPessoa(pessoaId);

        var novaListaEmails = new List<EmailPessoa>();

        if (meusEmails.Count == 0)
        {
            NovoEmail(pessoaId, 1, email);
        }
        else
        {
            foreach (var meuEmail in meusEmails)
            {
                if (meuEmail.DataExclusao is null)
                {
                    meuEmail.DataExclusao = DateTime.Now;
                    novaListaEmails.Add(meuEmail);
                }
            }

            _unitOfWork.EmailPessoaRepository.UpdateRange(novaListaEmails);

            var ultimoEmail = meusEmails.Max(x => x.Sequencia);

            var sequencia = ultimoEmail + 1;

            NovoEmail(pessoaId, sequencia, email);
        }
    }

    private void NovoEmail(int pessoaId, int sequencia, string email)
    {
        var novoEmail = new EmailPessoa
        {
            PessoaId = pessoaId,
            Sequencia = sequencia,
            Email = email
        };

        _unitOfWork.EmailPessoaRepository.Add(novoEmail);
    }

    private async Task AdicionarTelefone(int pessoaId, string numero)
    {
        var meusTelefones = await _unitOfWork.TelefonePessoaRepository.ObterTelefonesPorPessoa(pessoaId);

        var novaListaTelefones = new List<TelefonePessoa>();

        if (meusTelefones.Count == 0)
        {
            NovoTelefone(pessoaId, 1, numero);
        }
        else
        {
            foreach (var telefone in meusTelefones)
            {
                if (telefone.DataExclusao is null)
                {
                    telefone.DataExclusao = DateTime.Now;
                    novaListaTelefones.Add(telefone);
                }
            }

            _unitOfWork.TelefonePessoaRepository.UpdateRange(novaListaTelefones);

            var ultimoTelefone = meusTelefones.Max(x => x.Sequencia);

            var sequencia = ultimoTelefone + 1;

            NovoTelefone(pessoaId, sequencia, numero);
        }

    }

    private void NovoTelefone(int pessoaId, int sequencia, string telefone)
    {
        var novoTelefone = new TelefonePessoa
        {
            PessoaId = pessoaId,
            Sequencia = sequencia,
            Telefone = telefone
        };

        _unitOfWork.TelefonePessoaRepository.Add(novoTelefone);
    }

    private void AdicionarLog(string nome)
    {
        var log = new Log
        {
            Descricao = $"Atualização de dados da pessoa : {nome}"
        };

        _unitOfWork.LogRepository.Add(log);
    }
}