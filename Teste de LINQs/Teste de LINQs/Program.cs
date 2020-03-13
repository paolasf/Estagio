using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_de_LINQs
{
    class Program
    {
        public static void Main()
	    {
		    // Collection
		    IList<Disciplina> disciplinaLista = new List<Disciplina>() { 
				new Disciplina() { DisciplinaID = 1, DisciplinaNome = "Eletrônica Analógica", DisciplinaCreditos = 3} ,
                new Disciplina() { DisciplinaID = 2, DisciplinaNome = "Eletrônica Digital", DisciplinaCreditos = 3} ,
                new Disciplina() { DisciplinaID = 3, DisciplinaNome = "Física", DisciplinaCreditos = 4} ,
                new Disciplina() { DisciplinaID = 4, DisciplinaNome = "Física", DisciplinaCreditos = 1} ,
                new Disciplina() { DisciplinaID = 5, DisciplinaNome = "Gestão", DisciplinaCreditos = 1} ,
                new Disciplina() { DisciplinaID = 6, DisciplinaNome = "Cálculo", DisciplinaCreditos = 5} ,
                new Disciplina() { DisciplinaID = 7, DisciplinaNome = "Sinais e Sistemas", DisciplinaCreditos = 4} ,

            };

            int n;
            n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1: // Operador de filtro WHERE
                    var pesquisaDisciplinas = from s in disciplinaLista
                                              where s.DisciplinaCreditos > 0 && s.DisciplinaCreditos < 4
                                              select s;
                    // Resultado da filtragem
                    Console.WriteLine("Disciplinas com menos de 3 créditos:");
                    foreach (Disciplina std in pesquisaDisciplinas)
                        Console.WriteLine(std.DisciplinaNome);
                    Console.ReadLine();
                    break;


                case 2: // Operador de ordenação ORDERBY 
                    var orderByResult = from s in disciplinaLista
                                        orderby s.DisciplinaNome
                                        select s;
                    // Resultado da ordenação crescente
                    Console.WriteLine("Ordem crescente:");
                    foreach (var std in orderByResult)
                        Console.WriteLine(std.DisciplinaNome);
                    Console.WriteLine("----------------------------------------");

                    // Operador de ordenação ORDERBY - DESCENDING
                    var orderByDescendingResult = from s in disciplinaLista
                                                  orderby s.DisciplinaNome descending
                                                  select s;
                    // Resultado da ordenação decrescente
                    Console.WriteLine("Ordem decrescente:");
                    foreach (var std in orderByDescendingResult)
                        Console.WriteLine(std.DisciplinaNome);
                    Console.WriteLine("----------------------------------------");

                    // Operador de ordenação ORDERBY - MULTISORTING
                    var multiSortingResult = from s in disciplinaLista
                                             orderby s.DisciplinaNome, s.DisciplinaCreditos
                                             select s;
                    // Resultado da ordenação múltipla
                    Console.WriteLine("Ordem crescente de nome e de créditos: ");
                    foreach (var std in multiSortingResult)
                        Console.WriteLine("{0}, {1} créditos ", std.DisciplinaNome, std.DisciplinaCreditos);
                    Console.ReadLine();
                    break;


                case 3:  // Classificação de operadores - THENBY e THENBYDESCENDING
                    Console.WriteLine("Ordem crescente de nome e crescente de créditos: ");
                    var thenByResult = disciplinaLista.OrderBy(s => s.DisciplinaNome).ThenBy(s => s.DisciplinaCreditos);
                    foreach (var std in thenByResult)
                        Console.WriteLine("{0}, {1} créditos ", std.DisciplinaNome, std.DisciplinaCreditos);
                    Console.ReadLine();
                    Console.WriteLine("Ordem crescente de nome e decrescente de créditos: ");
                    var thenByDescResult = disciplinaLista.OrderBy(s => s.DisciplinaNome).ThenByDescending(s => s.DisciplinaCreditos);
                    foreach (var std in thenByDescResult)
                        Console.WriteLine("{0}, {1} créditos ", std.DisciplinaNome, std.DisciplinaCreditos);
                    Console.ReadLine();
                    break;


                case 4: // Operadores de agrupamento GROUPBY
                    var groupedResult = disciplinaLista.GroupBy(s => s.DisciplinaCreditos);
                    foreach (var creditosGrupo in groupedResult)
                    {
                        Console.WriteLine("Créditos: {0} ", creditosGrupo.Key);
                        foreach (Disciplina s in creditosGrupo)
                            Console.WriteLine("Nome da disciplina: {0}", s.DisciplinaNome);
                        Console.WriteLine("----------------------------------------");
                    }
                    Console.ReadLine();
                    break;


                case 5: // Operadores de agregação AVERAGE
                    var avgCreditos = disciplinaLista.Average(s => s.DisciplinaCreditos);
                    Console.WriteLine("Média de créditos: {0}", avgCreditos);
                    Console.ReadLine();
                    break;


                case 6: // Operadores de agregação COUNT
                    var totalDisciplinas = disciplinaLista.Count();
                    Console.WriteLine("Numero total de disciplinas: {0}", totalDisciplinas);
                    var totalCreditos = disciplinaLista.Count(s => s.DisciplinaCreditos >= 3);
                    Console.WriteLine("Número ed disciplinas com 3 ou mais créditos: {0}", totalCreditos);
                    Console.ReadLine();
                    break;


                case 7: // Operadores de agregação MAX
                    var menosCreditos = disciplinaLista.Min(s => s.DisciplinaCreditos);
                    Console.WriteLine("Menor número de créditos: {0}", menosCreditos);

                    var maisCreditos = disciplinaLista.Max(s => s.DisciplinaCreditos);
                    Console.WriteLine("Maior número de créditos: {0}", maisCreditos);

                    var disciplinaComNomeMaisLongo = disciplinaLista.Max(); // Esse operador precisou da implementação da interface IComparable<> junto com a classe ao final do código
                    Console.WriteLine("ID da Disciplina com maior nome: {0}, Nome: {1}", disciplinaComNomeMaisLongo.DisciplinaID, disciplinaComNomeMaisLongo.DisciplinaNome);
                    /*var disciplinaComNomeMaisCurto = disciplinaLista.Min(); 
                    Console.WriteLine("ID da Disciplina com menor nome: {0}, Nome: {1}", disciplinaComNomeMaisCurto.DisciplinaID, disciplinaComNomeMaisCurto.DisciplinaNome);*/
                    Console.ReadLine();
                    break;


                case 8: // Operadores de agregação SUM
                    var somaDeCreditos = disciplinaLista.Sum(s => s.DisciplinaCreditos);
                    Console.WriteLine("Soma de todos os créditos: {0}", somaDeCreditos);

                    var totalComMaisDeTres = disciplinaLista.Sum(s =>
                    {
                        if (s.DisciplinaCreditos >= 3)
                            return 1;
                        else
                            return 0;
                    });
                    Console.WriteLine("Total de disciplinas com 3 créditos ou mais: {0}", totalComMaisDeTres);
                    Console.ReadLine();
                    break;


                case 9: // Outros operadores FIRSTORDEFAULT
                    Console.ReadLine();
                    break;


                case 10: // Outros operadores TAKE
                    Console.ReadLine();
                    break;

            }
        }   
    }   

    public class Disciplina : IComparable<Disciplina>
    {

        public int DisciplinaID { get; set; }
	    public string DisciplinaNome { get; set; }
	    public int DisciplinaCreditos { get; set; }

        public int CompareTo(Disciplina other)
        {
            if (this.DisciplinaNome.Length >= other.DisciplinaNome.Length)
                return 1;

            return 0;
        }
    }


}

