using System;

class Ahorcado
{
    static string[] palabras = new string[10];
    static char[] letrasUsadas = new char[26];
    static int totalLetrasUsadas = 0;

    static void Main(string[] args)
    {
        palabras[0] = "programacion";
        palabras[1] = "computadora";
        palabras[2] = "algoritmo";
        palabras[3] = "teclado";
        palabras[4] = "variable";
        palabras[5] = "funcion";
        palabras[6] = "ciclo";
        palabras[7] = "arreglo";
        palabras[8] = "consola";
        palabras[9] = "metodo";

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
                JugarAhorcado();
                opcion = 0;
            }
            else if (opcion == 2)
            {
                Console.WriteLine("Aqui van las instrucciones...");
                Console.ReadLine();
                opcion = 0;
            }
            else if (opcion == 3)
            {
                Console.WriteLine("Hasta luego!");
            }
        }
    }

    static void JugarAhorcado()
    {
        totalLetrasUsadas = 0;
        for (int i = 0; i < 26; i++)
        {
            letrasUsadas[i] = ' ';
        }

        Random rand = new Random();
        int indice = rand.Next(0, 10);
        string palabraSecreta = palabras[indice];

        int intentosFallidos = 0;
        int maxIntentos = 6;
        bool gano = false;

        while (intentosFallidos < maxIntentos)
        {
            Console.Clear();
            Console.WriteLine("\nPalabra: ");
            MostrarPalabra(palabraSecreta);

            Console.Write("\nLetras usadas: ");
            for (int i = 0; i < totalLetrasUsadas; i++)
            {
                Console.Write(letrasUsadas[i] + " ");
            }

            Console.WriteLine("\nIntentos fallidos: " + intentosFallidos + "/" + maxIntentos);
            Console.Write("\nIngresa una letra: ");
            string letraEntrada = Console.ReadLine();

            if (letraEntrada == null || letraEntrada.Length != 1)
            {
                Console.WriteLine("Debes ingresar solo una letra!");
                Console.ReadLine();
                continue;
            }

            char letra = letraEntrada[0];
            if (letra >= 'A' && letra <= 'Z')
            {
                letra = (char)(letra + 32);
            }

            if (letra < 'a' || letra > 'z')
            {
                Console.WriteLine("Caracter no valido!");
                Console.ReadLine();
                continue;
            }

            bool yaUsada = false;
            for (int i = 0; i < totalLetrasUsadas; i++)
            {
                if (letrasUsadas[i] == letra) yaUsada = true;
            }

            if (yaUsada == true)
            {
                Console.WriteLine("Esa letra ya la usaste!");
                Console.ReadLine();
                continue;
            }

            letrasUsadas[totalLetrasUsadas] = letra;
            totalLetrasUsadas = totalLetrasUsadas + 1;

            bool letraEncontrada = false;
            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                if (palabraSecreta[i] == letra) letraEncontrada = true;
            }

            if (letraEncontrada == false)
            {
                intentosFallidos = intentosFallidos + 1;
                Console.WriteLine("La letra '" + letra + "' no esta en la palabra.");
                Console.ReadLine();
            }

            bool todasDescubiertas = true;
            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                bool encontrada = false;
                for (int j = 0; j < totalLetrasUsadas; j++)
                {
                    if (letrasUsadas[j] == palabraSecreta[i]) encontrada = true;
                }
                if (encontrada == false) todasDescubiertas = false;
            }

            if (todasDescubiertas == true)
            {
                gano = true;
                break;
            }
        }

        Console.Clear();
        if (gano == true)
        {
            Console.WriteLine("\n¡Felicidades! Adivinaste la palabra: " + palabraSecreta);
        }
        else
        {
            Console.WriteLine("\nPerdiste :( La palabra era: " + palabraSecreta);
        }

        Console.Write("\n¿Deseas jugar de nuevo? (s/n): ");
        string respuesta = Console.ReadLine();
        if (respuesta == "s" || respuesta == "S")
        {
            JugarAhorcado();
        }
    }

    static void MostrarPalabra(string palabra)
    {
        for (int i = 0; i < palabra.Length; i++)
        {
            bool descubierta = false;
            for (int j = 0; j < totalLetrasUsadas; j++)
            {
                if (letrasUsadas[j] == palabra[i]) descubierta = true;
            }
            if (descubierta == true) Console.Write(palabra[i] + " ");
            else Console.Write("_ ");
        }
        Console.WriteLine();
    }
}
