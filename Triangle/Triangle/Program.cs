using System;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

namespace Triangle
{
    public class Program
    {
        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(1200, 720),
                Title = "LearnOpenTk - Creating A Triangle",
                Flags = ContextFlags.ForwardCompatible,
            };

            using (var window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
    }

    public class Window : GameWindow
    {
        private readonly float[] _vertices =
        {
            -0.5f, -0.5f, 0.0f, //Bottom left vertex
            0.5f, -0.5f, 0.0f, //Bottom right vertex
            0.0f, 0.5f, 0.0f // Top vertex
        };

        private int _vertexBufferObject;

        private int _vertexArrayObject;

        private Shader _shader;

        // A simple constructor to let us set properties like window size, title, FPS, etc. on the window.
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            _vertexBufferObject = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);

            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices,
                BufferUsageHint.StaticDraw);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            GL.EnableVertexAttribArray(0);

            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");

            _shader.Use();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            
            _shader.Use();
            
            GL.BindVertexArray(_vertexArrayObject);
            
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            
            SwapBuffers();
        }

        // This function runs on every update frame.
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // Check if the Escape button is currently being pressed.
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                // If it is, close the window.
                Close();
            }

            base.OnUpdateFrame(e);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            
            GL.Viewport(0,0,Size.X,Size.Y);
        }

        protected override void OnUnload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);
            
            GL.DeleteBuffer(_vertexBufferObject);           
            GL.DeleteVertexArray(_vertexArrayObject);
            
            GL.DeleteProgram(_shader.Handle);
            
            base.OnUnload();
        }
    }
}