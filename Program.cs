using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace LD33_OpenTK
{
    class Program
    {
        static void Main(string[] args)
        {
            LD_Window win =  new LD_Window(GameWindowFlags.Default);
            win.Run(60);
        }
    }
}
