namespace RH.API.Ultilities
{
    public class Metodos
    {
        public void ValidaCpf(string cpf)
        {
            if (cpf.Length != 11)
            {
                throw new Exception("O CPF deve conter 11 dígitos.");
            }

            // Primeiro dígito
            int soma = 0;
            for (int i = 0; i < 9; i++) // Passa pelos 9 primeiros dígitos
            {
                int digito = int.Parse(cpf[i].ToString()); // Pega o dígito
                int peso = 10 - i; // Peso 10 e vai diminuindo até 2
                soma += digito * peso; // Dígito vezes peso e adição com soma
            }

            int resto = soma % 11;
            int digito1;

            if (resto < 2)
            {
                digito1 = 0;
            }
            else
            {
                digito1 = 11 - resto;
            }

            // Segundo dígito
            soma = 0;
            for (int i = 0; i < 10; i++) // Passa pelos 10 primeiros dígitos
            {
                int digito = int.Parse(cpf[i].ToString());
                int peso = 11 - i; // Peso descendo de 11 e diminui até 2
                soma += digito * peso; // Peso x dígito e adiciona à soma
            }

            resto = soma % 11;
            int digito2;

            if (resto < 2)
            {
                digito2 = 0;
            }
            else
            {
                digito2 = 11 - resto;
            }

            // Verifica se os dígitos verificadores calculados são iguais aos do CPF
            if (int.Parse(cpf[9].ToString()) != digito1 || int.Parse(cpf[10].ToString()) != digito2)
            {
                throw new Exception("O CPF é inválido.");
            }
        }
    }
}
