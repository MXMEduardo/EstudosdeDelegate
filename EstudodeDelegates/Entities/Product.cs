using System;

namespace EstudodeDelegates.Entities {
    public delegate string MetodoDelegateParametro<in T>(T Texto);

    public class Product {

        #region atributos
        public string Name { get; set; }
        public double Price { get; set; }
        #endregion

        #region construtores
        public Product(string name, double price) {
            this.Name = name;
            this.Price = price;
        }

        public Product() {

        }
        #endregion

        #region Metodo ToString
        public override string ToString() {
            return Name + " , " + Price.ToString("F2");
        }
        #endregion

        #region Estudos de Delegates

        #region Metodos para testes do MultiCats Delegate
        public void IncluiValor100(double valor) {
            valor += 100;
            Console.WriteLine(valor);
        }

        public void IncluiValor200(double valor) {
            valor += 200;
            Console.WriteLine(valor);
        }
        #endregion

        #region Delegate como parâmetro do metodoX
        public string ParametroDelegate(MetodoDelegateParametro<string> Texto) {
            return Texto.ToString();
        }
        #endregion

        #endregion
    }
}
