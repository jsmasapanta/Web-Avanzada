using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2
{
    // Interfaz para mostrar información general
    public interface IMostrarInformacion
    {
        void MostrarInformacion();
    }

    // Clase base: Empleado
    public class Empleado : IMostrarInformacion
    {
        // Atributos de la clase Empleado
        public string Nombre { get; set; }
        public double Salario { get; set; }

        // Constructor de la clase Empleado
        public Empleado(string nombre, double salario)
        {
            Nombre = nombre;
            Salario = salario;
        }

        // Método para calcular el salario anual
        public double CalcularSalarioAnual()
        {
            return Salario * 12;
        }

        // Implementación de la interfaz para mostrar información
        public void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Salario anual: {CalcularSalarioAnual()}");
        }
    }

    // Clase derivada: Gerente (hereda de Empleado)
    public class Gerente : Empleado, IMostrarInformacion
    {
        // Nuevo atributo para el departamento que supervisa
        public string Departamento { get; set; }

        // Constructor de la clase Gerente
        public Gerente(string nombre, double salario, string departamento)
            : base(nombre, salario)
        {
            Departamento = departamento;
        }

        // Implementación de la interfaz para mostrar información
        public new void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Departamento: {Departamento}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Obtener información del empleado
            Console.WriteLine("Ingrese el nombre del empleado: ");
            string nombreEmpleado = Console.ReadLine();
            Console.WriteLine("Ingrese el salario mensual del empleado:");
            double salarioMensualEmpleado;

            while (!double.TryParse(Console.ReadLine(), out salarioMensualEmpleado) || salarioMensualEmpleado < 0)
            {
                Console.WriteLine("Ingrese un valor válido para el salario mensual.");
                Console.Write("Ingrese el salario mensual del empleado: ");
            }

            // Obtener información del gerente
            Console.WriteLine("Ingrese el nombre del gerente: ");
            string nombreGerente = Console.ReadLine();
            Console.WriteLine("Ingrese el salario mensual del gerente:");
            double salarioMensualGerente;

            while (!double.TryParse(Console.ReadLine(), out salarioMensualGerente) || salarioMensualGerente < 0)
            {
                Console.WriteLine("Ingrese un valor válido para el salario mensual.");
                Console.Write("Ingrese el salario mensual del gerente: ");
            }

            Console.WriteLine("Ingrese el departamento que supervisa el gerente: ");
            string departamentoGerente = Console.ReadLine();

            // Crear instancias de Empleado y Gerente
            Empleado empleado = new Empleado(nombreEmpleado, salarioMensualEmpleado);
            Gerente gerente = new Gerente(nombreGerente, salarioMensualGerente, departamentoGerente);

            // Mostrar información utilizando la interfaz y el polimorfismo
            MostrarInformacion(empleado);
            MostrarInformacion(gerente);
        }

        // Método para mostrar información utilizando la interfaz
        static void MostrarInformacion(IMostrarInformacion persona)
        {
            persona.MostrarInformacion();
            Console.WriteLine();
        }
    }
}