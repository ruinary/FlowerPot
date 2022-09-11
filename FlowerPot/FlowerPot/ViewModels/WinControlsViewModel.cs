using DevExpress.Mvvm;
using FlowerPot.Views.Pages;
using FlowerPot.Views.Windows;
using System.Windows;
using System.Windows.Input;

namespace FlowerPot.ViewModels
{
    class WinControlsViewModel
    {
        public interface ICloseable
        {
            void Close();
        }
        public ICommand close => new DelegateCommand(Close);
        public void Close()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is MoreAboutFlower) { window.Close(); Catalog.openedAbout--; }
                if (window is MiniWindow) { window.Close(); }
                if (window is WindowEditProduct) { window.Close(); }
            }
        }

        public ICommand exit => new DelegateCommand(Exit);
        public void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
