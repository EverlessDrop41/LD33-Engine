using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using LD33_OpenTK.Framework;

namespace LD33_OpenTK
{
    class LD_Window : GameWindow
    {
        List<Level> levels = new List<Level>();

        Level currentLevel;

        public LD_Window(GameWindowFlags flag) : base(600, 600, new GraphicsMode(32 , 24, 8, 64), "Clock", flag)
        {
            VSync = VSyncMode.On;
        }

        public void SwitchLevel(int index)
        {
            if (levels.Count - 1 >= index)
            {
                currentLevel = levels[index];
            }
            else
            {
                throw new ArgumentException("Index not found in levels");
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Add All Levels Here
            Level level = new Level();
            levels.Add(level);

            currentLevel = levels[0];

            //Load all content for the levels
            foreach (Level l in levels)
            {
                l.OnLoad();
            }

            GL.ClearColor(Color.CornflowerBlue);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreateOrthographic(Width, Height, -10, 10);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (Keyboard[Key.Escape])
            {
                Exit();
            }

            currentLevel.Update();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            currentLevel.Draw();

            SwapBuffers();
        }
    }
}
