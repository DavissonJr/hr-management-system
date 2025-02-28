namespace RH.API.Dto;

public interface IColaboradorDto
{
    string Nome { get; set; }
    string CPF { get; set; }
    int Matricula { get; set; }
    int EmpresaId { get; set; }
}
