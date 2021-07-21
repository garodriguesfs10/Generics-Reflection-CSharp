using System;
using System.Text;

namespace Reflection
{
    class Program
    {
        // Problema a ser resolvido: Criar somente um método de Log pegando todos os atributos da classe referenciada.
        static void Main(string[] args)
        {
            var pessoa = new Pessoa() { Nome = "Gabriel", Idade = 24, Profissao = "Desenvolvedor" };
            var equipamento = new Equipamento() { Tipo = "Industrial", Marca = "3M", Quantidade = 8 };
            var livro = new Livro() { Nome = "Clean Architecture", Autor = "Billie", Edicao = 3 };

            Log(pessoa);
            Log(equipamento);
            Log(livro);
        }

        public static void Log(object obj)
        {

            var tipo = obj.GetType();
            var propriedades = tipo.GetProperties();

            var builder = new StringBuilder();
            builder.AppendLine($"Data de log: {DateTime.Now}");
            //Jeito Antigo -> builder.AppendLine($"Nome da pessoa: {pessoa.Nome}");
            // usando Reflection:
            foreach (var p in propriedades)
            {
                builder.AppendLine($"{p.Name}: {p.GetValue(obj)}");
            }
            builder.AppendLine("-------------");
            var texto = builder.ToString();

            Console.WriteLine(texto);
        }
    }

    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public string Profissao { get; set; }
    }

    public class Equipamento
    {
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public int Quantidade { get; set; }
    }

    public class Livro
    {
        public string Nome { get; set; }
        public string Autor { get; set; }

        public int Edicao { get; set; }
    }
}
