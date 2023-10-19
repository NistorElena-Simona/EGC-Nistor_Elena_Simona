using System;
using System.Drawing;
using System.Threading;
using System.Windows.Media;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using Color = System.Drawing.Color;

/**
    Aplicația utilizează biblioteca OpenTK v2.0.0 (stable) oficială și OpenTK. GLControl v2.0.0
    (unstable) neoficială. Aplicația fiind scrisă în modul consolă nu va utiliza controlul WinForms
    oferit de OpenTK!
    Tipul de ferestră utilizat: GAMEWINDOW. Se demmonstrează modul imediat de randare (vezi comentariul!)...
**/

/* 
 
 *
 **                  NISTOR ELENA SIMONA
 *                      GRUPA 3131B 
 *                 REZOLVARE LABORATOR 2 EGC
 * 
 */

namespace Nistor_L2
{
    public class Program
    {

        [STAThread]
        public static void Main(string[] args)
        {

            using (SimpleWindow3D example = new SimpleWindow3D())
            {

                example.Run(30.0, 0.0);
            }
        }
    }
}


