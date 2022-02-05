using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

namespace LearnOpenTk
{
    // This is where our opengl code is written
    public class Window : GameWindow
    {
        // A simple constructor to let us set properties like Window size, title, etc. on the window
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(
            gameWindowSettings, nativeWindowSettings)
        {
        }
        
        // runs on every frame update
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
               Close(); 
            }
            base.OnUpdateFrame(e);
        }
    }
}