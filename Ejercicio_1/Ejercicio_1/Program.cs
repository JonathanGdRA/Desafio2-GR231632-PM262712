using System;

class Ahorcado
{
    // Banco de palabras
    static string[] palabras = new string[10];

    // Letras usadas por el jugador
    static char[] letrasUsadas = new char[26];
    static int totalLetrasUsadas = 0;

    static void Main(string[] args)
    {
        // Inicializar banco de palabras
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

        // Ciclo principal del menú
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

            // Convertir entrada a número
            if (entrada == "1") opcion = 1;
            else if (entrada == "2") opcion = 2;
            else if (entrada == "3") opcion = 3;
            else opcion = 0;

            switch (opcion)
            {
                case 1:
                    JugarAhorcado();
                    opcion = 0;
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("=============================");
                    Console.WriteLine("        INSTRUCCIONES        ");
                    Console.WriteLine("=============================");
                    Console.WriteLine("- Debes adivinar la palabra oculta letra por letra.");
                    Console.WriteLine("- Tienes un maximo de 6 intentos fallidos.");
                    Console.WriteLine("- Ingresa una letra a la vez.");
                    Console.WriteLine("- No puedes repetir letras ya usadas.");
                    Console.WriteLine("- Si fallas 6 veces, el ahorcado se completa y pierdes.");
                    Console.WriteLine("\nPresiona ENTER para volver al menu...");
                    Console.ReadLine();
                    opcion = 0;
                    break;

                case 3:
                    Console.WriteLine("\nHasta luego!");
                    break;

                default:
                    // Opción no válida, volver al menú
                    break;
            }
        }
    }

    // Método principal del juego
    static void JugarAhorcado()
    {
        // Reiniciar letras usadas
        totalLetrasUsadas = 0;
        for (int i = 0; i < 26; i++)
        {
            letrasUsadas[i] = ' ';
        }

        // Seleccionar palabra aleatoria
        Random rand = new Random();
        int indice = rand.Next(0, 10);
        string palabraSecreta = palabras[indice];

        int intentosFallidos = 0;
        int maxIntentos = 6;
        bool gano = false;

        // Ciclo del juego
        while (intentosFallidos < maxIntentos)
        {
            Console.Clear();

            // Mostrar dibujo del ahorcado
            DibujarAhorcado(intentosFallidos);

            // Mostrar estado de la palabra
            Console.WriteLine("\nPalabra: ");
            MostrarPalabra(palabraSecreta);

            // Mostrar letras usadas
            Console.Write("\nLetras usadas: ");
            for (int i = 0; i < totalLetrasUsadas; i++)
            {
                Console.Write(letrasUsadas[i] + " ");
            }

            Console.WriteLine("\nIntentos fallidos: " + intentosFallidos + "/" + maxIntentos);
            Console.Write("\nIngresa una letra: ");
            string letraEntrada = Console.ReadLine();

            // Validar que sea una sola letra
            if (letraEntrada == null || letraEntrada.Length != 1)
            {
                Console.WriteLine("Debes ingresar solo una letra!");
                Console.ReadLine();
                continue;
            }

            char letra = letraEntrada[0];

            // Convertir a minúscula si es mayúscula
            if (letra >= 'A' && letra <= 'Z')
            {
                letra = (char)(letra + 32);
            }

            // Validar que sea letra del alfabeto
            if (letra < 'a' || letra > 'z')
            {
                Console.WriteLine("Caracter no valido!");
                Console.ReadLine();
                continue;
            }

            // Verificar si la letra ya fue usada
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

            // Guardar letra usada
            letrasUsadas[totalLetrasUsadas] = letra;
            totalLetrasUsadas = totalLetrasUsadas + 1;

            // Verificar si la letra está en la palabra
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

            // Verificar si ya se descubrió toda la palabra
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

        // Mostrar resultado final
        Console.Clear();
        DibujarAhorcado(intentosFallidos);

        if (gano == true)
        {
            Console.WriteLine("\n¡Felicidades! Adivinaste la palabra: " + palabraSecreta);
        }
        else
        {
            Console.WriteLine("\nPerdiste :( La palabra era: " + palabraSecreta);
        }

        // Preguntar si desea jugar de nuevo
        Console.Write("\n¿Deseas jugar de nuevo? (s/n): ");
        string respuesta = Console.ReadLine();
        if (respuesta == "s" || respuesta == "S")
        {
            JugarAhorcado();
        }
    }

    // Método para mostrar la palabra con guiones en letras no descubiertas
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

    // Método para dibujar el ahorcado según los intentos fallidos
    static void DibujarAhorcado(int intentos)
    {
        Console.WriteLine("  +---+");

        // Cabeza
        if (intentos >= 1)
            Console.WriteLine("  |   O");
        else
            Console.WriteLine("  |    ");

        // Cuerpo
        if (intentos >= 3)
            Console.WriteLine("  |   |");
        else
            Console.WriteLine("  |    ");

        // Brazos
        if (intentos == 2)
            Console.WriteLine("  |  /  ");
        else if (intentos >= 4)
            Console.WriteLine("  |  /|\\");
        else
            Console.WriteLine("  |    ");

        // Piernas
        if (intentos == 5)
            Console.WriteLine("  |  /  ");
        else if (intentos >= 6)
            Console.WriteLine("  |  / \\");
        else
            Console.WriteLine("  |    ");

        Console.WriteLine("  |");
        Console.WriteLine("=====");
    }
}
