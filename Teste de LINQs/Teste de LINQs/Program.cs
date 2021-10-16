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
		    IList<Disciplina> intList = new List<Disciplina>() { 
			new Disciplina() { DisciplinaID = 1, DisciplinaNome = "Eletrônica Analógica", DisciplinaCreditos = 3} ,
                	new Disciplina() { DisciplinaID = 2, DisciplinaNome = "Eletrônica Digital", DisciplinaCreditos = 3} ,
                	new Disciplina() { DisciplinaID = 3, DisciplinaNome = "Física", DisciplinaCreditos = 4} ,
                	new Disciplina() { DisciplinaID = 4, DisciplinaNome = "Física", DisciplinaCreditos = 1} ,
                	new Disciplina() { DisciplinaID = 5, DisciplinaNome = "Gestão", DisciplinaCreditos = 1} ,
                	new Disciplina() { DisciplinaID = 6, DisciplinaNome = "Cálculo", DisciplinaCreditos = 5} ,
                	new Disciplina() { DisciplinaID = 7, DisciplinaNome = "Sinais e Sistemas", DisciplinaCreditos = 4} ,

            };

            int n;
            
            do
            {
                Console.WriteLine("OPERADORES LINQ E EXPRESSÕES LAMBDA");
                Console.WriteLine(" 1 - Where");
                Console.WriteLine(" 2 - OrderBy");
                Console.WriteLine(" 3 - ThenBy e ThenByDescending");
                Console.WriteLine(" 4 - GroupBy");
                Console.WriteLine(" 5 - Average");
                Console.WriteLine(" 6 - Count");
                Console.WriteLine(" 7 - Max");
                Console.WriteLine(" 8 - Sum");
                Console.WriteLine(" 9 - FirstOrDefault");
                Console.WriteLine("10 - Take");
                Console.Write("NÚMERO DA OPÇÃO ESCOLHIDA: ");
                n = int.Parse(Console.ReadLine());


                if (n == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Where - Retorna valores da coleção com base em uma função de atributo");
                    Console.WriteLine();
                    var pesquisaDisciplinas = from s in intList
                                              where s.DisciplinaCreditos > 0 && s.DisciplinaCreditos < 4
                                              select s;
                    // Resultado da filtragem
                    Console.WriteLine("Disciplinas com menos de 3 créditos:");
                    foreach (Disciplina std in pesquisaDisciplinas)
                        Console.WriteLine(std.DisciplinaNome);
                    Console.ReadLine();
                }

                else if (n == 2)
                {
                    Console.Clear();
                    Console.WriteLine("OrderBy - Classifica os elementos na coleção com base nos campos especificados em ordem crescente ou decrescente.");
                    Console.WriteLine();
                    var orderByResult = from s in intList
                                        orderby s.DisciplinaNome
                                        select s;
                    // Resultado da ordenação crescente
                    Console.WriteLine("Ordem crescente:");
                    foreach (var std in orderByResult)
                        Console.WriteLine(std.DisciplinaNome);
                    Console.WriteLine("----------------------------------------");

                    // Operador de ordenação ORDERBY - DESCENDING
                    var orderByDescendingResult = from s in intList
                                                  orderby s.DisciplinaNome descending
                                                  select s;
                    // Resultado da ordenação decrescente
                    Console.WriteLine("Ordem decrescente:");
                    foreach (var std in orderByDescendingResult)
                        Console.WriteLine(std.DisciplinaNome);
                    Console.WriteLine("----------------------------------------");

                    // Operador de ordenação ORDERBY - MULTISORTING
                    var multiSortingResult = from s in intList
                                             orderby s.DisciplinaNome, s.DisciplinaCreditos
                                             select s;
                    // Resultado da ordenação múltipla
                    Console.WriteLine("Ordem crescente de nome e de créditos: ");
                    foreach (var std in multiSortingResult)
                        Console.WriteLine("{0}, {1} créditos ", std.DisciplinaNome, std.DisciplinaCreditos);
                    Console.ReadLine();
                }

                else if (n == 3)
                {
                    Console.Clear();
                    Console.WriteLine("ThenBy - Válido apenas na sintaxe do método. Usado para classificação de segundo nível em ordem crescente.");
                    Console.WriteLine();
                    Console.WriteLine("Ordem crescente de nome e crescente de créditos: ");
                    var thenByResult = intList.OrderBy(s => s.DisciplinaNome).ThenBy(s => s.DisciplinaCreditos);
                    foreach (var std in thenByResult)
                        Console.WriteLine("{0}, {1} créditos ", std.DisciplinaNome, std.DisciplinaCreditos);
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("ThenByDescending - Válido apenas na sintaxe do método. Usado para classificação de segundo nível em ordem decrescente.");
                    Console.WriteLine("Ordem crescente de nome e decrescente de créditos: ");
                    var thenByDescResult = intList.OrderBy(s => s.DisciplinaNome).ThenByDescending(s => s.DisciplinaCreditos);
                    foreach (var std in thenByDescResult)
                        Console.WriteLine("{0}, {1} créditos ", std.DisciplinaNome, std.DisciplinaCreditos);
                    Console.ReadLine();
                }

                else if (n == 4)
                {
                    Console.Clear();
                    Console.WriteLine("GroupBy - O operador GroupBy retorna grupos de elementos com base em algum valor-chave.");
                    Console.WriteLine();
                    var groupedResult = intList.GroupBy(s => s.DisciplinaCreditos);
                    foreach (var creditosGrupo in groupedResult)
                    {
                        Console.WriteLine("Créditos: {0} ", creditosGrupo.Key);
                        foreach (Disciplina s in creditosGrupo)
                            Console.WriteLine("Nome da disciplina: {0}", s.DisciplinaNome);
                        Console.WriteLine("----------------------------------------");
                    }
                    Console.ReadLine();
                }

                else if (n == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Average - O método de extensão média calcula a média dos itens numéricos na coleção.");
                    Console.WriteLine();
                    var avgCreditos = intList.Average(s => s.DisciplinaCreditos);
                    Console.WriteLine("Média de créditos: {0}", avgCreditos);
                    Console.ReadLine();
                }

                else if (n == 6)
                {
                    Console.Clear();
                    Console.WriteLine("Count - O operador Count retorna o número de elementos na coleção ou o número de elementos que atenderam à condição especificada.");
                    Console.WriteLine();
                    var totalDisciplinas = intList.Count();
                    Console.WriteLine("Numero total de disciplinas: {0}", totalDisciplinas);
                    var totalCreditos = intList.Count(s => s.DisciplinaCreditos >= 3);
                    Console.WriteLine("Número ed disciplinas com 3 ou mais créditos: {0}", totalCreditos);
                    Console.ReadLine();
                }

                else if (n == 7)
                {
                    Console.Clear();
                    Console.WriteLine("Max - O operador Max retorna o maior elemento numérico de uma coleção.");
                    Console.WriteLine();
                    var menosCreditos = intList.Min(s => s.DisciplinaCreditos);
                    Console.WriteLine("Menor número de créditos: {0}", menosCreditos);

                    var maisCreditos = intList.Max(s => s.DisciplinaCreditos);
                    Console.WriteLine("Maior número de créditos: {0}", maisCreditos);

                    var disciplinaComNomeMaisLongo = intList.Max(); // Esse operador precisou da implementação da interface IComparable<> junto com a classe ao final do código
                    Console.WriteLine("ID da Disciplina com maior nome: {0}, Nome: {1}", disciplinaComNomeMaisLongo.DisciplinaID, disciplinaComNomeMaisLongo.DisciplinaNome);
                    /*var disciplinaComNomeMaisCurto = disciplinaLista.Min(); 
                    Console.WriteLine("ID da Disciplina com menor nome: {0}, Nome: {1}", disciplinaComNomeMaisCurto.DisciplinaID, disciplinaComNomeMaisCurto.DisciplinaNome);*/
                    Console.ReadLine();
                }

                else if (n == 8)
                {
                    Console.Clear();
                    Console.WriteLine("Sum - Calcula a soma dos itens numéricos na coleção.");
                    Console.WriteLine();
                    var somaDeCreditos = intList.Sum(s => s.DisciplinaCreditos);
                    Console.WriteLine("Soma de todos os créditos: {0}", somaDeCreditos);

                    var totalComMaisDeTres = intList.Sum(s =>
                    {
                        if (s.DisciplinaCreditos >= 3)
                            return 1;
                        else
                            return 0;
                    });
                    Console.WriteLine("Total de disciplinas com 3 créditos ou mais: {0}", totalComMaisDeTres);
                    Console.ReadLine();
                }

                else if (n == 9)
                {
                    Console.Clear();
                    Console.WriteLine("FirstOrDefault - Retorna o primeiro elemento de uma coleção ou o primeiro elemento que satisfaz uma condição.");
                    Console.WriteLine();
                    IList<int> intLista = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
                    Console.WriteLine("Primerio elemento da lista: {0}", intLista.FirstOrDefault());
                    Console.ReadLine();
                }

                else if (n == 10)
                {
                    Console.Clear();
                    Console.WriteLine("Take - Retorna o número especificado de elementos, começando no primeiro elemento.");
		    Console.WriteLine("Mozinho da minha vida");
		    Console.WriteLine();
                    IList<int> intListat = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
                    var newList = intListat.Take(3);
                    Console.WriteLine("Os 3 primeiros numeros são:");
                    foreach (var str in newList)
                        Console.WriteLine(str);
                    Console.ReadLine();
                }

                else
                {
                    Console.Clear();
                }

                Console.Clear();
            } while (n != 0);

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


