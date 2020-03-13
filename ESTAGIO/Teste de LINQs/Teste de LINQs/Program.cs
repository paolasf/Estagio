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


                case 5: // Operadores de agregação AVERAGE]
                    Console.ReadLine();
                    break;


                case 6: // Operadores de agregação COUNT
                    Console.ReadLine();
                    break;


                case 7: // Operadores de agregação MAX
                    Console.ReadLine();
                    break;


                case 8: // Operadores de agregação SUM
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

    public class Disciplina{

	    public int DisciplinaID { get; set; }
	    public string DisciplinaNome { get; set; }
	    public int DisciplinaCreditos { get; set; }
    }
}
