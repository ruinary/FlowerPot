using FlowerPot.Models;
using FlowerPot.Unit;
using FlowerPot.ViewModels;
using FlowerPot.Views.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FlowerPot.Views.Pages
{
    public partial class Cart : Page
    {
        BasketViewModel m = new BasketViewModel();
        public Cart()
        {
            InitializeComponent();
            ChangeLanguage();
            DataContext = m;

            using (UnitOfWork uow = new UnitOfWork())
            {
                List<Models.Cart> cart = uow.CartRepository.GetAll();
                BasketTable.DataContext = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user);
                var sum = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user).Sum(u => u.total_price);
                TotalPrice.DataContext = sum.ToString();
            }
        }

        #region Функции инициализации в окне
        private void ChangeLanguage()
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(Settings.local, UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
        #endregion
        #region Функции изменения количества товаров в корзине
        private void AddAmount(object sender, RoutedEventArgs e)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var index = BasketTable.SelectedIndex;
                    Models.Cart item = (Models.Cart)BasketTable.Items[index];
                    int id = uow.CartRepository.GetAll().Where(u => u.Products.name_product == item.Products.name_product).FirstOrDefault().id_cart;
                    if (item.total_amount < item.Products.amount)
                    {
                        Models.Cart newitem = new Models.Cart()
                        {
                            id_cart = item.id_cart,
                            id_product = item.id_product,
                            id_user = item.id_user,
                            total_amount = item.total_amount + 1,
                            total_price = (item.total_price / item.total_amount) * (item.total_amount + 1)
                        };

                        uow.CartRepository.Remove(id);
                        uow.Save();
                        uow.CartRepository.Add(newitem);
                        uow.Save();
                    }
                    else
                    {
                        Models.Cart newitem = new Models.Cart()
                        {
                            id_cart = item.id_cart,
                            id_product = item.id_product,
                            id_user = item.id_user,
                            total_amount = item.total_amount,
                            total_price = (item.total_price / item.total_amount) * (item.total_amount)
                        };

                        uow.CartRepository.Remove(id);
                        uow.Save();
                        uow.CartRepository.Add(newitem);
                        uow.Save();
                    }
                    BasketTable.DataContext = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user);
                    var sum = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user).Sum(u => u.total_price);
                    TotalPrice.DataContext = sum.ToString();
                }

            }
            catch (SystemException)
            {
                MessageBox.Show("Ошибка!");
            }
        }
        private void RemoveAmount(object sender, RoutedEventArgs e)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var index = BasketTable.SelectedIndex;
                    Models.Cart item = (Models.Cart)BasketTable.Items[index];
                    int id = uow.CartRepository.GetAll().Where(u => u.Products.name_product == item.Products.name_product).FirstOrDefault().id_cart;
                    if (item.total_amount > 1)
                    {
                        Models.Cart newitem = new Models.Cart()
                        {
                            id_cart = item.id_cart,
                            id_product = item.id_product,
                            id_user = item.id_user,
                            total_amount = item.total_amount - 1,
                            total_price = (item.total_price / item.total_amount) * (item.total_amount - 1)
                        };

                        uow.CartRepository.Remove(id);
                        uow.Save();
                        uow.CartRepository.Add(newitem);
                        uow.Save();
                    }
                    else if (item.total_amount == 1)
                    {
                        uow.CartRepository.Remove(id);
                        uow.Save();
                    }
                    else
                    {
                        Models.Cart newitem = new Models.Cart()
                        {
                            id_cart = item.id_cart,
                            id_product = item.id_product,
                            id_user = item.id_user,
                            total_amount = item.total_amount,
                            total_price = (item.total_price / item.total_amount) * (item.total_amount)
                        };

                        uow.CartRepository.Remove(id);
                        uow.Save();
                        uow.CartRepository.Add(newitem);
                        uow.Save();
                    }
                    BasketTable.DataContext = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user);
                    var sum = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user).Sum(u => u.total_price);
                    TotalPrice.DataContext = sum.ToString();
                }

            }
            catch (SystemException)
            {
                MessageBox.Show("Ошибка!");
            }
        }
        #endregion
        #region Функции подтверждения заказа
        private void ButtonConfirmPayment_Click(object sender, RoutedEventArgs e)
        {
            using(UnitOfWork uow = new UnitOfWork())
                {
                var orders = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user);
                foreach (var item in orders)
                {
                    int countinconforders = 1;
                    if (uow.СonfirmOrderRepository.GetAll().Count() != 0) { countinconforders = uow.СonfirmOrderRepository.GetAll().Last().id_conforder + 1; }
                    int countinorders = 1;
                    if (uow.OrdersRepository.GetAll().Count() != 0) { countinorders = uow.OrdersRepository.GetAll().Last().id_order + 1; }
                    СonfirmOrder conforder = new СonfirmOrder()
                    {
                        id_conforder = countinconforders,
                        id_product = item.id_product,
                        id_user = item.id_user,
                        total_amount = item.total_amount,
                        total_price = item.total_price
                    };
                    uow.СonfirmOrderRepository.Add(conforder);
                    uow.Save();
                    Orders order = new Orders()
                    {
                        id_order = countinorders,
                        id_conforder = conforder.id_conforder,
                        now_date = DateTime.Now,
                        id_order_status = 3
                    };
                    uow.OrdersRepository.Add(order);
                    uow.CartRepository.Remove(item.id_cart);
                    uow.Save();
                }

                BasketTable.DataContext = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user);
                var sum = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user).Sum(u => u.total_price);
                TotalPrice.DataContext = sum.ToString();
            }
        }
        #endregion
        #region Поиск
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                String searchBox = search.Text;
                BasketTable.ItemsSource = uow.CartRepository.GetAll().Where(x => x.Products.name_product.Contains(searchBox) && x.id_user == AuthorizationViewModel.currentuser.id_user);
            }
        }
        #endregion
        #region Удалить продукт из корзины
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var index = BasketTable.SelectedIndex;
            Models.Cart item = (Models.Cart)BasketTable.Items[index];
            if (index < 0) { MessageBox.Show("Ничего не выбрано!", "Ошибка!"); }
            else
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    int id = uow.CartRepository.GetAll().Where(u => u.id_cart == item.id_cart).FirstOrDefault().id_cart;
                    uow.CartRepository.Remove(id);
                    uow.Save();
                    BasketTable.DataContext = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user);
                    var sum = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user).Sum(u => u.total_price);
                    TotalPrice.DataContext = sum.ToString();
                }
            }
        }
        #endregion
        #region Очистить корзину
        private void Button_Click_ClearAll(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var cart = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user);
                foreach (var x in cart) 
                {
                    uow.CartRepository.Remove(x.id_cart);
                    uow.Save();
                }

                BasketTable.DataContext = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user);
                var sum = uow.CartRepository.GetAll().Where(u => u.id_user == AuthorizationViewModel.currentuser.id_user).Sum(u => u.total_price);
                TotalPrice.DataContext = sum.ToString();
            }
        }
        #endregion
    }
}
