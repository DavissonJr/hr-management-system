namespace RH.API.Domain;

public class Colaborador
{
    public int ColaboradorId { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public int Matricula { get; set; }
    public int EmpresaId { get; set; }
    public string EmpresaNome { get; set; }
}
