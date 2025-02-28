namespace RH.API.Dto;

public class CreateColaboradorDto : IColaboradorDto
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public int Matricula { get; set; }
    public int EmpresaId { get; set; }
}
