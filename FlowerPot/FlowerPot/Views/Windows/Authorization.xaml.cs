using FlowerPot.Models;
using FlowerPot.Unit;
using FlowerPot.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Resources;

namespace FlowerPot.Views.Windows
{
    public partial class Authorization : Window
    {
        AuthorizationViewModel m = new AuthorizationViewModel();

        public Authorization()
        {
            InitializeComponent();

            ChangeCursor();
            ChangeLanguage();
            ChangeTheme();
            DataContext = m;
        }
        public void GetPassword(object sender, RoutedEventArgs e)
        {
            m.password = password.Password;
        }

        #region Функции инициализации в окне

        private void ChangeCursor()
        {
            this.Cursor = Cursors.None;
            StreamResourceInfo sri = Application.GetResourceStream(new Uri(Settings.cursor, UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;
            Mouse.OverrideCursor = customCursor;
        }
        private void ChangeLanguage()
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(Settings.local, UriKind.Relative);
            Resources.MergedDictionaries.Add(dict);
        }
        private void ChangeTheme()
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(Settings.theme, UriKind.Relative);
            Resources.MergedDictionaries.Add(dict);
        }

        #endregion
        
    }

}
