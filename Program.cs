using System;

namespace Ejercicio4_EliminarFueraDeRango
{
    public class Nodo
    {
        public int Valor;
        public Nodo? Siguiente;

        public Nodo(int valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }

    public class ListaEnlazada
    {
        private Nodo? cabeza;

        public void Agregar(int valor)
        {
            if (cabeza == null)
            {
                cabeza = new Nodo(valor);
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = new Nodo(valor);
            }
        }

        public void Mostrar()
        {
            Nodo? actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Valor + " -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }

        public void EliminarFueraDeRango(int min, int max)
        {
            while (cabeza != null && (cabeza.Valor < min || cabeza.Valor > max))
            {
                cabeza = cabeza.Siguiente;
            }

            Nodo? actual = cabeza;
            while (actual?.Siguiente != null)
            {
                if (actual.Siguiente.Valor < min || actual.Siguiente.Valor > max)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                }
                else
                {
                    actual = actual.Siguiente;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();

            Random random = new Random();
            for (int i = 0; i < 50; i++)
            {
                lista.Agregar(random.Next(1, 1000));
            }

            Console.WriteLine("Lista generada:");
            lista.Mostrar();

            Console.WriteLine("Introduce el valor mínimo del rango:");
            int min = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Introduce el valor máximo del rango:");
            int max = int.Parse(Console.ReadLine() ?? "0");
            lista.EliminarFueraDeRango(min, max);

            Console.WriteLine($"Lista después de eliminar elementos fuera del rango [{min}, {max}]:");
            lista.Mostrar();
        }
    }
}
//fin