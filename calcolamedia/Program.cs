{
Random random = new Random();
int rnd;
decimal media;
decimal Media;
int[] valori = new int[10];

Console.WriteLine("Inserisci il tuo nome:");
string nome = Console.ReadLine();

Console.WriteLine($"Di che hai bisogno {nome}?\n Digita 1 per il generatore di numeri\nDigita 2 per il calcolatore della media");

if (Int32.Parse(Console.ReadLine()) == 1)
{
    Console.WriteLine("Digita limite (es. 100 quindi genererà da 1 a 100)");
    rnd = random.Next(1, Int32.Parse(Console.ReadLine()));
    Console.WriteLine($"Il numero generato è: \t{rnd}");
}
else if (Int32.Parse(Console.ReadLine()) == 2)
{
Console.WriteLine("Inserisci dei numeri per calcolarne le medie (minimo 2 numerei; massimo 10 numeri)");

valori[0] = Int32.Parse(Console.ReadLine());
valori[1] = Int32.Parse(Console.ReadLine());
Console.WriteLine("Continuare? Si, No");
string continua = Console.ReadLine().ToUpper();
if (continua == "SI")
{
    Console.WriteLine("Immettere valore");
    valori[2] = Int32.Parse(Console.ReadLine());
    Console.WriteLine("Continuare? Si, No");
    continua = Console.ReadLine().ToUpper();
    if (continua == "SI")
    {
        Console.WriteLine("Immettere valore");
        valori[3] = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Continuare? Si, No");
        continua = Console.ReadLine().ToUpper();
        if (continua == "SI")
        {
            Console.WriteLine("Immettere valore");
            valori[4] = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Continuare? Si, No");
            continua = Console.ReadLine().ToUpper();
            if (continua == "SI")
            {
                Console.WriteLine("Immettere valore");
                valori[5] = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Continuare? Si, No");
                continua = Console.ReadLine().ToUpper();
                if (continua == "SI")
                {
                    Console.WriteLine("Immettere valore");
                    valori[6] = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Continuare? Si, No");
                    continua = Console.ReadLine().ToUpper();
                    if (continua == "SI")
                    {
                       Console.WriteLine("Immettere valore");
                       valori[7] = Int32.Parse(Console.ReadLine());
                       Console.WriteLine("Continuare? Si, No");
                       continua = Console.ReadLine().ToUpper();
                       if (continua == "SI")
                       {
                           Console.WriteLine("Immettere valore");
                           valori[8] = Int32.Parse(Console.ReadLine());
                           Console.WriteLine("Continuare? Si, No");
                           continua = Console.ReadLine().ToUpper();
                           if (continua == "SI")
                           {
                               Console.WriteLine("Immettere valore");
                               valori[9] = Int32.Parse(Console.ReadLine());
                               media = (valori[0]+valori[1]+valori[2]+valori[3]+valori[4]+valori[5]+valori[6]+valori[7]+valori[8]+valori[9]);
                               Media = decimal.Round(media/10, 2);
                               Console.WriteLine(($"La media di questi numeri è:\t {Media}"));

                           }
                           else if (continua == "NO")
                           {
                               media = (valori[0]+valori[1]+valori[2]+valori[3]+valori[4]+valori[5]+valori[6]+valori[7]+valori[8]);
                               Media = decimal.Round(media/9, 2);
                               Console.WriteLine(($"La media di questi numeri è:\t {Media}"));
                           }
                       }
                       else if (continua == "NO")
                       {
                           media = (valori[0]+valori[1]+valori[2]+valori[3]+valori[4]+valori[5]+valori[6]+valori[7]);
                           Media = decimal.Round(media/8, 2);
                           Console.WriteLine(($"La media di questi numeri è:\t {Media}"));
                       }
                    }
                    else if (continua == "NO")
                    {
                        media = (valori[0]+valori[1]+valori[2]+valori[3]+valori[4]+valori[5]+valori[6]);
                        Media = decimal.Round(media/7, 2);
                        Console.WriteLine(($"La media di questi numeri è:\t {Media}"));
                    }

                }
                else if (continua == "NO")
                {
                    media = (valori[0]+valori[1]+valori[2]+valori[3]+valori[4]+valori[5]);
                    Media = decimal.Round(media/6, 2);
                    Console.WriteLine(($"La media di questi numeri è:\t {Media}"));
                }
            }
            else if (continua == "NO")
            {
                media = (valori[0]+valori[1]+valori[2]+valori[3]+valori[4]);
                Media = decimal.Round(media/5, 2);
                Console.WriteLine(($"La media di questi numeri è:\t {Media}"));
            }
        }
        else if (continua == "NO")
        {
           media = (valori[0]+valori[1]+valori[2]+valori[3]);
           Media = decimal.Round(media/4, 2);
           Console.WriteLine(($"La media di questi numeri è:\t {Media}"));
        }
    }
    else if (continua == "NO")
    {
        media = (valori[0]+valori[1]+valori[2]);
        Media = decimal.Round(media/3, 2);
        Console.WriteLine(($"La media di questi numeri è:\t {Media}"));
    }
}
else if (continua == "NO")
{
    media = (valori[0]+valori[1]);
    Media = decimal.Round(media/2, 2);
    Console.WriteLine(($"La media di questi numeri è:\t {Media}"));
}
}
}