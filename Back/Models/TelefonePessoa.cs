namespace Api.Models;

public class TelefonePessoa : Entity
{
    public string Telefone { get; set; }
    public int Sequencia { get; set; }
    public int PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
}