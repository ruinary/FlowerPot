using FlowerPot.Models;
using FlowerPot.Unit;
using FlowerPot.ViewModels;
using FlowerPot.Views.Windows;
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

namespace FlowerPot.Views.Pages
{
    public partial class OrdersInfo : Page
    {

        bool sortflagName = true;
        bool sortflagPrice = true;

        public OrdersInfo()
        {
            InitializeComponent();

            using (UnitOfWork uow = new UnitOfWork())
            {
                OrdersTable.DataContext = uow.OrdersRepository.GetAll().Where(u => u.СonfirmOrder.id_user == AuthorizationViewModel.currentuser.id_user);
            }
        }

        #region Поиск
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                String searchBox = search.Text;
                OrdersTable.ItemsSource = uow.OrdersRepository.GetAll().Where(x => x.СonfirmOrder.Products.name_product.Contains(searchBox) && x.СonfirmOrder.id_user == AuthorizationViewModel.currentuser.id_user);
            }
        }
        #endregion
        #region Сортировка
        private void Button_Click_SortByNum(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (sortflagPrice) { OrdersTable.DataContext = uow.OrdersRepository.GetAll().Where(u => u.СonfirmOrder.id_user == AuthorizationViewModel.currentuser.id_user).OrderBy(u => u.id_order); }
                else { OrdersTable.DataContext = uow.OrdersRepository.GetAll().Where(u => u.СonfirmOrder.id_user == AuthorizationViewModel.currentuser.id_user).OrderByDescending(u => u.id_order); }
                sortflagPrice = !sortflagPrice;
            }
        }

        private void Button_Click_SortByName(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (sortflagName) { OrdersTable.DataContext = uow.OrdersRepository.GetAll().Where(u=>u.СonfirmOrder.id_user == AuthorizationViewModel.currentuser.id_user).OrderBy(u => u.СonfirmOrder.Products.fullname_product); }
                else { OrdersTable.DataContext = uow.OrdersRepository.GetAll().Where(u => u.СonfirmOrder.id_user == AuthorizationViewModel.currentuser.id_user).OrderByDescending(u => u.СonfirmOrder.Products.fullname_product); }
                sortflagName = !sortflagName;
            }
        }
        #endregion
    }
}
