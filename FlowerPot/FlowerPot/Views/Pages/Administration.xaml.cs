using FlowerPot.Models;
using FlowerPot.Unit;
using FlowerPot.ViewModels;
using FlowerPot.Views.Windows;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FlowerPot.Views.Pages
{
    public partial class Administration : Page
    {
        CatalogViewModel m = new CatalogViewModel();
        public Administration()
        {
            InitializeComponent();

            ChangeLanguage();
            DataContext = m;

            using (UnitOfWork uow = new UnitOfWork())
            {
                CatalogTable.DataContext = uow.ProductsRepository.GetAll();
                UsersTable.DataContext = uow.UserRepository.GetAll();
                OrdersTable.DataContext = uow.OrdersRepository.GetAll();
            }

        }

        #region Функции инициализации в окне
        private void ChangeLanguage()
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(Settings.local, UriKind.Relative);
            Resources.MergedDictionaries.Add(dict);
        }
        #endregion
        #region Смена отображения элементов управления
        private void Button_Click_Swap_Orders(object sender, RoutedEventArgs e)
        {
            CatalogText.Visibility = Visibility.Hidden; CatalogTable.Visibility = Visibility.Hidden;
            UserText.Visibility = Visibility.Hidden; UsersTable.Visibility = Visibility.Hidden;
            OrdersText.Visibility = Visibility.Visible; OrdersTable.Visibility = Visibility.Visible;
        }
        private void Button_Click_Swap_Users(object sender, RoutedEventArgs e)
        {
            CatalogText.Visibility = Visibility.Hidden; CatalogTable.Visibility = Visibility.Hidden;
            OrdersText.Visibility = Visibility.Hidden; OrdersTable.Visibility = Visibility.Hidden;
            UserText.Visibility = Visibility.Visible; UsersTable.Visibility = Visibility.Visible;
        }
        private void Button_Click_Swap_Catalog(object sender, RoutedEventArgs e)
        {
            CatalogTable.Visibility = Visibility.Visible; CatalogText.Visibility = Visibility.Visible;
            UserText.Visibility = Visibility.Hidden; UsersTable.Visibility = Visibility.Hidden;
            OrdersText.Visibility = Visibility.Hidden; OrdersTable.Visibility = Visibility.Hidden;
        }
        #endregion
        #region Функции ЭУ
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            var index = CatalogTable.SelectedIndex;
            Products item = (Products)CatalogTable.Items[index];

            if (index < 0) { MessageBox.Show("Ничего не выбрано!", "Ошибка!"); }
            else
            {
                using (UnitOfWork uow = new UnitOfWork())
                {

                    int id = item.id_product;
                    Products product = uow.ProductsRepository.GetAll().Where(u => u.id_product == id).FirstOrDefault();

                    WindowEditProduct.infoFlower = new InfoAboutFlowers(id, product.name_product, product.fullname_product, product.discription_product, product.img_path, product.model_path, product.price_product, product.Color.type_of_color, product.Catagory.type_of_flower, product.amount);
                }
                WindowEditProduct editProductWin = new WindowEditProduct();
                editProductWin.Show();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
           
                var index = CatalogTable.SelectedIndex;
                Products item = (Products)CatalogTable.Items[index];
            if (index < 0) { MessageBox.Show("Ничего не выбрано!", "Ошибка!"); }
            else
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if ((!uow.CartRepository.GetAll().Any(u => u.id_product == item.id_product))|| (!uow.СonfirmOrderRepository.GetAll().Any(u => u.id_product == item.id_product)))
                    {
                        int id = uow.ProductsRepository.GetAll().Where(u => u.id_product == item.id_product).FirstOrDefault().id_product;
                        uow.ProductsRepository.Remove(id);
                        uow.Save();
                        List<Products> catalog = uow.ProductsRepository.GetAll();
                        CatalogTable.DataContext = catalog;
                    }
                }
            }
        }
        private void Button_Click_OrderFinish(object sender, RoutedEventArgs e)
        {
            var index = OrdersTable.SelectedIndex;
            Orders item = (Orders)OrdersTable.Items[index];

            if (index < 0) { MessageBox.Show("Ничего не выбрано!", "Ошибка!"); }
            else
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    int id = uow.OrdersRepository.GetAll().Where(u => u.id_order == item.id_order).FirstOrDefault().id_order;

                    SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
                    connection.Open();
                    string cmd = "UPDATE Orders SET id_order_status = '" + 1 + "' WHERE Orders.id_conforder =" + id;
                    SqlCommand createCommand = new SqlCommand(cmd, connection);
                    createCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);

                    OrdersTable.DataContext = uow.OrdersRepository.GetAll();
                }
            }
        }
        private void Button_Click_OrderReady(object sender, RoutedEventArgs e)
        {
            var index = OrdersTable.SelectedIndex;
            Orders item = (Orders)OrdersTable.Items[index];

            if (index < 0) { MessageBox.Show("Ничего не выбрано!", "Ошибка!"); }
            else
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    int id = uow.OrdersRepository.GetAll().Where(u => u.id_order == item.id_order).FirstOrDefault().id_order;

                    SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
                    connection.Open();
                    string cmd = "UPDATE Orders SET id_order_status = '" + 2 + "' WHERE Orders.id_conforder =" + id;
                    SqlCommand createCommand = new SqlCommand(cmd, connection);
                    createCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);


                    OrdersTable.DataContext = uow.OrdersRepository.GetAll().OrderBy(u => u.id_order);
                }
            }
        }

        private void Button_Click_Delete_Order(object sender, RoutedEventArgs e)
        {
            var index = OrdersTable.SelectedIndex;
            Orders item = (Orders)OrdersTable.Items[index];

            if (index < 0) { MessageBox.Show("Ничего не выбрано!", "Ошибка!"); }
            else
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    int id = uow.OrdersRepository.GetAll().Where(u => u.id_order == item.id_order).FirstOrDefault().id_order;
                    uow.OrdersRepository.Remove(id);
                    uow.Save();
                    OrdersTable.DataContext = uow.OrdersRepository.GetAll();
                }
            }
        }
        #endregion
    }
}
