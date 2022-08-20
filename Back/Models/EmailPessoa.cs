namespace Api.Models;

public class EmailPessoa : Entity
{
    public string Email { get; set; }
    public int Sequencia { get; set; }
    public int PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
}