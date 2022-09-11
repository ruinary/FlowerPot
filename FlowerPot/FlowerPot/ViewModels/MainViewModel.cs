using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Mvvm;
using FlowerPot.Views.Pages;
using FlowerPot.Views.Windows;


namespace FlowerPot.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Page currentpage;
        public Page CurrentPage
        {
            get { return currentpage; }
            set
            {
                this.currentpage = value;
                RaisePropertiesChanged(nameof(CurrentPage));
            }
        }

        private Page Catalog;
        private Page Cart;
        private Page AboutApp;
        private Page Settings;
        private Page Account;

        public MainViewModel()
        {
            Catalog = new Catalog();
            Cart = new Cart();
            AboutApp = new AboutApp();
            Settings = new Settings();
            Account = new Account();

            CurrentPage = Catalog;
        }

        public ICommand logout => new DelegateCommand(Logout);
        private void Logout()
        {
            Authorization formAuth = new Authorization();
            Application.Current.MainWindow = formAuth;
            formAuth.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window is MainWindow) { window.Close(); }
            }
        }

        public ICommand close => new DelegateCommand(Close);
        public void Close()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this) { window.Close(); }
            }
        }

        public ICommand exit => new DelegateCommand(Exit);
        public void Exit()
        {
            Application.Current.Shutdown();
        }

        public ICommand open_Catalog => new DelegateCommand(Open_Catalog);
        private void Open_Catalog()
        {
            CurrentPage = Catalog;
        }

        public ICommand open_Basket => new DelegateCommand(Open_Basket);
        private void Open_Basket()
        {
            CurrentPage = Cart;
        }

        public ICommand open_AboutApp => new DelegateCommand(Open_AboutApp);
        private void Open_AboutApp()
        {
            CurrentPage = AboutApp;
        }

        public ICommand open_Settings => new DelegateCommand(Open_Settings);
        private void Open_Settings()
        {
            CurrentPage = Settings;
        }

        public ICommand open_Account => new DelegateCommand(Open_Account);
        private void Open_Account()
        {
            CurrentPage = Account;
        }

    }
}