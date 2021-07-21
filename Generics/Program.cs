using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            // Problema a ser resolvido: Não criar um método cruzar para cada espécie de Mamifero, e sim uma genérica.

            // Código sem Generics
            //var macho = new Cachorro() { Nome = "João"};
            //var femea = new Cachorro() { Nome = "Maria" };
            //var filhote = new Cachorro().CruzarCachorro(macho, femea);
            //    public Cachorro CruzarCachorro(Cachorro macho, Cachorro femea)
            //    {
            //        var filhote = new Cachorro() { Pai = macho, Mae = femea };
            //        return filhote;
            //    }
            //Console.WriteLine($"Filho de {filhote.Pai.Nome} e {filhote.Mae.Nome}");

            // Código com Generics:
            var machoCachorro = new Cachorro();
            var femeaCachorro = new Cachorro();
            var filhote = Cruzar(machoCachorro, femeaCachorro, "cachorro");
            Console.WriteLine($"Filho do tipo: {filhote.especie}");
            var machoGato = new Gato();
            var femeaGato = new Gato();
            var filhote2 = Cruzar(machoGato, femeaGato, "gato");
            Console.WriteLine($"Filho do tipo: {filhote2.especie}");
            var machoElefante = new Elefante();
            var femeaElefante = new Elefante();
            var filhote3 = Cruzar(machoElefante, femeaElefante, "elefante");
            Console.WriteLine($"Filho do tipo: {filhote3.especie}");
        }

        public static T Cruzar<T>(T macho, T femea, string especie) where T : Mamifero<T>
        {
            var filhoteGenerico = Activator.CreateInstance<T>(); // cria um tipo Genérico
            filhoteGenerico.Mae = femea;
            filhoteGenerico.Pai = macho;
            filhoteGenerico.especie = especie;
            return filhoteGenerico;
        }
    }


    // Código com Generics
    public abstract class Mamifero<T> where T : Mamifero<T>
    {

        public string Nome { get; set; }
        public T Pai { get; set; }
        public T Mae { get; set; }

        public string especie { get; set; }


    }

    public class Cachorro : Mamifero<Cachorro>
    {
        public string Raca { get; set; }
    }

    public class Gato : Mamifero<Gato>
    {
        public int qtdPelos { get; set; }
    }

    public class Elefante : Mamifero<Elefante>
    {
        public string corElefante { get; set; }
    }
    // Código Sem Generics
    //public abstract class Mamifero {       

    //    public string Nome { get; set; }
    //    public Mamifero Pai { get; set; }
    //    public Mamifero Mae { get; set; } 
    //    public decimal Peso { get; set; }
    //}

    //public class Cachorro : Mamifero
    //{   
    //    public string Raca { get; set; }

    //    public Cachorro CruzarCachorro(Cachorro macho, Cachorro femea)
    //    {
    //        var filhote = new Cachorro() { Pai = macho, Mae = femea };
    //        return filhote;
    //    }
    //}

    //public class Gato : Mamifero
    //{
    //    public int qtdPelos { get; set; }
    //}

    //public class Elefante : Mamifero
    //{
    //    public string corElefante { get; set; }
    //}
}
