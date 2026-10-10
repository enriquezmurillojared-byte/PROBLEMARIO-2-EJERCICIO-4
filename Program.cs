using System;

class Bateria
{
    // Propiedades de la bateria
    public double Voltaje { get; set; }
    public double Incremento { get; set; }
    public int Ciclo { get; set; }
    public double VoltajeObjetivo { get; set; }

    // Constructor
    public Bateria()
    {
        Voltaje = 0;
        Incremento = 0;
        Ciclo = 0;
        VoltajeObjetivo = 12.6;
    }

    // Metodo para leer los datos
    public void LeerDatos()
    {
        do
        {
            Console.Write("Ingrese el voltaje inicial de la bateria (V): ");

            if (!double.TryParse(Console.ReadLine(), out double voltajeInicial))
            {
                Console.WriteLine("Dato invalido.");
                continue;
            }

            if (voltajeInicial < 0)
            {
                Console.WriteLine("El voltaje no puede ser negativo.");
                continue;
            }

            Voltaje = voltajeInicial;
            break;

        } while (true);

        do
        {
            Console.Write("Ingrese el incremento por ciclo (V): ");

            if (!double.TryParse(Console.ReadLine(), out double incremento))
            {
                Console.WriteLine("Dato invalido.");
                continue;
            }

            if (incremento <= 0)
            {
                Console.WriteLine("El incremento debe ser mayor que cero.");
                continue;
            }

            Incremento = incremento;
            break;

        } while (true);

        Ciclo = 0;
    }

    // Metodo para cargar la bateria
    public void Cargar()
    {
        while (Voltaje < VoltajeObjetivo)
        {
            Ciclo++;

            Voltaje += Incremento;

            AjustarVoltaje();
            MostrarEstado();
        }
    }

    // Metodo para ajustar el voltaje al limite
    public void AjustarVoltaje()
    {
        if (Voltaje > VoltajeObjetivo)
        {
            Voltaje = VoltajeObjetivo;
        }
    }

    // Metodo para mostrar el estado
    public void MostrarEstado()
    {
        Console.WriteLine($"Ciclo: {Ciclo}");
        Console.WriteLine($"Voltaje actualizado: {Voltaje:F1} V");
        Console.WriteLine("-------------------------");
    }
}

class Program
{
    static void Main()
    {
        // Crear el objeto
        Bateria bateria1 = new Bateria();

        // Ejecutar los metodos
        bateria1.LeerDatos();

        if (bateria1.Voltaje < bateria1.VoltajeObjetivo)
        {
            bateria1.Cargar();
        }

        Console.WriteLine("\n--- CARGA COMPLETADA ---");
        Console.WriteLine($"Voltaje final: {bateria1.Voltaje:F1} V");

        Console.WriteLine("\nPresione una tecla para salir.");
        Console.ReadKey();
    }
}