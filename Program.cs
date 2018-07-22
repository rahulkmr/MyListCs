using System;

namespace MyList
{
    class Program
    {
        static int changeCount = 0;

        static void ListChanged(object sender, EventArgs eventArgs)
        {
            changeCount++;
        }

        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            names.Changed += new EventHandler(ListChanged);
            names.Add("Liz");
            names.Add("Martha");
            names.Add("Beth");
            Console.WriteLine(changeCount);

            for (int i = 0; i < names.Count; i++) 
            {
                Console.WriteLine(names[i]);
            }
            names[0] = names[0].ToUpper();
            Console.WriteLine(names[0]);
        }
    }
}
