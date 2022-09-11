using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Mvvm;
using FlowerPot.Models;
using FlowerPot.Views.Pages;
using FlowerPot.Views.Windows;

namespace FlowerPot.ViewModels
{
    class RegistrationViewModel : ViewModelBase
    {
        public ICommand close => new DelegateCommand(Close);
        public void Close()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this) { window.Close(); }
            }
        }

        public ICommand exit => new DelegateCommand(Exit);
        public void Exit()
        {
            Application.Current.Shutdown();
        }

        public ICommand auth => new DelegateCommand(Auth);
        private void Auth()
        {
            Authorization formAuth = new Authorization();
            formAuth.Show();
            this.Close();
        }

        public ICommand confReg => new DelegateCommand(ConfReg);
        private void ConfReg()
        {
        }
    }
}
