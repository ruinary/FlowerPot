using System;
using System.Windows;
using System.Windows.Input;

namespace FlowerPot.Views.Windows
{
    public partial class MiniWindow : Window
    {
        public int idmes { get; set; }

        public MiniWindow(int idmes) 
        {
            this.idmes = idmes;

            InitializeComponent();
            ChangeLanguage();
            ChangeTheme();

            #region Локализация вывода ошибок
            switch (idmes)
            {
                case 0: Message.DataContext = this.Resources["Mes0"]; break;
                case 1: Message.DataContext = this.Resources["Mes1"]; break;
                case 2: Message.DataContext = this.Resources["Mes2"]; break;
                case 3: Message.DataContext = this.Resources["Mes3"]; break;
                case 4: Message.DataContext = this.Resources["Mes4"]; break;
                case 5: Message.DataContext = this.Resources["Mes5"]; break;
                case 6: Message.DataContext = this.Resources["Mes6"]; break;
                case 7: Message.DataContext = this.Resources["Mes7"]; break;
                case 8: Message.DataContext = this.Resources["Mes8"]; break;
                case 9: Message.DataContext = this.Resources["Mes9"]; break;
                case 10: Message.DataContext = this.Resources["Mes10"]; break;
                case 11: Message.DataContext = this.Resources["Mes11"]; break;
                case 12: Message.DataContext = this.Resources["Mes12"]; break;
                case 13: Message.DataContext = this.Resources["Mes13"]; break;

                case 666: Message.DataContext = this.Resources["Mes666"]; break;

                case 22012003: Message.DataContext = this.Resources["Mes22012003"]; break;

                default: break;
            }
            #endregion
        }

        #region Функции инициализации в окне
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

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion
    }
}
