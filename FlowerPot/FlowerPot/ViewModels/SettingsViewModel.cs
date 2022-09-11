using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Mvvm;
using FlowerPot.Views.Pages;
using FlowerPot.Views.Windows;

namespace FlowerPot.ViewModels
{
    class SettingsViewModel
    {
        public ICommand themeStandart => new DelegateCommand(ThemeStandart);
        public void ThemeStandart()
        {
            Settings.theme = @"..\Styles\StandartTheme.xaml";
        }

        public ICommand themeGrey => new DelegateCommand(ThemeGrey);
        public void ThemeGrey()
        {
            Settings.theme = @"..\Styles\GreyTheme.xaml";
        }

        public ICommand themeDark => new DelegateCommand(ThemeDark);
        public void ThemeDark()
        {
            Settings.theme = @"..\Styles\DarkTheme.xaml";
        }
    }
}
