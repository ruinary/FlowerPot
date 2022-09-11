using FlowerPot.ViewModels;
using System.Windows.Controls;

namespace FlowerPot.Views.UC
{
    public partial class WinBar : UserControl
    {
        WinControlsViewModel m = new WinControlsViewModel();
        public WinBar()
        {
            InitializeComponent();
            DataContext = m;
        }
    }
}
