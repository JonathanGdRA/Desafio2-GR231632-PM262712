using System;

class Ahorcado
{
    static void Main(string[] args)
    {
        int opcion = 0;

        while (opcion != 3)
        {
            Console.Clear();
            Console.WriteLine("=============================");
            Console.WriteLine("     JUEGO DEL AHORCADO      ");
            Console.WriteLine("=============================");
            Console.WriteLine("1. Jugar");
            Console.WriteLine("2. Ver instrucciones");
            Console.WriteLine("3. Salir");
            Console.Write("Elige una opcion: ");

            string entrada = Console.ReadLine();

            if (entrada == "1") opcion = 1;
            else if (entrada == "2") opcion = 2;
            else if (entrada == "3") opcion = 3;
            else opcion = 0;

            if (opcion == 1)
            {
                Console.WriteLine("Aqui va el juego...");
                Console.ReadLine();
            }
            else if (opcion == 2)
            {
                Console.WriteLine("Aqui van las instrucciones...");
                Console.ReadLine();
            }
            else if (opcion == 3)
            {
                Console.WriteLine("Hasta luego!");
            }
        }
    }
}