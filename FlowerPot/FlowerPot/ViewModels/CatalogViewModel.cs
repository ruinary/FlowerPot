using System.Data;
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
    class CatalogViewModel : ViewModelBase
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
       
        public ICommand search => new DelegateCommand(Search);
        public void Search()
        {
        }

        public ICommand sort => new DelegateCommand(Sort);
        public void Sort()
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

        public ICommand toBasket => new DelegateCommand(ToBasket);
        private void ToBasket()
        {
            
        }

        public ICommand toInfo => new DelegateCommand(ToInfo);
        private void ToInfo()
        {
            //CurrentPage = new MoreAboutFlower();
            //MoreAboutFlower itemModels = new MoreAboutFlower();
            //WindowApp windowApp = new WindowApp();
            //windowApp.Show();
            //Controls.MainFrame.Navigate(itemModels);
        }
    }
}
