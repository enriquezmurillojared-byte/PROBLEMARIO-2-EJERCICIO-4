
using System;

internal class Motor
{
    // Propiedades del motor
    public string Identificador { get; set; }
    public double[] Temperaturas { get; set; }
    public double SumaTemperaturas { get; set; }
    public double Promedio { get; set; }
    public string Estado { get; set; }

    // Constructor
    public Motor()
    {
        Identificador = "";
        Temperaturas = new double[5];
        SumaTemperaturas = 0;
        Promedio = 0;
        Estado = "";
    }

    // Metodo para leer los datos
    public void LeerDatos()
    {
        Console.Write("Ingrese el identificador del motor: ");
        Identificador = Console.ReadLine() ?? "";

        SumaTemperaturas = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Ingrese la temperatura {i + 1} en °C: ");

            while (!double.TryParse(Console.ReadLine(), out Temperaturas[i]))
            {
                Console.Write("Dato invalido. Ingrese una temperatura: ");
            }

            SumaTemperaturas += Temperaturas[i];
        }
    }

    // Metodo para calcular el promedio
    public double CalcularPromedio()
    {
        Promedio = SumaTemperaturas / 5;
        return Promedio;
    }

    // Metodo para determinar el estado
    public string DeterminarEstado()
    {
        if (Promedio <= 70)
        {
            Estado = "NORMAL";
        }
        else
        {
            Estado = "ALERTA DE TEMPERATURA";
        }

        return Estado;
    }

    // Metodo para mostrar los resultados
    public void MostrarResultados()
    {
        Console.WriteLine("\n--- RESULTADOS DEL MOTOR ---");
        Console.WriteLine($"Identificador: {Identificador}");
        Console.WriteLine($"Promedio: {Promedio:F2} °C");
        Console.WriteLine($"Estado: {Estado}");
    }
}

internal class Program
{
    static void Main()
    {
        // Crear el objeto
        Motor motor1 = new Motor();

        // Ejecutar los metodos
        motor1.LeerDatos();
        motor1.CalcularPromedio();
        motor1.DeterminarEstado();
        motor1.MostrarResultados();

        Console.WriteLine("\nPresione una tecla para salir.");
        Console.ReadKey();
    }
}

