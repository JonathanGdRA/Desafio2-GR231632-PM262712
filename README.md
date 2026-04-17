# Desafio-2---PAL404
codigo de sistema de notas

using System;

namespace DesafioUDB
{
    class Program
    {
        static void Main(string[] args)
        {
            // Aquí es donde llamarás a tu función de notas
            SistemaDeNotas();
        }

        static void SistemaDeNotas()
        {
            Console.WriteLine("--- SISTEMA DE REGISTRO DE NOTAS ESTUDIANTILES ---");

            // 1. Solicitar cantidad de estudiantes
            Console.Write("Ingrese la cantidad de estudiantes a registrar: ");
            int n = int.Parse(Console.ReadLine());

            // 2. Vectores paralelos (Requisito funcional 2)
            string[] nombres = new string[n];
            double[] notas = new double[n];
            char[] letras = new char[n];
            string[] estados = new string[n];

            double sumaNotas = 0;

            // Bucle para llenar los datos
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nRegistro del estudiante #{i + 1}:");
                Console.Write("Nombre completo: ");
                nombres[i] = Console.ReadLine();

                // 3. Validar nota entre 0 y 10 (Requisito funcional 3)
                double notaTemporal;
                do
                {
                    Console.Write("Ingrese la nota (0.0 - 10.0): ");
                    if (!double.TryParse(Console.ReadLine(), out notaTemporal) || notaTemporal < 0 || notaTemporal > 10)
                    {
                        Console.WriteLine("¡Error! La nota debe ser un número entre 0 y 10.");
                        notaTemporal = -1; // Para que siga en el bucle
                    }
                } while (notaTemporal < 0 || notaTemporal > 10);

                notas[i] = notaTemporal;
                sumaNotas += notas[i];

                // 5. Determinar si aprobó o reprobó (Requisito funcional 5)
                if (notas[i] >= 6.0)
                    estados[i] = "Aprobado";
                else
                    estados[i] = "Reprobado";

                // 6. Convertir nota a letra (Requisito funcional 6)
                if (notas[i] >= 9.0) letras[i] = 'A';
                else if (notas[i] >= 8.0) letras[i] = 'B';
                else if (notas[i] >= 7.0) letras[i] = 'C';
                else if (notas[i] >= 6.0) letras[i] = 'D';
                else letras[i] = 'F';
            }

            // 4. Calcular promedio, máxima y mínima (Requisito funcional 4)
            double promedio = sumaNotas / n;
            double notaMax = notas[0];
            double notaMin = notas[0];

            for (int i = 1; i < n; i++)
            {
                if (notas[i] > notaMax) notaMax = notas[i];
                if (notas[i] < notaMin) notaMin = notas[i];
            }

            // 7. Reporte Final (Requisito funcional 7)
            Console.WriteLine("\n============================================================");
            Console.WriteLine("REPORTE FINAL DE ESTUDIANTES");
            Console.WriteLine("============================================================");
            Console.WriteLine("Nombre\t\t\tNota\tLetra\tEstado");
            Console.WriteLine("------------------------------------------------------------");
            for (int i = 0; i < n; i++)
            {
                // Usamos \t para tabular y que se vea como tabla
                Console.WriteLine($"{nombres[i]}\t\t{notas[i]:F1}\t{letras[i]}\t{estados[i]}");
            }

            // 8. Resumen final (Requisito funcional 8)
            int totalAprobados = 0, totalReprobados = 0;
            foreach (string est in estados)
            {
                if (est == "Aprobado") totalAprobados++;
                else totalReprobados++;
            }

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"Promedio General del Grupo: {promedio:F2}");
            Console.WriteLine($"Nota más alta: {notaMax:F1}");
            Console.WriteLine($"Nota más baja: {notaMin:F1}");
            Console.WriteLine($"Total de estudiantes Aprobados: {totalAprobados}");
            Console.WriteLine($"Total de estudiantes Reprobados: {totalReprobados}");
            Console.WriteLine("============================================================\n");

            Console.WriteLine("Presione cualquier tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
