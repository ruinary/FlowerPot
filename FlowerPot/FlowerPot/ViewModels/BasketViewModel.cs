using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Mvvm;
using FlowerPot.Views.Pages;
using FlowerPot.Views.UC;
using FlowerPot.Views.Windows;

namespace FlowerPot.ViewModels
{
    class BasketViewModel : ViewModelBase
    {
        public ICommand search => new DelegateCommand(Search);
        public void Search()
        {
        }

        public ICommand sort => new DelegateCommand(Sort);
        public void Sort()
        {
           
        }

        public ICommand clear => new DelegateCommand(Clear);
        public void Clear()
        {
            
        }
        public ICommand add => new DelegateCommand(Add);
        private void Add()
        {
            WindowAdd windowAdd = new WindowAdd();
            windowAdd.Show();
        }
        public ICommand remove => new DelegateCommand(Remove);
        private void Remove()
        {

        }

        public ICommand toInfo => new DelegateCommand(ToInfo);
        private void ToInfo()
        {
            
        }
    }
}
