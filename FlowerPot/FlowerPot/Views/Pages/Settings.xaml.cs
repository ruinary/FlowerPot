using FlowerPot.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowerPot
{
    public partial class Settings : Page
    {
        SettingsViewModel m = new SettingsViewModel();
        public static string local = @"..\Localization\Dictionary.ru_RU.xaml";
        public static string theme = @"..\Styles\StandartTheme.xaml";
        public static string cursor = @"\Images\00.cur";

        public Settings()
        {
            InitializeComponent();

            ChangeLanguage();
            ChangeTheme();
            DataContext = m;
        }

        #region Функции инициализации в окне
        private void ChangeTheme()
        {
            var dict = Application.LoadComponent(new Uri(Settings.theme, UriKind.Relative)) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageSelection.Text =="English") { SelectRusLanguage();}
            else { SelectRusLanguage(); }
            if (LanguageSelection.Text == "Русский") { SelectEngLanguage(); }
            
        }
        private void ChangeLanguage()
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(local, UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
        private void SelectRusLanguage()
        {
            local = @"..\Localization\Dictionary.ru_RU.xaml";
            ChangeLanguage();
        }

        private void SelectEngLanguage()
        {
            local = @"..\Localization\Dictionary.eng_ENG.xaml";
            ChangeLanguage();
        }

        public void ThemeStandart(object sender, RoutedEventArgs e)
        {
            Settings.theme = @"..\Styles\StandartTheme.xaml";
            ChangeTheme();
        }

        public void ThemeGrey(object sender, RoutedEventArgs e)
        {
            Settings.theme = @"..\Styles\GreyTheme.xaml";
            ChangeTheme();
        }

        public void ThemeDark(object sender, RoutedEventArgs e)
        {
            Settings.theme = @"..\Styles\DarkTheme.xaml";
            ChangeTheme();
        }

        #endregion
    }
}
