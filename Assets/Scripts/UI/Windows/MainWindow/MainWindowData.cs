using UI.Core.Windows;

namespace UI.Windows.MainWindow
{
    public class MainWindowData : IWindowData
    {
        public WindowId WindowId { get; } = WindowId.MainWindow;
    }
}