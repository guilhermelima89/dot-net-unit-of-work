using Api.ViewModel;

namespace Api.Interfaces;

public interface IPessoaService
{
    Task<bool> Update(PessoaViewModel request);
}