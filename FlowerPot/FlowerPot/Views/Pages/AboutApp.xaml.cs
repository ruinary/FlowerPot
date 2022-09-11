using System;
using System.Windows;
using System.Windows.Controls;

namespace FlowerPot
{
    public partial class AboutApp : Page
    {
        public AboutApp()
        {
            InitializeComponent(); 
            
            ChangeLanguage();
        }

        #region Функции инициализации в окне
        private void ChangeLanguage()
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(Settings.local, UriKind.Relative);
            Resources.MergedDictionaries.Add(dict);
        }
        #endregion
    }
}
