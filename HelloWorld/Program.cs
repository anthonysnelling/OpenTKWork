using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace HelloWorld
{
    public class Program
    {
        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(1200, 720),
                Title = "LearnOpenTk - Creating A Window",
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
            // A simple constructor to let us set properties like window size, title, FPS, etc. on the window.
            public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
                : base(gameWindowSettings, nativeWindowSettings)
            {
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
        }
}