using ConsoleApp3;

using System;
using System.Security.Cryptography;

using tema3.Tema2;
using tema3.Tema3;
using tema3.Tema4;

namespace tema3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Alegeti proiectul:
1. Tema2
2. Tema3
3. Tema4
4. Tema5

Introduceti optiunea: ");

            var optiune = Console.ReadLine();

            switch (optiune)
            {
                case "1":
                    using (Tema2Window window = new Tema2Window())
                    {
                        window.Run();
                    }
                    break;
                case "2":
                    using (Tema3Window window = new Tema3Window())
                    {
                        window.Run();
                    }
                    break;
                case "3":
                    using (Tema4Window window = new Tema4Window()) 
                    {
                        window.Run();
                    }
                    break;
                    case "4":
                    using (tema5_window window = new tema5_window())
                    {
                        window.Run();
                    }
                    break;
                default:
                    Console.WriteLine("Optiune necunoscuta");
                    break;
            }    
        }
    }
}
