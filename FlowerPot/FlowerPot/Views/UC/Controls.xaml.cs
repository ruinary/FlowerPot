using FlowerPot.Unit;
using FlowerPot.ViewModels;
using FlowerPot.Views.Pages;
using FlowerPot.Views.Windows;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FlowerPot.Views.UC
{
    public partial class Controls : UserControl
    {
        MainViewModel m = new MainViewModel();
        public Controls()
        {
            InitializeComponent();

            ChangeLanguage();
            ChangeTheme();
            DataContext = m;

            using (UnitOfWork uow = new UnitOfWork())
            {
                if (AuthorizationViewModel.currentuser.is_admin == true) 
                { 
                    ItemAdmin.Visibility = Visibility.Visible;
                }
            }
        }

        #region Функции инициализации в окне
        private void ChangeLanguage()
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(Settings.local, UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
        private void ChangeTheme()
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(Settings.theme, UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        #endregion

        #region Закрытие открытие меню
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Hidden;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Hidden;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }
        #endregion

        #region Смена страницы в окне
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemCatalog":
                    Catalog itemCatalog = new Catalog();
                    MainFrame.Navigate(itemCatalog);
                    break;
                case "ItemBasket":
                    Cart itemBasket = new Cart();
                    MainFrame.Navigate(itemBasket);
                    break;
                case "ItemOrders":
                    OrdersInfo itemorders = new OrdersInfo();
                    MainFrame.Navigate(itemorders);
                    break;
                case "ItemAccount":
                    Account itemccount = new Account();
                    MainFrame.Navigate(itemccount);
                    break;
                case "ItemAbout":
                    AboutApp itemAbout = new AboutApp();
                    MainFrame.Navigate(itemAbout);
                    break;
                case "ItemAdmin":
                    Administration itemAdmin = new Administration();
                    MainFrame.Navigate(itemAdmin);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
