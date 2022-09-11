using FlowerPot.Models;
using FlowerPot.Unit;
using FlowerPot.ViewModels;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FlowerPot.Views.Pages
{
    public partial class Catalog : Page
    {
        CatalogViewModel m = new CatalogViewModel();
        public static InfoAboutFlowers infoFlower = new InfoAboutFlowers();
        bool sortflagName = true;
        bool sortflagPrice = true;
        public static int openedAbout = 0;
        public Catalog()
        {
            InitializeComponent();
            ChangeLanguage();
            DataContext = m;

            using (UnitOfWork uow = new UnitOfWork())
            {
                CatalogTable.DataContext = uow.ProductsRepository.GetAll();
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
        #region Поиск
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                String searchBox = search.Text;
                CatalogTable.ItemsSource = uow.ProductsRepository.GetAll().Where(x => x.name_product.Contains(searchBox) || x.Catagory.type_of_flower.Contains(searchBox) || x.Color.type_of_color.Contains(searchBox));
            }
        }
        #endregion
        #region Добавить в корзину
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var index = CatalogTable.SelectedIndex;
                    Products item = (Products)CatalogTable.Items[index];
                    int countincart = 1;
                    int idcart = 0;

                    if (uow.CartRepository.GetAll().Where(u => u.Products.name_product == item.name_product && u.id_user == AuthorizationViewModel.currentuser.id_user).Count() > 0)
                    {
                        idcart = uow.CartRepository.GetAll().Where(u => u.Products.name_product == item.name_product && u.id_user == AuthorizationViewModel.currentuser.id_user).FirstOrDefault().id_cart;
                    }
                    if (idcart != 0)
                    {
                        var itemincart = uow.CartRepository.GetAll().Where(u => u.id_cart == idcart).FirstOrDefault();

                        uow.CartRepository.Remove(idcart);
                        uow.Save();

                        if (itemincart.total_amount < item.amount)
                        {
                            Models.Cart newitem = new Models.Cart()
                            {
                                id_cart = idcart,
                                id_product = item.id_product,
                                id_user = AuthorizationViewModel.currentuser.id_user,
                                total_amount = itemincart.total_amount + 1,
                                total_price = (itemincart.total_price / itemincart.total_amount) * (itemincart.total_amount + 1)
                            };

                            uow.CartRepository.Add(newitem);
                            uow.Save();
                        }
                    }
                    else 
                    {
                        int id = uow.ProductsRepository.GetAll().Where(u => u.name_product == item.name_product).FirstOrDefault().id_product;
                        Products product = uow.ProductsRepository.GetAll().Where(u => u.id_product == id).FirstOrDefault();

                        if (uow.CartRepository.GetAll().Count() != 0) { countincart = uow.CartRepository.GetAll().Last().id_cart + 1; }

                        Models.Cart cart = new Models.Cart() { id_cart = countincart, id_user = AuthorizationViewModel.currentuser.id_user, id_product = id, total_price = product.price_product, total_amount = 1 };
                        uow.CartRepository.Add(cart);
                        uow.Save();
                    }
                }
                catch (SystemException)
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }
#endregion
        #region Подробнее о товаре
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        block1:
            if (openedAbout < 1)
            {
                openedAbout++;
                using (UnitOfWork uow = new UnitOfWork())
                {
                    try
                    {
                        var index = CatalogTable.SelectedIndex;
                        Products item = (Products)CatalogTable.Items[index];
                        int id = uow.ProductsRepository.GetAll().Where(u => u.name_product == item.name_product).FirstOrDefault().id_product;
                        Products product = uow.ProductsRepository.GetAll().Where(u => u.id_product == id).FirstOrDefault();

                        var idP = product.id_product;
                        var name = product.name_product;
                        var fullname = product.fullname_product;
                        var description = product.discription_product;
                        var imageadress = product.img_path;
                        var cost = product.price_product;
                        var modeladress = product.model_path;
                        var color = product.Color.type_of_color;
                        var category = product.Catagory.type_of_flower;
                        var amount = product.amount;

                        infoFlower = new InfoAboutFlowers(idP, name, fullname, description, imageadress, modeladress, cost, color, category, amount);

                        MoreAboutFlower itemModels = new MoreAboutFlower();
                        itemModels.Show();

                    }
                    catch (SystemException)
                    {
                        MessageBox.Show("Ошибка!");
                    }
                }
            }
            else 
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window is MoreAboutFlower) { window.Close(); openedAbout--; }
                }
                goto block1;
            }
        }
        #endregion
        #region Сортировки
        private void Button_Click_SortByName(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (sortflagName) { CatalogTable.DataContext = uow.ProductsRepository.GetAll().OrderBy(u => u.fullname_product); }
                else { CatalogTable.DataContext = uow.ProductsRepository.GetAll().OrderByDescending(u => u.fullname_product); }
                sortflagName = !sortflagName;
            }
        }

        private void Button_Click_SortByPrice(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (sortflagPrice) { CatalogTable.DataContext = uow.ProductsRepository.GetAll().OrderBy(u => u.price_product); }
                else { CatalogTable.DataContext = uow.ProductsRepository.GetAll().OrderByDescending(u => u.price_product); }
                sortflagPrice = !sortflagPrice;
            }
        }
        #endregion
    }
}

