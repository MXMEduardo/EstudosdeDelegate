using System;
using System.Linq;
using System.Collections.Generic;
using EstudodeDelegates.Entities;

namespace EstudodeDelegates {
    
    //delegate string TestedeDelegate(string s);
    delegate void DelegateMultoCast(double valor);

    class Program {
        static void FuncDelegateAction(Product p) {
            p.Price += p.Price * 0.1;
        }
        static bool FuncDelegatePredicate(Product p) {
            return p.Price >= 100;
        }

        static string FuncDelegateFunc(Product p) {
            return p.Name.ToUpper();
        }

        public string FuncParametroDelegate(string s) {
            return s;
        }

        static void Main(string[] args) {

            List<Product> List = new List<Product>();
            List.Add(new Product("TV", 900.00 ));
            List.Add(new Product("Mouse", 50.00));
            List.Add(new Product("Tabler", 350.50));
            List.Add(new Product("HD Case", 80.90));

            Console.WriteLine("Lista Original");
            Console.WriteLine("-----------------");
            foreach (Product p in List) {
                Console.WriteLine(p);
            }


            Console.WriteLine("");
            Console.WriteLine("Delegate Predicate");
            Console.WriteLine("-----------------");
            List.RemoveAll(FuncDelegatePredicate);
            // Usando uma expressão LAMDA para associar ao delegate Predicate
            //   List.RemoveAll( p => p.Price >= 100);

            foreach (Product p in List) {
                Console.WriteLine(p);
            }


            Console.WriteLine("");
            Console.WriteLine("Delegate Action");
            Console.WriteLine("-----------------");
            List.ForEach(FuncDelegateAction);
            // Instânciando o delegate Action
            //   Action<Product> act = FuncDelegateAction;
            //   List.ForEach(act);
            // Usando uma expressão LAMDA para associar ao delegate Action
            //   Action<Product> act = p => { p.Price += p.Price * 0.1; } ;
            //   List.ForEach(act);

            foreach (Product p in List) {
                Console.WriteLine(p);
            }


            Console.WriteLine("");
            Console.WriteLine("Delegate Func");
            Console.WriteLine("-----------------");
            List<String> NomeMaiusculo = List.Select(FuncDelegateFunc).ToList();
            // Instânciando o delegate Func 
            //   Func<Product, string> Prod = FuncDelegateFunc;
            //   List<String> NomeMaiusculo = List.Select(Prod).ToList();

            foreach (string stringUpper in NomeMaiusculo) {
                Console.WriteLine(stringUpper);
            }


            Console.WriteLine("");
            Console.WriteLine("MultiCats Delegate");
            Console.WriteLine("-----------------");
            Product ProductMultDelegates = new Product();
            DelegateMultoCast MultDelegates  = ProductMultDelegates.IncluiValor100;
                              MultDelegates += ProductMultDelegates.IncluiValor200;
            //MultDelegates.Invoke(1000);
            MultDelegates(1000);


            Console.WriteLine("");
            Console.WriteLine("Teste de parametro delegate");
            Console.WriteLine("-----------------");
            Product ProdutoParDelegate = new Product();
            string strParametroDelegate = ProdutoParDelegate.ParametroDelegate(s => s = "Agora Bolei");
            Console.WriteLine(strParametroDelegate);

            //TestedeDelegate delegateTest = PTeste.TextProduct;
            //Console.WriteLine(delegateTest("Teste 1") );
            //string x = PTeste.MetodocomDelegate();

            Console.ReadLine();
        }
    }
}
