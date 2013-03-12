
using System.Windows.Forms;
namespace ScreenGrab
{
    public static class ControlExtentions
    {
        public delegate void InvokeHandler();

        public static bool SafeInvoke(this Control control, InvokeHandler handler)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(handler);
                return false;
            }
            return true;
        }
    }
}
