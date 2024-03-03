using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Random random = new Random(); // Inizializza un oggetto Random per generare numeri casuali
        decimal media; // Variabile per memorizzare la media dei numeri
        string scelta1; // Variabile per memorizzare la scelta dell'utente

        Console.WriteLine("Inserisci il tuo nome:"); // Richiede all'utente di inserire il nome
        string nome = Console.ReadLine(); // Legge il nome inserito dall'utente

        // Menu delle opzioni disponibili
        Console.WriteLine($"Di che hai bisogno {nome}?");
        Console.WriteLine("Digita 0 per arrestare il programma");
        Console.WriteLine("Digita 1 per il generatore di numeri");
        Console.WriteLine("Digita 2 per il calcolatore della media");
        Console.WriteLine("Digita 3 per giocare a \"Indovino\" ");
        Console.WriteLine("Digita 4 per la calcolatrice");
        Console.WriteLine("Digita 5 per \"Acchiappa il numero!\" ");
        int scelta; // Variabile per memorizzare la scelta dell'utente

        try
        {
            scelta = Int32.Parse(Console.ReadLine()); // Legge la scelta dell'utente e la converte in un intero
        }
        catch (FormatException)
        {
            Console.WriteLine("Input non valido. Inserire un valore numerico valido"); // Gestisce il caso in cui l'input non sia un numero
            return;
        }

        if (scelta == 0)
        {
            return; // Termina il programma se l'utente sceglie 0
        }
        else if (scelta == 1)
        {
            Console.WriteLine(
                "Digita il limite minore (es. 24 quindi genererà da 24 al limite maggiore che inserirai dopo)"
            ); // Richiede all'utente di inserire il limite minore
            int limiteMinore;

            try
            {
                limiteMinore = Int32.Parse(Console.ReadLine()); // Legge il limite inserito dall'utente
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Inserire un numero valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                return; // Termina il programma
            }

            Console.WriteLine(
                $"Digita il limite maggiore (es. 130 quindi genererà da {limiteMinore} a 130)"
            ); //Richiede all'utente di inserire il limite maggiore
            int limiteMaggiore;

            try
            {
                limiteMaggiore = Int32.Parse(Console.ReadLine()); // Legge il limite inserito dall'utente
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Inserire un numero valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                return; // Termina il programma
            }

            if (limiteMinore >= limiteMaggiore)
            {
                Console.WriteLine(
                    "Errore, il limite minore deve essere MINORE del limite maggiore"
                ); // Stampa un messaggio di errore se il limite minore è >= del limite maggiore
            }
            else
            {
                int rnd = random.Next(limiteMinore, limiteMaggiore + 1); // Genera un numero casuale compreso tra limite minore e quello maggiore
                Console.WriteLine($"Il numero generato è: {rnd}"); // Stampa il numero generato
            }
        }
        else if (scelta == 2)
        {
            List<int> valori = new List<int>(); // Lista per memorizzare i numeri inseriti dall'utente

            Console.WriteLine("Inserisci dei numeri per calcolarne le medie"); // Richiede all'utente di inserire i numeri

            do
            {
                int numero;

                try
                {
                    Console.WriteLine("Inserisci un numero:"); // Richiede all'utente di inserire un numero
                    numero = Int32.Parse(Console.ReadLine()); // Legge il numero inserito dall'utente
                }
                catch (FormatException)
                {
                    Console.WriteLine("Errore: Inserire un numero valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                    return; // Termina il programma
                }

                valori.Add(numero); // Aggiunge il numero alla lista

                Console.WriteLine("Vuoi inserire un altro numero? (Si/No)"); // Richiede all'utente se vuole inserire un altro numero
                scelta1 = Console.ReadLine(); // Legge la scelta dell'utente
            } while (scelta1.ToUpper() == "SI"); // Continua a richiedere numeri fintanto che l'utente risponde "Si"

            media = CalcolaMedia(valori); // Calcola la media dei numeri inseriti
            Console.WriteLine($"La media di questi numeri è: {media}"); // Stampa la media
        }
        else if (scelta == 3)
        {
            Random rnd = new Random(); // Inizializza un nuovo oggetto Random per generare numeri casuali
            int numeroGiusto; // Variabile per memorizzare il numero da indovinare
            int numeriGen; // Variabile per memorizzare il numero di numeri da generare

            Console.WriteLine("Ciao! Benvenuto a Indovina!"); // Saluta l'utente
            Console.WriteLine("Sai come funziona? Si, No"); // Chiede all'utente se conosce le regole

            string sceltaA;
            do
            {
                sceltaA = Console.ReadLine().ToUpper(); // Legge la risposta dell'utente e la converte in maiuscolo

                if (sceltaA != "SI" && sceltaA != "NO")
                {
                    Console.WriteLine("Risposta non valida. Inserisci 'Si' o 'No'."); // Messaggio di errore per risposta non valida
                }
            } while (sceltaA != "SI" && sceltaA != "NO");

            if (sceltaA == "SI")
            {
                Console.WriteLine(
                    $"Inserisci quanti numeri vuoi che vengano generati {nome}! (Almeno 2)"
                ); // Richiede all'utente di inserire il numero di numeri da generare

                numeriGen = Int32.Parse(Console.ReadLine()); // Legge il numero inserito dall'utente

                if (numeriGen < 2)
                {
                    Console.WriteLine("Errore: i numeri da generare devono essere almeno 2");
                }
                else if (numeriGen >= 2)
                {
                    List<int> ListaNumeri = new List<int>(); // Lista per memorizzare i numeri generati
                    for (int i = 0; i < numeriGen; i++)
                    {
                        int numeroGen = rnd.Next(1, numeriGen); // Genera un numero casuale compreso tra 1 e il numero di numeri da generare
                        ListaNumeri.Add(numeroGen); // Aggiunge il numero alla lista dei numeri generati
                    }

                    Console.WriteLine("Numeri generati:"); // Stampa i numeri generati

                    foreach (int numeri in ListaNumeri)
                    {
                        Console.Write($"{numeri} "); // Stampa ciascun numero generato
                    }

                    numeroGiusto = ListaNumeri[rnd.Next(0, numeriGen)]; // Seleziona casualmente il numero da indovinare tra quelli generati

                    Console.WriteLine("\nIndovina il numero giusto"); // Richiede all'utente di indovinare il numero
                    int tentativo = Int32.Parse(Console.ReadLine()); // Legge il tentativo dell'utente

                    if (tentativo == numeroGiusto)
                    {
                        Console.WriteLine("Brav* hai indovinato il numero"); // Stampa un messaggio di successo se il tentativo è corretto
                    }
                    else
                    {
                        Console.WriteLine($"Spiacente, il numero giusto era {numeroGiusto}"); // Altrimenti, stampa il numero corretto
                    }
                }
            }
            else if (sceltaA == "NO")
            {
                Console.WriteLine("Nessun problema, ora ti spiegherò."); // Spiega le regole del gioco
                Console.WriteLine(
                    "Questo programma genererà una serie di numeri casuali (scegli te quanti numeri generare), dovrai quindi indovinare quello corretto."
                );
                Console.WriteLine("Adesso che hai capito cominciamo");
                Console.WriteLine(
                    $"Inserisci quanti numeri vuoi che vengano generati {nome}! (Almeno 2)"
                ); // Richiede all'utente di inserire il numero di numeri da generare

                int Nnumeri = Int32.Parse(Console.ReadLine()); // Legge il numero inserito dall'utente

                if (Nnumeri < 2)
                {
                    Console.WriteLine("Errore: i numeri da generare devono essere almeno 2");
                }
                else if (Nnumeri >= 2)
                {
                    List<int> ListaNumeri = new List<int>(); // Lista per memorizzare i numeri generati
                    for (int i = 0; i < Nnumeri; i++)
                    {
                        int numeroGen;
                        do
                        {
                            numeroGen = rnd.Next(1, Nnumeri + 1); // Genera un numero casuale compreso tra 1 e il numero di numeri da generare
                        } while (ListaNumeri.Contains(numeroGen)); // Assicura che il numero generato non sia già presente nella lista

                        ListaNumeri.Add(numeroGen); // Aggiunge il numero alla lista dei numeri generati
                    }

                    Console.WriteLine("Numeri generati:"); // Stampa i numeri generati

                    foreach (int numeri in ListaNumeri)
                    {
                        Console.Write($"{numeri} "); // Stampa ciascun numero generato
                    }

                    numeroGiusto = ListaNumeri[rnd.Next(0, Nnumeri)]; // Seleziona casualmente il numero da indovinare tra quelli generati

                    Console.WriteLine("\nIndovina il numero giusto!"); // Richiede all'utente di indovinare il numero
                    int tentativo = Int32.Parse(Console.ReadLine()); // Legge il tentativo dell'utente

                    if (tentativo == numeroGiusto)
                    {
                        Console.WriteLine("Brav* hai indovinato il numero"); // Stampa un messaggio di successo se il tentativo è corretto
                    }
                    else
                    {
                        Console.WriteLine($"Spiacente, il numero giusto era {numeroGiusto}"); // Altrimenti, stampa il numero corretto
                    }
                }
            }
        }
        else if (scelta == 4)
        {
            Console.WriteLine("Benvenuto in una calcolatrice basica.");
            decimal num1;
            decimal num2;
            string sceltaB;
            int arrot;

            try
            {
                Console.WriteLine("Inserisci un numero:"); // Richiede all'utente di inserire un numero
                num1 = decimal.Parse(Console.ReadLine()); // Legge il numero inserito dall'utente
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Inserire un numero valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                return; // Termina il programma
            }

            try
            {
                Console.WriteLine("Inserisci un altro numero:"); // Richiede all'utente di inserire un numero
                num2 = (decimal.Parse(Console.ReadLine())); // Legge il numero inserito dall'utente
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Inserire un numero valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                return; // Termina il programma
            }

            try
            {
                Console.WriteLine(
                    "Che operazione vuoi eseguire?\nAddizione\nSottrazione\nMoltiplicazione\nDivisione)"
                ); // Richiede all'utente di inserire un numero
                sceltaB = (Console.ReadLine().ToUpper()); // Legge l'operazione inserita dall'utente
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Inserire un operazione valida."); // Stampa un messaggio di errore se l'utente non inserisce un operazione
                return; // Termina il programma
            }
            
            if (sceltaB == "ADDIZIONE")
            {
                Console.WriteLine($"Il risultato è: {num1 + num2}");
            }
            else if (sceltaB == "SOTTRAZIONE")
            {
                Console.WriteLine($"Il risultato è: {num1 - num2}");
            }
            else if (sceltaB == "MOLTIPLICAZIONE")
            {
                Console.WriteLine($"Il risultato è: {num1 * num2}");
            }
            else if (sceltaB == "DIVISIONE")
            {
                if (num2 == 0)
                {
                    Console.WriteLine("Errore: Non si può dividere per 0"); // Stampa un messaggio di errore se l'utente vuole dividere per 0
                    return; //Termina il programma
                }
                else
                {
                    Console.WriteLine($"Il risultato è: {num1 / num2}");
                }
            }
        }
 else if (scelta == 5)
{
    Console.WriteLine("Benvenuto a Indovina il Numero!");
    Console.WriteLine("In questo gioco, ti verrà mostrato un numero segreto compreso tra 5 e 9.");
    Console.WriteLine("Il numero verrà nascosto, e il tuo compito sarà indovinare dietro quale valore si trova!");
    Console.WriteLine("Hai a disposizione due tentativi per indovinare correttamente.");

    int vite = 2;
    int numero = random.Next(5, 10);
    int OO = 1;
    int O1 = 2;
    int O2 = 3;

    Console.WriteLine($"Il numero è {numero}\n");
    Console.WriteLine($"{OO}\n{O1}\n{O2}");

    int sceltaD;
    int sceltaC;

    try
            {
                Console.WriteLine("\nDietro quale valore è?");
                sceltaC = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Inserire un valore valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                return; // Termina il programma
            }

    if (sceltaC == OO)
    {
        OO = random.Next(5, 10);
        if (OO == numero)
        {
            Console.WriteLine($"Hai vinto {nome}!");
            return;
        }
        else
        {
            Console.WriteLine($"Hai perso una vita {nome}!");
            vite = vite - 1;
            try
            {
                Console.WriteLine("Riprova, dietro quale valore pensi che sia?");
                sceltaD = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Inserire un valore valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                return; // Termina il programma
            }

            O1 = 2;
            if (sceltaD == O1)
            {
                O1 = random.Next(5, 10);
                if (O1 == numero)
                {
                    Console.WriteLine($"Hai vinto {nome}!");
                    return;
                }
                else
                {
                    Console.WriteLine($"Hai perso una vita {nome}!");
                    vite = vite - 1;

                    if (vite == 0)
                    {
                        Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                    }
                }
            }
        }
    }
    else if (sceltaC == O2)
    {
        O2 = random.Next(5, 10);
        if (O2 == numero)
        {
            Console.WriteLine($"Hai vinto {nome}!");
            return;
        }
        else
        {
            Console.WriteLine($"Hai perso una vita {nome}!");
            vite = vite - 1;

            if (vite == 0)
            {
                Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
            }
        }
    }
    else if (sceltaC == O1)
    {
        if (O1 == numero)
        {
            Console.WriteLine($"Hai vinto {nome}!");
            return;
        }
        else
        {
            Console.WriteLine($"Hai perso una vita {nome}!");
            vite = vite - 1;
            try
            {
                Console.WriteLine("Riprova, dietro quale valore pensi che sia?");
                sceltaD = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Inserire un valore valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                return; // Termina il programma
            }

            if (sceltaD == OO)
            {
                if (OO == numero)
                {
                    Console.WriteLine($"Hai vinto {nome}!");
                    return;
                }
                else
                {
                    Console.WriteLine($"Hai perso una vita {nome}!");
                    vite = vite - 1;

                    if (vite == 0)
                    {
                        Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                    }
                }
            }
            else if (sceltaD == O2)
            {
                if (O2 == numero)
                {
                    Console.WriteLine($"Hai vinto {nome}!");
                    return;
                }
                else
                {
                    Console.WriteLine($"Hai perso una vita {nome}!");
                    vite = vite - 1;

                    if (vite == 0)
                    {
                        Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                    }
                }
            }
        }
    }
    else if (sceltaC == O2)
    {
        if (O2 == numero)
        {
            Console.WriteLine($"Hai vinto {nome}!");
            return;
        }
        else
        {
            Console.WriteLine($"Hai perso una vita {nome}!");
            vite = vite - 1;
            try
            {
                Console.WriteLine("Riprova, dietro quale valore pensi che sia?");
                sceltaD = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Inserire un valore valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                return; // Termina il programma
            }

            if (sceltaD == OO)
            {
                if (OO == numero)
                {
                    Console.WriteLine($"Hai vinto {nome}!");
                    return;
                }
                else
                {
                    Console.WriteLine($"Hai perso una vita {nome}!");
                    vite = vite - 1;
                    try
            {
                Console.WriteLine("Riprova, dietro quale valore pensi che sia?");
                sceltaD = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Inserire un valore valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                return; // Termina il programma
            }

                    if (vite == 0)
                    {
                        Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                    }
                }
            }
            else if (sceltaD == O1)
            {
                if (O1 == numero)
                {
                    Console.WriteLine($"Hai vinto {nome}!");
                    return;
                }
                else
                {
                    Console.WriteLine($"Hai perso una vita {nome}!");
                    vite = vite - 1;
                    try
            {
                Console.WriteLine("Riprova, dietro quale valore pensi che sia?");
                sceltaD = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Inserire un valore valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                return; // Termina il programma
            }

                    if (vite == 0)
                    {
                        Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                    }
                }
            }
        }
    }
}

    static decimal CalcolaMedia(List<int> valori)
    {
        int somma = 0; // Variabile per memorizzare la somma dei numeri
        foreach (int valore in valori)
        {
            somma += valore; // Aggiunge il valore corrente alla somma totale
        }
        return decimal.Round((decimal)somma / valori.Count, 2); // Calcola e restituisce la media dei numeri
    }
    }
}