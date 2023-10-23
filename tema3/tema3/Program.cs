using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"

Alegeti proiectul:
1.Tema2
2.Tema3

->Introduceti alegerea");
            var optiune = Console.ReadLine();
            switch (optiune)
            {
                case "1":
                    using (tema2 Window = new tema2())
                    {
                        Window.Run();
                    }
                    break;
                case "2":
                    using (tema_3 Window = new tema_3())
                    {
                        Window.Run();
                    }
                    break;



            }    

           
        }
    }
}
