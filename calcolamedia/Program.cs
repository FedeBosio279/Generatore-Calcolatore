using System;
using System.Collections.Generic;

// Variabili per gestire le password dell'utente
string password = "";     // Variabile per la password principale
string password2 = "";    // Variabile per una seconda password (potrebbe essere utilizzata per confronti o verifiche)
string password3 = "";    // Variabile per la password utilizzata durante la procedura di logout
string password4 = "";    // Variabile per la nuova password inserita dall'utente durante la procedura di cambio password

// Variabili di controllo per il flusso del programma
int pass = 0;             // Variabile per il passaggio tra le fasi del programma
int pass1 = 0;            // Variabile per il passaggio tra le fasi specifiche dell'autenticazione e della registrazione

// Variabili per gestire i nomi dell'utente
string nome = "";         // Variabile per memorizzare il nome dell'utente
string nome2 = "";        // Variabile per memorizzare un secondo nome durante la procedura di autenticazione

// Variabili per gestire i cognomi dell'utente
string cognome = "";      // Variabile per memorizzare il cognome dell'utente
string cognome2 = "";     // Variabile per memorizzare un secondo cognome durante la procedura di autenticazione

// Variabile per confermare il nome dell'utente
string confermaNome = ""; // Variabile per la conferma del nome completo dell'utente

// Variabile per memorizzare la data di nascita dell'utente
string dataCompleta = ""; // Variabile per memorizzare la data di nascita completa dell'utente

// Variabili per gestire le scelte dell'utente
string sceltaG = "";      // Variabile per memorizzare la scelta dell'utente durante la procedura di autenticazione o registrazione
int sceltaF = 0;          // Variabile per memorizzare la scelta dell'utente durante le fasi iniziali del programma

do
{
    // Dichiarazione delle variabili

    Random random = new();

    decimal media;

    while (pass1 == 0)
    {
        // Saluto iniziale
        Console.WriteLine($"Benvenut*");
        Console.WriteLine("Per procedere con il programma, registrati");
        pass = 2;
        pass1 = 2;
    }

    while (pass1 == 1)
    {
        // Un loop che continua finché la variabile pass1 è uguale a 1
        do
        {
            try
            {
                // Visualizza un messaggio di benvenuto e le opzioni per l'utente
                Console.WriteLine("Benvenuto");
                Console.WriteLine("Per continuare col programma;");
                Console.WriteLine("Digitare 1 per accedere");
                Console.WriteLine("Digitare 2 per registrarsi");

                // Legge l'input dell'utente e lo converte in un intero
                sceltaF = Int32.Parse(Console.ReadLine());

                // Controlla se l'input è valido (1 o 2)
                if (sceltaF > 2 || sceltaF <= 0)
                {
                    Console.WriteLine("Errore: Assicurarsi di aver scritto 1 o 2");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Assicurarsi di aver digitato 1 o 2");
            }
        } while (sceltaF > 2 || sceltaF <= 0); // Continua il loop finché l'input non è 1 o 2

        pass1 = 3; // Imposta pass1 a 3 per uscire dal loop esterno
    }

    if (sceltaF == 1 && pass1 == 3)
    {
        // Se l'utente ha scelto di accedere e pass1 è 3, esegue il seguente blocco di codice
        do
        {
            try
            {
                // Richiede e legge il nome dall'utente
                Console.WriteLine("Inserisci il nome:");
                nome2 = Console.ReadLine();

                // Controlla se il nome inserito è uguale al nome registrato
                if (nome2 == nome)
                {
                    // Se il nome è corretto, richiede e legge il cognome dall'utente
                    do
                    {
                        Console.WriteLine("Inserisci il cognome:");
                        cognome2 = Console.ReadLine();

                        // Controlla se il cognome inserito è uguale al cognome registrato
                        if (cognome2 == cognome)
                        {
                            // Se il cognome è corretto, richiede e legge la password dall'utente
                            do
                            {
                                Console.WriteLine("Inserisci la tua password:");
                                password4 = Console.ReadLine();

                                // Controlla se la password inserita è corretta
                                if (password4 == password)
                                {
                                    // Se la password è corretta, l'accesso è riuscito e imposta pass1 a 4
                                    Console.WriteLine("Accesso effettuato con successo!");
                                    pass1 = 4;
                                }
                                else
                                {
                                    Console.WriteLine("Errore: Password errata");
                                }
                            } while (password4 != password); // Continua il loop finché la password non è corretta
                        }
                        else
                        {
                            Console.WriteLine("Errore: Cognome non esistente");
                        }
                    } while (cognome2 != cognome); // Continua il loop finché il cognome non è corretto
                }
                else
                {
                    Console.WriteLine("Errore: nome non esistente");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: assicurarsi di non aver inserito numeri");
            }
        } while (nome2 != nome); // Continua il loop finché il nome non è corretto
    }
    else if (sceltaF == 2 && pass1 == 3)
    {
        // Se l'utente ha scelto di registrarsi e pass1 è 3, imposta pass1 a 2 per uscire dal loop esterno
        pass1 = 2;
    }

    // Loop per assicurarsi che il nome sia corretto
    while (pass1 == 2)
    {
        // Loop principale che continua finché la variabile pass1 è uguale a 2
        do
        {
            try
            {
                // Richiede e legge il nome e il cognome dell'utente
                Console.WriteLine("Inserisci il tuo nome:");
                nome = Console.ReadLine();
                Console.WriteLine("Inserisci il tuo cognome:");
                cognome = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Assicurarsi di aver scritto un nome corretto");
            }

            do
            {
                // Chiede all'utente di confermare il nome completo
                Console.WriteLine($"Il tuo nome completo è quindi: {nome} {cognome}? (Si, No)");
                confermaNome = Console.ReadLine().Trim().ToLower();

                // Controlla se la risposta è valida
                if (confermaNome != "si" && confermaNome != "no")
                {
                    Console.WriteLine("Inserimento non valido. Rispondi 'Si' o 'No'.");
                }
            } while (confermaNome != "si" && confermaNome != "no");

            // Incrementa pass1 per uscire dal loop principale
            pass1++;
        } while (confermaNome == "no" || pass1 == 2); // Continua il loop se la conferma del nome è "no" o se pass1 è ancora 2
    }


    while (pass1 == 3)
    {
        if (confermaNome == "si" || pass1 == 3)
        {
            // Variabili per la data di nascita
            int dataNascita = 0;
            int meseNascita = 0;
            int annoNascita = 0;
            string dataCompletaConferma = "";

            // Loop per richiedere e confermare la data di nascita
            do
            {
                // Richiesta del giorno di nascita
                do
                {
                    try
                    {
                        Console.WriteLine("Inserisci ora la tua data di nascita\nGiorno? es (02, 12, 31)");
                        dataNascita = Int32.Parse(Console.ReadLine());
                        if (dataNascita > 31 || dataNascita < 1)
                        {
                            Console.WriteLine(
                                "Errore: assicurarsi che il giorno sia stato inserito in modo corretto"
                            );
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Errore: Assicurarsi di aver inserito un valore numerico intero");
                    }
                } while (dataNascita > 31 || dataNascita < 1);

                // Richiesta del mese di nascita
                do
                {
                    try
                    {
                        Console.WriteLine("Mese? es (1, 2, 5, 12)");
                        meseNascita = Int32.Parse(Console.ReadLine());
                        if (meseNascita < 1 || meseNascita > 12)
                        {
                            Console.WriteLine(
                                "Errore: assicurarsi che il mese sia stato inserito nel modo corretto"
                            );
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Errore: Assicurarsi di aver inserito un valore numerico intero");
                    }
                } while (meseNascita < 1 || meseNascita > 12);

                // Richiesta dell'anno di nascita
                do
                {
                    try
                    {
                        Console.WriteLine("Inserire l'anno (1104 - 2024)");
                        annoNascita = Int32.Parse(Console.ReadLine());
                        if (annoNascita < 1104 || annoNascita > 2024)
                        {
                            Console.WriteLine(
                                "Errore: assicurarsi che l'anno sia compreso tra il 1104 e il 2024"
                            );
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Errore: Assicurarsi di aver inserito un valore numerico intero");
                    }
                } while (annoNascita < 1104 || annoNascita > 2024);

                // Conferma della data di nascita
                do
                {
                    try
                    {
                        Console.WriteLine(
                    $"La tua data di nascita è quindi: {dataNascita}/{meseNascita}/{annoNascita}? (Si, No)"
                );
                        dataCompleta = $"{dataNascita}/{meseNascita}/{annoNascita}";
                        dataCompletaConferma = Console.ReadLine().Trim().ToLower();

                        if (dataCompletaConferma != "si" && dataCompletaConferma != "no")
                        {
                            Console.WriteLine("Inserimento non valido. Rispondi 'Si' o 'No'.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Errore: Assicurarsi di aver inserito \"si\" oppure \"no\"");
                    }
                } while (dataCompletaConferma != "si" && dataCompletaConferma != "no");
            } while (dataCompletaConferma == "no");

            // Se la data di nascita è confermata, chiedi e conferma la password
            if (dataCompletaConferma == "si")
            {

                do
                {
                    try
                    {
                        bool entry = false;
                        Console.WriteLine("Inserisci ora una nuova password della lunghezza di almeno 5 caratteri:");

                        do
                        {
                            password = Console.ReadLine();

                            if (password.Length >= 5)
                            {
                                entry = true;
                            }
                            else
                            {
                                Console.WriteLine("Errore: La password deve contenere almeno 5 caratteri, riprova");
                            }
                        } while (entry == false);

                        Console.WriteLine("Ripeti la password:");
                        password2 = Console.ReadLine();

                        if (password != password2)
                        {
                            Console.WriteLine("Errore: le password non corrispondono");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Errore: inserisci una password valida");
                        return;
                    }
                } while (password != password2);

                Console.WriteLine("Password aggiornata con successo, accesso effettuato");
                pass1 = 5;
            }
        }
    }

    int scelta; // Variabile per memorizzare la scelta dell'utente

    do
    {
        pass1 = 0;

        // Menu delle opzioni disponibili
        Console.WriteLine($"\nDi che hai bisogno {nome}?");
        Console.WriteLine("Digita 0 per arrestare il programma");
        Console.WriteLine("Digita 1 per il generatore di numeri");
        Console.WriteLine("Digita 2 per il calcolatore della media");
        Console.WriteLine("Digita 3 per giocare a \"Indovino\" ");
        Console.WriteLine("Digita 4 per la calcolatrice");
        Console.WriteLine("Digita 5 per \"Acchiappa il numero!\" ");
        Console.WriteLine("Digita 6 per il Contatore di occorrenze di nomi o numeri");
        Console.WriteLine("Digita 7 per entrare nelle impostazioni");

        try
        {
            scelta = Int32.Parse(Console.ReadLine()); // Legge la scelta dell'utente e la converte in un intero

            switch (scelta)
            {
                case 0:
                    {
                        return; // Termina il programma se l'utente sceglie 0
                    }

                case 1:
                    {
                        int limiteMinore;
                        int limiteMaggiore;

                        // Richiesta e controllo del limite minore
                        do
                        {
                            Console.WriteLine("Digita il limite minore (deve essere un numero positivo):");

                            try
                            {
                                limiteMinore = Int32.Parse(Console.ReadLine());

                                if (limiteMinore < 0)
                                {
                                    Console.WriteLine("Errore: Il limite minore deve essere un numero positivo.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Errore: Inserire un numero valido per il limite minore.");
                                limiteMinore = -1; // Imposta un valore non valido per far ripetere il ciclo
                            }
                        } while (limiteMinore < 0);

                        // Richiesta e controllo del limite maggiore
                        do
                        {
                            Console.WriteLine($"Digita il limite maggiore (deve essere maggiore di {limiteMinore}):");

                            try
                            {
                                limiteMaggiore = Int32.Parse(Console.ReadLine());

                                if (limiteMaggiore <= limiteMinore)
                                {
                                    Console.WriteLine("Errore: Il limite maggiore deve essere maggiore del limite minore.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Errore: Inserire un numero valido per il limite maggiore.");
                                limiteMaggiore = -1; // Imposta un valore non valido per far ripetere il ciclo
                            }
                        } while (limiteMaggiore <= limiteMinore);

                        // Generazione del numero casuale tra i limiti
                        int rnd = random.Next(limiteMinore, limiteMaggiore + 1);
                        Console.WriteLine($"Il numero generato è: {rnd}");
                        pass = 2;
                        break;
                    }


                case 2:
                    {
                        List<int> valori = new List<int>(); // Lista per memorizzare i numeri inseriti dall'utente

                        // Richiesta all'utente di inserire i numeri per calcolarne la media
                        Console.WriteLine("Inserisci dei numeri per calcolarne le medie");

                        string scelta2 = ""; // Dichiarazione e inizializzazione della variabile scelta2

                        // Ciclo per continuare a richiedere numeri finché l'utente desidera inserirne
                        do
                        {
                            int numero;

                            try
                            {
                                // Richiesta all'utente di inserire un numero
                                Console.WriteLine("Inserisci un numero:");
                                numero = Int32.Parse(Console.ReadLine()); // Legge il numero inserito dall'utente
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Errore: Inserire un numero valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                                continue; // Continua con il prossimo ciclo
                            }

                            valori.Add(numero); // Aggiunge il numero alla lista

                            // Richiesta all'utente se desidera inserire un altro numero
                            Console.WriteLine("Vuoi inserire un altro numero? (Si/No)");
                            scelta2 = Console.ReadLine(); // Legge la scelta dell'utente
                        } while (scelta2.ToUpper() == "SI"); // Continua a richiedere numeri fintanto che l'utente risponde "Si"

                        // Calcolo della media dei numeri inseriti
                        media = CalcolaMedia(valori);

                        // Stampa della media calcolata
                        Console.WriteLine($"La media di questi numeri è: {media}");
                        pass = 2;
                        break;
                    }



                case 3:
                    {
                        Random rnd = new Random(); // Inizializza un nuovo oggetto Random per generare numeri casuali
                        int numeroGiusto; // Variabile per memorizzare il numero da indovinare
                        int numeriGen; // Variabile per memorizzare il numero di numeri da generare

                        // Saluto all'utente e richiesta se conosce le regole del gioco
                        Console.WriteLine("Ciao! Benvenuto a Indovina!");
                        Console.WriteLine("Sai come funziona? Si, No");

                        string sceltaA;
                        do
                        {
                            sceltaA = Console.ReadLine().ToUpper(); // Legge la risposta dell'utente e la converte in maiuscolo

                            if (sceltaA != "SI" && sceltaA != "NO")
                            {
                                Console.WriteLine("Risposta non valida. Inserisci 'Si' o 'No'."); // Messaggio di errore per risposta non valida
                            }
                        } while (sceltaA != "SI" && sceltaA != "NO");

                        // Se l'utente conosce le regole
                        if (sceltaA == "SI")
                        {
                            // Richiesta all'utente di inserire il numero di numeri da generare
                            Console.WriteLine($"Inserisci quanti numeri vuoi che vengano generati {nome}! (Almeno 2)");

                            numeriGen = Int32.Parse(Console.ReadLine()); // Legge il numero inserito dall'utente

                            if (numeriGen < 2)
                            {
                                Console.WriteLine("Errore: i numeri da generare devono essere almeno 2"); // Messaggio di errore se l'utente inserisce un valore inferiore a 2
                            }
                            else
                            {
                                List<int> ListaNumeri = new List<int>(); // Lista per memorizzare i numeri generati

                                // Generazione dei numeri casuali e aggiunta alla lista
                                for (int i = 0; i < numeriGen; i++)
                                {
                                    int numeroGen = rnd.Next(1, numeriGen); // Genera un numero casuale compreso tra 1 e il numero di numeri da generare
                                    ListaNumeri.Add(numeroGen); // Aggiunge il numero alla lista dei numeri generati
                                }

                                // Stampa dei numeri generati
                                Console.WriteLine("Numeri generati:");
                                foreach (int numeri in ListaNumeri)
                                {
                                    Console.Write($"{numeri} "); // Stampa ciascun numero generato
                                }

                                // Selezione casuale del numero da indovinare tra quelli generati
                                numeroGiusto = ListaNumeri[rnd.Next(0, numeriGen)];

                                // Richiesta all'utente di indovinare il numero
                                Console.WriteLine("\nIndovina il numero giusto");
                                int tentativo = Int32.Parse(Console.ReadLine()); // Legge il tentativo dell'utente

                                // Verifica se il tentativo dell'utente è corretto                            
                                if (tentativo == numeroGiusto)
                                {
                                    Console.WriteLine("Brav* hai indovinato il numero"); // Messaggio di successo se il tentativo è corretto
                                }
                                else if (tentativo != numeroGiusto)
                                {
                                    Console.WriteLine($"Spiacente, il numero giusto era {numeroGiusto}"); // Altrimenti, stampa il numero corretto
                                }
                            }
                        }
                        // Se l'utente non conosce le regole
                        else if (sceltaA == "NO")
                        {
                            // Spiega le regole del gioco all'utente
                            Console.WriteLine("Nessun problema, ora ti spiegherò.");
                            Console.WriteLine("Questo programma genererà una serie di numeri casuali (scegli te quanti numeri generare), dovrai quindi indovinare quello corretto.");
                            Console.WriteLine("Adesso che hai capito cominciamo");

                            // Richiesta all'utente di inserire il numero di numeri da generare
                            Console.WriteLine($"Inserisci quanti numeri vuoi che vengano generati {nome}! (Almeno 2)");

                            int Nnumeri = Int32.Parse(Console.ReadLine()); // Legge il numero inserito dall'utente

                            if (Nnumeri < 2)
                            {
                                Console.WriteLine("Errore: i numeri da generare devono essere almeno 2"); // Messaggio di errore se l'utente inserisce un valore inferiore a 2
                            }
                            else
                            {
                                List<int> ListaNumeri = new List<int>(); // Lista per memorizzare i numeri generati

                                // Generazione dei numeri casuali e aggiunta alla lista
                                for (int i = 0; i < Nnumeri; i++)
                                {
                                    int numeroGen;
                                    do
                                    {
                                        numeroGen = rnd.Next(1, Nnumeri + 1); // Genera un numero casuale compreso tra 1 e il numero di numeri da generare
                                    } while (ListaNumeri.Contains(numeroGen)); // Assicura che il numero generato non sia già presente nella lista

                                    ListaNumeri.Add(numeroGen); // Aggiunge il numero alla lista dei numeri generati
                                }

                                // Stampa dei numeri generati
                                Console.WriteLine("Numeri generati:");
                                foreach (int numeri in ListaNumeri)
                                {
                                    Console.Write($"{numeri} "); // Stampa ciascun numero generato
                                }

                                // Selezione casuale del numero da indovinare tra quelli generati
                                numeroGiusto = ListaNumeri[rnd.Next(0, Nnumeri)];

                                // Richiesta all'utente di indovinare il numero
                                Console.WriteLine("\nIndovina il numero giusto!");
                                int tentativo = Int32.Parse(Console.ReadLine()); // Legge il tentativo dell'utente

                                // Verifica se il tentativo dell'utente è corretto
                                if (tentativo == numeroGiusto)
                                {
                                    Console.WriteLine("Brav* hai indovinato il numero"); // Messaggio di successo se il tentativo è corretto
                                }
                                else
                                {
                                    Console.WriteLine($"Spiacente, il numero giusto era {numeroGiusto}"); // Altrimenti, stampa il numero corretto
                                }
                            }
                        }
                        pass = 2;
                        break;
                    }

                case 4:
                    {
                        Console.WriteLine("Benvenuto in una calcolatrice basica."); // Saluta l'utente e lo accoglie nella calcolatrice
                        decimal num1;
                        decimal num2;
                        string sceltaB;

                        try
                        {
                            Console.WriteLine(
                                "Che operazione vuoi eseguire?\nAddizione\nSottrazione\nMoltiplicazione\nDivisione\nQuadrato\nCubo\nRadice Quadrata"
                            ); // Richiede all'utente di inserire un numero
                            sceltaB = (Console.ReadLine().ToUpper()); // Legge l'operazione inserita dall'utente
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Errore: Inserire un operazione valida."); // Stampa un messaggio di errore se l'utente non inserisce un operazione
                            continue; // Continua con il prossimo ciclo
                        }

                        switch (sceltaB)
                        {
                            case "QUADRATO":
                                try
                                {
                                    Console.WriteLine("Inserisci un numero:");
                                    int num3 = Int32.Parse(Console.ReadLine());
                                    Console.WriteLine($"Il risultato è {num3 * num3}");
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Errore: Assicurarsi di aver inserito un valore valido");
                                }
                                break;

                            case "CUBO":
                                try
                                {
                                    Console.WriteLine("Inserisci un numero:");
                                    int num4 = Int32.Parse(Console.ReadLine());
                                    Console.WriteLine($"Il risultato è {num4 * num4 * num4}");
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Errore: Assicurarsi di aver inserito un valore valido");
                                }
                                break;

                            case "RADICE QUADRATA":
                                try
                                {
                                    Console.WriteLine("Inserisci un numero:");
                                    int num5 = Int32.Parse(Console.ReadLine());
                                    Console.WriteLine("Il risultato è " + Math.Sqrt(num5));
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Errore: Assicurarsi di aver inserito un valore valido");
                                }
                                break;
                        }

                        if (sceltaB == "ADDIZIONE" || sceltaB == "SOTTRAZIONE" || sceltaB == "MOLTIPLICAZIONE" || sceltaB == "DIVISIONE")
                        {
                            try
                            {
                                Console.WriteLine("Inserisci un numero:"); // Richiede all'utente di inserire un numero
                                num1 = decimal.Parse(Console.ReadLine()); // Legge il numero inserito dall'utente
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Errore: Inserire un numero valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                                continue; // Continua con il prossimo ciclo
                            }

                            try
                            {
                                Console.WriteLine("Inserisci un altro numero:"); // Richiede all'utente di inserire un numero
                                num2 = (decimal.Parse(Console.ReadLine())); // Legge il numero inserito dall'utente
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Errore: Inserire un numero valido."); // Stampa un messaggio di errore se l'utente non inserisce un numero
                                continue; // Continua con il prossimo ciclo
                            }

                            // Esegue l'operazione richiesta dall'utente e stampa il risultato
                            switch (sceltaB)
                            {
                                case "ADDIZIONE":
                                    Console.WriteLine($"Il risultato è: {num1 + num2}"); // Effettua l'addizione e stampa il risultato
                                    break;
                                case "SOTTRAZIONE":
                                    Console.WriteLine($"Il risultato è: {num1 - num2}"); // Effettua la sottrazione e stampa il risultato
                                    break;
                                case "MOLTIPLICAZIONE":
                                    Console.WriteLine($"Il risultato è: {num1 * num2}"); // Effettua la moltiplicazione e stampa il risultato
                                    break;
                                case "DIVISIONE":
                                    // Controlla se l'utente sta cercando di dividere per zero
                                    if (num2 == 0)
                                    {
                                        Console.WriteLine("Errore: Non si può dividere per 0"); // Stampa un messaggio di errore se l'utente vuole dividere per 0
                                        continue; // Continua con il prossimo ciclo
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Il risultato è: {num1 / num2}"); // Effettua la divisione e stampa il risultato
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Selezione non valida"); // Stampa un messaggio se la selezione non è valida
                                    break;
                            }
                        }
                        pass = 2;
                        break;
                    }

                case 5:
                    {
                        // Messaggi di benvenuto e istruzioni del gioco
                        Console.WriteLine("Benvenuto a Indovina il Numero!");
                        Console.WriteLine("In questo gioco, ti verrà mostrato un numero segreto compreso tra 5 e 10.");
                        Console.WriteLine("Il numero verrà nascosto, e il tuo compito sarà indovinare dietro quale valore si trova!");
                        Console.WriteLine("Hai a disposizione due tentativi per indovinare correttamente.");

                        // Inizializzazione delle variabili
                        int vite = 2;
                        int numero = random.Next(5, 11);
                        int OO = 1;
                        int O1 = 2;
                        int O2 = 3;

                        // Visualizzazione del numero segreto e delle opzioni
                        Console.WriteLine($"Il numero è {numero}\n");
                        Console.WriteLine($"{OO}\n{O1}\n{O2}");

                        // Dichiarazione delle variabili per la scelta dell'utente
                        int sceltaD;
                        int sceltaC;

                        try
                        {
                            // Input della scelta dell'utente e gestione degli errori
                            Console.WriteLine("\nDietro quale valore è?");
                            sceltaC = Int32.Parse(Console.ReadLine());

                            // Verifica se la scelta dell'utente è valida
                            if (sceltaC < OO || sceltaC > O2)
                            {
                                Console.WriteLine($"Errore: Inserire un valore compreso fra {OO} e {O2}.");
                                continue; // Continua con il prossimo ciclo
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Errore: Inserire un valore valido.");
                            continue; // Continua con il prossimo ciclo
                        }

                        // Gestione del primo livello di scelta
                        if (sceltaC == OO)
                        {
                            // Generazione di un nuovo valore per OO e verifica della correttezza
                            OO = random.Next(5, 11);
                            if (OO == numero)
                            {
                                Console.WriteLine($"Hai vinto {nome}!");
                                break; // Esce dallo switch
                            }
                            else
                            {
                                Console.WriteLine($"Hai perso una vita {nome}!");
                                vite--;
                                if (vite > 0)
                                {
                                    // Richiesta di un altro tentativo se ci sono vite rimanenti
                                    Console.WriteLine("Riprova, dietro quale valore pensi che sia?");
                                    try
                                    {
                                        sceltaD = Int32.Parse(Console.ReadLine());
                                        // Verifica se la scelta dell'utente è valida
                                        if (sceltaD < OO || sceltaD > O2)
                                        {
                                            Console.WriteLine($"Errore: Inserire un valore compreso fra {OO} e {O2}.");
                                            continue; // Continua con il prossimo ciclo
                                        }
                                        // Gestione del secondo livello di scelta
                                        if (sceltaD == O1)
                                        {
                                            // Generazione di un nuovo valore per O1 e verifica della correttezza
                                            O1 = random.Next(5, 11);
                                            if (O1 == numero)
                                            {
                                                Console.WriteLine($"Hai vinto {nome}!");
                                                break; // Esce dallo switch
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Hai perso una vita {nome}!");
                                                vite--;
                                                if (vite == 0)
                                                {
                                                    Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                                                }
                                            }
                                        }
                                        else if (sceltaD == O2)
                                        {
                                            // Generazione di un nuovo valore per O2 e verifica della correttezza
                                            O2 = random.Next(5, 11);
                                            if (O2 == numero)
                                            {
                                                Console.WriteLine($"Hai vinto {nome}!");
                                                break; // Esce dallo switch
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Hai perso una vita {nome}!");
                                                vite--;
                                                if (vite == 0)
                                                {
                                                    Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                                                }
                                            }
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Errore: Inserire un valore valido.");
                                        continue; // Continua con il prossimo ciclo
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                                }
                            }
                        }
                        else if (sceltaC == O1)
                        {
                            // Gestione della scelta dietro O1
                            if (O1 == numero)
                            {
                                Console.WriteLine($"Hai vinto {nome}!");
                                break; // Esce dallo switch
                            }
                            else
                            {
                                Console.WriteLine($"Hai perso una vita {nome}!");
                                vite--;
                                if (vite > 0)
                                {
                                    // Richiesta di un altro tentativo se ci sono vite rimanenti
                                    Console.WriteLine("Riprova, dietro quale valore pensi che sia?");
                                    try
                                    {
                                        sceltaD = Int32.Parse(Console.ReadLine());
                                        // Verifica se la scelta dell'utente è valida
                                        if (sceltaD < OO || sceltaD > O2)
                                        {
                                            Console.WriteLine($"Errore: Inserire un valore compreso fra {OO} e {O2}.");
                                            continue; // Continua con il prossimo ciclo
                                        }
                                        // Gestione del secondo livello di scelta
                                        if (sceltaD == OO)
                                        {
                                            // Generazione di un nuovo valore per OO e verifica della correttezza
                                            OO = random.Next(5, 11);
                                            if (OO == numero)
                                            {
                                                Console.WriteLine($"Hai vinto {nome}!");
                                                break; // Esce dallo switch
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Hai perso una vita {nome}!");
                                                vite--;
                                                if (vite == 0)
                                                {
                                                    Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                                                }
                                            }
                                        }
                                        else if (sceltaD == O2)
                                        {
                                            // Generazione di un nuovo valore per O2 e verifica della correttezza
                                            O2 = random.Next(5, 11);
                                            if (O2 == numero)
                                            {
                                                Console.WriteLine($"Hai vinto {nome}!");
                                                break; // Esce dallo switch
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Hai perso una vita {nome}!");
                                                vite--;
                                                if (vite == 0)
                                                {
                                                    Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                                                }
                                            }
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Errore: Inserire un valore valido.");
                                        continue; // Continua con il prossimo ciclo
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                                }
                            }
                        }
                        else if (sceltaC == O2)
                        {
                            // Gestione della scelta dietro O2
                            if (O2 == numero)
                            {
                                Console.WriteLine($"Hai vinto {nome}!");
                                break; // Esce dallo switch
                            }
                            else
                            {
                                Console.WriteLine($"Hai perso una vita {nome}!");
                                vite--;
                                if (vite > 0)
                                {
                                    // Richiesta di un altro tentativo se ci sono vite rimanenti
                                    Console.WriteLine("Riprova, dietro quale valore pensi che sia?");
                                    try
                                    {
                                        sceltaD = Int32.Parse(Console.ReadLine());
                                        // Verifica se la scelta dell'utente è valida
                                        if (sceltaD < OO || sceltaD > O1)
                                        {
                                            Console.WriteLine($"Errore: Inserire un valore compreso fra {OO} e {O2}.");
                                            continue; // Continua con il prossimo ciclo
                                        }
                                        // Gestione del secondo livello di scelta
                                        if (sceltaD == OO)
                                        {
                                            // Generazione di un nuovo valore per OO e verifica della correttezza
                                            OO = random.Next(5, 11);
                                            if (OO == numero)
                                            {
                                                Console.WriteLine($"Hai vinto {nome}!");
                                                break; // Esce dallo switch
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Hai perso una vita {nome}!");
                                                vite--;
                                                if (vite == 0)
                                                {
                                                    Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                                                }
                                            }
                                        }
                                        else if (sceltaD == O1)
                                        {
                                            // Generazione di un nuovo valore per O1 e verifica della correttezza
                                            O1 = random.Next(5, 11);
                                            if (O1 == numero)
                                            {
                                                Console.WriteLine($"Hai vinto {nome}!");
                                                break; // Esce dallo switch
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Hai perso una vita {nome}!");
                                                vite--;
                                                if (vite == 0)
                                                {
                                                    Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                                                }
                                            }
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Errore: Inserire un valore valido.");
                                        continue; // Continua con il prossimo ciclo
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Hai finito le vite, hai perso {nome}!");
                                }
                            }
                        }
                        pass = 2;
                        break;
                    }

                case 6:
                    {
                        Console.WriteLine("Inserisci una lista di nomi separati da virgole");
                        var inputNomi = Console.ReadLine().ToLower();
                        string[] nomi = inputNomi.Split(',');

                        Console.WriteLine("Che nome vuoi cercare?");
                        string input = Console.ReadLine().ToLower().Trim();

                        int count = 0;

                        foreach (var nome1 in nomi)
                        {
                            if (nome1.Trim().ToLower() == input)
                            {
                                count++;
                            }
                        }

                        if (count > 1)
                        {
                            Console.WriteLine($"\"{input}\" appare {count} volte.");
                        }
                        else if (count == 1)
                        {
                            Console.WriteLine($"\"{input}\" appare {count} volta.");
                        }
                        else if (count == 0)
                        {
                            Console.Write($"{input} non appare nella lista.");
                        }
                        pass = 2;
                        break;
                    }
                case 7:
                    {
                        // Caso 7: Gestione delle impostazioni dell'account
                        do
                        {
                            try
                            {
                                // Visualizza le opzioni di impostazione dell'account
                                Console.WriteLine("\nImpostazioni:\nAccount\nLogout\n\nTorna indietro");
                                string sceltaE = Console.ReadLine().ToLower();

                                if (sceltaE == "account")
                                {
                                    // Se l'utente sceglie "account", mostra le informazioni dell'account e le opzioni aggiuntive
                                    Console.WriteLine($"Account:\nNome:\t{nome}\nCognome:\t{cognome}\nData di nascita:\t{dataCompleta}\nCambia password\n\nTorna indietro");
                                    sceltaG = Console.ReadLine().ToLower().Trim();

                                    if (sceltaG == "tornaindietro")
                                    {
                                        pass = 2; // Imposta la variabile di passaggio su 2 per uscire dal ciclo
                                    }
                                    else if (sceltaG == "cambiapassword")
                                    {
                                        // Se l'utente sceglie di cambiare la password, esegui il seguente blocco di codice
                                        string newPassword;
                                        do
                                        {
                                            Console.WriteLine("Inserisci la password corrente:");
                                            string currentPassword = Console.ReadLine();

                                            if (currentPassword == password)
                                            {
                                                Console.WriteLine("Inserisci la nuova password (almeno 5 caratteri):");
                                                newPassword = Console.ReadLine();

                                                if (newPassword.Length < 5)
                                                {
                                                    Console.WriteLine("Errore: la password deve essere lunga almeno 5 caratteri");
                                                }
                                                else if (newPassword == password)
                                                {
                                                    Console.WriteLine("Errore: la nuova password non può essere uguale alla precedente");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Nuova password aggiornata con successo!");
                                                    password = newPassword;
                                                    pass = 2; // Imposta la variabile di passaggio su 2 per uscire dal ciclo
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Password errata!");
                                            }
                                        } while (pass != 2); // Continua il ciclo finché la password non è stata cambiata correttamente
                                    }
                                }
                                else if (sceltaE == "logout")
                                {
                                    // Se l'utente sceglie "logout", richiede la password per confermare e quindi esce dall'account
                                    Console.WriteLine("Immetti la tua password");
                                    password3 = Console.ReadLine();
                                    if (password3 == password)
                                    {
                                        pass = 1; // Imposta la variabile di passaggio su 1 per uscire dall'account
                                        scelta = 0;
                                        pass1 = 1;
                                        Console.WriteLine("Logout effettuato con successo");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Password incorretta");
                                    }
                                }
                                else if (sceltaE == "torna indietro")
                                {
                                    pass = 2; // Imposta la variabile di passaggio su 2 per uscire dal ciclo
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Errore: Assicurarsi di aver inserito una delle opzioni");
                            }
                        } while (pass != 2 && pass != 1); // Termina il ciclo quando l'utente sceglie "Torna indietro" o effettua il logout
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Scelta non valida. Per favore, scegli un'opzione valida.");
                        pass = 2;
                        break;
                    }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Errore: Inserire un numero valido.");
            scelta = -1; // Imposta un valore non valido per far ripetere il ciclo
        }
    } while (scelta != 0 || (pass == 2) || (pass1 == 5));// Ripeti finché l'utente non sceglie di terminare il programma
} while (pass == 1);

Console.WriteLine("Grazie per aver usato il programma. Arrivederci!"); // Saluta l'utente quando termina il programma

static decimal CalcolaMedia(List<int> valori)
{
    int somma = 0; // Variabile per memorizzare la somma dei numeri
    foreach (int valore in valori)
    {
        somma += valore; // Aggiunge il valore corrente alla somma totale
    }
    return decimal.Round((decimal)somma / valori.Count, 2); // Calcola e restituisce la media dei numeri
}
