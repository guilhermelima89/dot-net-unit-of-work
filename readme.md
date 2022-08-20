# .NET UNIT OF WORK

## Back-End

- Net 6
- EF Core
- Swagger
- Unit Of Work

#

# Back

### POC abordando Unit of Work, realizando atualização de dados de uma pessoa (email e telefone), porém realizando o commit no final.

```c#
public async Task<bool> Update(PessoaViewModel request)
{
    -- OBTER PESSOA ID = 1
    var pessoa = await _unitOfWork.PessoaRepository.GetByIdAsync(1);

    if (pessoa is null) return false;

    -- METODOS INTERNOS COM LOGICA
    await AdicionarEmail(pessoa.Id, request.Email);
    await AdicionarTelefone(pessoa.Id, request.Telefone);
    AdicionarLog(pessoa.Nome);

    -- REALIZAR COMMIT NO BANCO DE DADOS
    await _unitOfWork.Commit();

    return true;
}
```
