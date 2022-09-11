using FlowerPot.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace FlowerPot
{
    public partial class MainWindow : Window
    {
        MainViewModel m = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            
            ChangeLanguage();
            ChangeTheme();
            DataContext = m;
        }

        #region Функции инициализации в окне
        private void ChangeLanguage()
        {
            var dict = Application.LoadComponent(new Uri(Settings.theme, UriKind.Relative)) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
        private void ChangeTheme()
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(Settings.theme, UriKind.Relative);
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion
    }
}
