using System;
using System.Collections.Generic;

namespace Cipher
{
    public class Menu
    {
        private string title;
        private List<MenuItem> items = new List<MenuItem>();

        public void setTitle(string text)
        {
            title = text;
        }

        public void addItem(string identifier, string label)
        {
            items.Add(new MenuItem(identifier, label));
        }

        public string displayAndGetInput()
        {
            Console.WriteLine(title);
            Console.WriteLine();

            int i = 1;
            foreach(MenuItem element in items)
            {
                Console.WriteLine("{0}. {1}", i++, element.getLabel());
            }

            int input;

            do
            {
                Int32.TryParse(Console.ReadLine(), out input);
            } while (input <=0 || input > i);
            MenuItem[] mItems = items.ToArray();
            return mItems[input-1].getIdentifier();

        }

        public void reset()
        {
            title = "";
            items.Clear();
        }
    }

    public class MenuItem
    {
        private string identifier;
        private string label;

        public MenuItem(string identifier, string label)
        {
            this.identifier = identifier;
            this.label = label;
        }

        public string getIdentifier()
        {
            return identifier;
        }

        public string getLabel()
        {
            return label;
        }
    }

}
