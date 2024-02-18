    {
        Random random = new Random();
        decimal media;

        Console.WriteLine("Inserisci il tuo nome:");
        string nome = Console.ReadLine();

        Console.WriteLine($"Di che hai bisogno {nome}?");
        Console.WriteLine("Digita 0 per arrestare il programma");
        Console.WriteLine("Digita 1 per il generatore di numeri");
        Console.WriteLine("Digita 2 per il calcolatore della media");

        int scelta;

        try
        {
            scelta = Int32.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Input non valido. Inserire un valore numerico");
            return;
        }
        
        if (scelta == 0)
        {
            return;
        }
        
        else if (scelta == 1)
        {
            Console.WriteLine("Digita il limite (es. 100 quindi genererà da 1 a 100)");
            int limite = Int32.Parse(Console.ReadLine());
            int rnd = random.Next(1, limite + 1);
            Console.WriteLine($"Il numero generato è: {rnd}");
        }
        
        else if (scelta == 2)
        {
            List<int> valori = new List<int>();

            Console.WriteLine("Inserisci dei numeri per calcolarne le medie (minimo 2 numeri; massimo 10 numeri)");

            do
            {
                Console.WriteLine("Inserisci un numero:");
                int numero = Int32.Parse(Console.ReadLine());
                valori.Add(numero);

                Console.WriteLine("Vuoi inserire un altro numero? (Si/No)");
            } while (Console.ReadLine().ToUpper() == "SI");

            media = CalcolaMedia(valori);
            Console.WriteLine($"La media di questi numeri è: {media}");
        }
    }

    static decimal CalcolaMedia(List<int> valori)
    {
        int somma = 0;
        foreach (int valore in valori)
        {
            somma += valore;
        }
        return decimal.Round((decimal)somma / valori.Count, 2);
    }

