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
            Program program = new Program();
        }

        public Program()
        {
            string direction;
            string identifier;
            do
            {
                identifier = displayAlgorithmMenu();
                direction = displayDirectionMenu(identifier);
            } while (direction == "back");

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
            return new CipherCezar();
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
    }
}
