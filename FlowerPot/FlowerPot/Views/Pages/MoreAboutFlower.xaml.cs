using FlowerPot.Unit;
using FlowerPot.ViewModels;
using FlowerPot.Views.Pages;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FlowerPot
{
    public partial class MoreAboutFlower : Window
    {
        //MoreAboutFlowerViewModel m = new MoreAboutFlowerViewModel();

        public MoreAboutFlower()
        {
            InitializeComponent();

            DataContext = Catalog.infoFlower;

            ChangeLanguage();
            ChangeTheme();
            
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
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion
        #region Смена отображения модели и изображения товара
        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            if (ImagesProductBlock.Visibility == Visibility.Visible)
            {
                ImagesProductBlock.Visibility = Visibility.Hidden;
                ThreeDimensionalBlock.Visibility = Visibility.Visible;
            }
            else
            {
                ImagesProductBlock.Visibility = Visibility.Visible;
                ThreeDimensionalBlock.Visibility = Visibility.Hidden;
            }
        }
        #endregion
        #region Занести в корзину
        private void ButtonBuy_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var index = Catalog.infoFlower.SelectedItemId;
                    var item = uow.ProductsRepository.GetAll().Where(u => u.id_product == index).FirstOrDefault();

                    int amount = 1;

                    bool check1 = Regex.IsMatch(countToAddCart.Text, @"^[1-9]+[0-9]*$");
                    bool check2 = false;
                    if (check1) check2 = Convert.ToInt32(countToAddCart.Text) < item.amount;

                    if (check1 && check2) { amount = Convert.ToInt32(countToAddCart.Text); countToAddCart.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF"); }
                    else { countToAddCart.BorderBrush = Brushes.MediumVioletRed; }

                        int countincart = 1;
                    int idcart = 0;

                    if (uow.CartRepository.GetAll().Any(u => u.Products.name_product == item.name_product && u.id_user == AuthorizationViewModel.currentuser.id_user))
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
                                total_amount = itemincart.total_amount + amount,
                                total_price = (itemincart.total_price / itemincart.total_amount) * (itemincart.total_amount + amount)
                            };

                            uow.CartRepository.Add(newitem);
                            uow.Save();
                        }
                    }
                    else
                    {
                        if (uow.CartRepository.GetAll().Count() != 0) { countincart = uow.CartRepository.GetAll().Last().id_cart + 1; }

                        Models.Cart cart = new Models.Cart() { id_cart = countincart, id_user = AuthorizationViewModel.currentuser.id_user, id_product = index, total_price = item.price_product*amount, total_amount = amount };
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
    }
}