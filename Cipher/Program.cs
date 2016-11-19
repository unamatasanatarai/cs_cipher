using System;

namespace Cipher
{
    class Program
    {
        Menu menu = new Menu();

        const string id_cezar = "cezar";
        const string id_atbash = "atbash";
        const string id_bacon = "bacon";
        const string id_morse = "morse";

        const string id_from = "from";
        const string id_to = "to";

        const string id_back = "back";

        static void Main(string[] args)
        {
            Credits.Display();
            Program program = new Program();
            if (args.Length < 4 && args.Length > 0)
            {
                program.displayHelp();
                return;
            }

            if (args.Length > 0 && args.Length <= 4)
            {
                if (args.Length == 3 && args[2] == id_atbash)
                {
                    args[3] = id_from;
                }

                program.fromArgs(args[0], args[1], args[2], args[3]);
            }
            else
            {
                program.fromMenu();
            }
        }

        public Program() { }

        public void fromArgs(String inFile, String outFile, String algorithm, String direction = "to")
        {
            CipherAlgorithm alg = getAlgorithm(algorithm);
            if (getAlgorithm(algorithm) == null)
            {
                displayHelp();
                return;
            }
            if (direction != id_from && direction != id_to)
            {
                displayHelp();
                return;
            }

            string inText = "";
            try
            {
                inText = System.IO.File.ReadAllText(inFile);
            }
            catch (Exception e)
            {
                Console.WriteLine("(!) Failed to read from file\n");
                displayHelp();
            }

            string result = "";

            if (direction == id_from)
            {
                result = alg.from(inText);
            }
            else
            {
                result = alg.to(inText);
            }
            System.IO.File.WriteAllText(outFile, result);
            Console.WriteLine("Zapisałem do pliku {0}", outFile);
        }

        public void fromMenu()
        {
            string direction;
            string identifier;
            do
            {
                identifier = displayAlgorithmMenu();
                direction = displayDirectionMenu(identifier);
            } while (direction == id_back);

            Console.Clear();
            Console.WriteLine("Wpisz tekst (potwierdź enterem)\n");
            string input = Console.ReadLine();
            Console.Clear();

            CipherAlgorithm algorithm = getAlgorithm(identifier);

            if (direction == id_from)
            {
                Console.WriteLine(algorithm.from(input));
            }
            else
            {
                Console.WriteLine(algorithm.to(input));
            }

            Console.ReadKey(true);
        }

        CipherAlgorithm getAlgorithm(string identifier)
        {
            if (identifier == id_cezar)
            {
                return new CipherCezar();
            }
            if (identifier == id_atbash)
            {
                return new CipherAtBash();
            }
            if (identifier == id_morse)
            {
                return new CipherMorse();
            }
            if (identifier == id_bacon)
            {
                return new CipherBacon();
            }
            return null;
        }

        string displayAlgorithmMenu()
        {
            Console.Clear();
            Credits.Display();
            menu.reset();
            menu.setTitle("Wybierz algorytm szyfrowania");
            menu.addItem(id_cezar, "Szyfr Cezara");
            menu.addItem(id_atbash, "Szyfr AtBash");
            menu.addItem(id_bacon, "Szyfr Bacona");
            menu.addItem(id_morse, "Kod Morse’a");

            return menu.displayAndGetInput();
        }

        string displayDirectionMenu(string identifier)
        {
            if (identifier == id_atbash)
            {
                return id_from;
            }
            Console.Clear();
            menu.reset();
            menu.setTitle("Wybierz typ (od)szyfrowania");
            menu.addItem(id_to, "Zaszyfruj");
            menu.addItem(id_from, "Odszyfruj");
            menu.addItem(id_back, "Wróć do poprzedniego menu");
            return menu.displayAndGetInput();
        }

        public void displayHelp()
        {
            Console.WriteLine("uruchamianie: Cipher.exe plik_źródłowy plik_do_zapisu algorygm kierunek");
            Console.WriteLine("przykład: Cipher.exe text.txt encrypted.txt morse to");
            Console.WriteLine("\noptions:");
            Console.WriteLine("   plik_źródłowy  - plik z tekstem do zakodowania/odkodowania");
            Console.WriteLine("   plik_do_zapisu - plik do zapisania rezultatu zakodowania/odkodowania");
            Console.WriteLine("   algorytm       - bacon|morse|cezar|atbash");
            Console.WriteLine("   kierunek       - from|to");
        }
    }
}
