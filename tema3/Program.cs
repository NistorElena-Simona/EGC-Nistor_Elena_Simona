using OpenTK;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using tema3.OpenGLCubeColorChange;

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
3.Tema4

->Introduceti alegerea");
            var optiune = Console.ReadLine();
            switch (optiune)
            {
                case "1":
                    using (tema2 Window = new tema2())
                    {
                        Console.WriteLine(@"
Aici avem o piramida ce se invarte, care la miscarea mouse-ului
se va misca si ea in sensul mouseu-ului, iar la apasarea 
tastei B piramida va diparea
ESC - iesirea din program
");
                        Window.Run();
                    }
                    break;
                case "2":
                    Console.WriteLine(@"
Aici avem un triunghi care se misca in tandem cu mouse-ul
iar la apasarea tastei space se va schimba nuanta de culoare
a triunghiului in ceva mai deschis pana devine alb ");
                    using (tema_3 Window = new tema_3())
                    {

                        Window.Run();
                    }
                    break;
                case "3":
                    using (citire_fisier Window = new citire_fisier()) 
                    {
                        Console.WriteLine(@"
-----------------------------------------------------------
MENU                                                      |
| --------------------------------------------------------|
| ESC - exit application                                  |
| H   - display HELP menu                                 |
| Instructions                                            |
| --------------------------------------------------------|
| 1 - Set vertex 1 color to a random color                |
| 2 - Set vertex 2 color to a random color                |
| 3 - Set vertex 3 color to a random color                |
| Up Arrow + R - Increase red component                   |
| Down Arrow + R - Decrease red component                 |
| Up Arrow + B - Increase blue component                  |
| Down Arrow + B - Decrease blue component                |
| Up Arrow + G - Increase green component                 |
| Down Arrow + G - Decrease green component               |
| Up Arrow + A - Increase alpha component                 |
| Down Arrow + A - Decrease alpha component               |
| Left Mouse Button - Rotate the system to the left       |
| Right Mouse Button - Rotate the system to the right     |
|_________________________________________________________|");
                        Window.Run();
                    }
                    break;



            }    

           
        }
    }
}
