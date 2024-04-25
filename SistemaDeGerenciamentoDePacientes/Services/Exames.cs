namespace SistemaDeGerenciamentoDePacientes.Services
{
    public interface IExames
    {
        string Exame1(int? idade, char? sexo);
        string Exame2(int? idade, char? sexo);
    }

    public class Exames : IExames
    {
        public string Exame1(int? idade, char? sexo)
        {
            string result = "";

            if(idade < 10)
            {
                result = "valor entre 5 e 10";
            }
            if(idade >= 10 && sexo == 'M')
            {
                result = "valor entre 10 e 15";
            }
            if (idade >= 10 && sexo == 'F')
            {
                result = "valor entre 10 e 20";
            }

            return result;
        }

        public string Exame2(int? idade, char? sexo)
        {
            string result = "";

            if (idade < 12)
            {
                result = "CRIANÇA";
            }
            if (idade >= 12 && idade < 18)
            {
                result = "ADOLESCENTE";
            }
            if (sexo == 'M' && idade >= 18)
            {
                result = "HOMEM ADULTO";
            }
            if (sexo == 'F' && idade >= 18)
            {
                result = "MULHER ADULTO";
            }

            return result;
        }
    }
}
