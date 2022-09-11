using FlowerPot.Models;
using FlowerPot.Unit;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FlowerPot.Views.Windows
{
    public partial class WindowAdd : Window
    {
        public string IMAGESTR = @"D:\git\FP\FlowerPot\picmodels\default.png";
        public string MODELSTR = @"D:\git\FP\FlowerPot\3dmodels\default.obj";

        public WindowAdd()
        {
            InitializeComponent();

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
        #endregion
        #region Функции

        #region Функции добавление изображения товара
        private void AddPictureBTTN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            if (Regex.IsMatch(filename, @"^.*\.(jpg|jfif|jpg|png|){1}$"))
            {
                if (filename != string.Empty)
                    IMAGESTR = filename;
                else IMAGESTR = @"D:\git\FP\FlowerPot\picmodels\default.png";
            }
            else
            {
                MiniWindow mw = new MiniWindow(666);
                mw.Show();
            }
        }
        #endregion

        #region Функции добавление 3д модели товара
        private void AddModelBTTN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            if (Regex.IsMatch(filename, @"^.*\.(obj){1}$"))
            {
                if (filename != string.Empty)
                    MODELSTR = filename;
                else MODELSTR = @"D:\git\FP\FlowerPot\3dmodels\default.obj";
            }
            else
            {
                MODELSTR = @"D:\git\FP\FlowerPot\3dmodels\default.obj";
                MiniWindow mw = new MiniWindow(666);
                mw.Show();
            }
        }
        #endregion

        #region Функции закрытия окна
        private void CancelBTTNADD_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Функции добавления товара
        private void OkBTTNADD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index_flower_type = 1;
                int index_color_type = 1;

                bool canAdd = true;
                int message = 22012003;

                if (DescriptionTB.Text.Length>200)
                {
                    canAdd = false;
                    message = 12;
                    DescriptionTB.BorderBrush = Brushes.MediumVioletRed;

                    goto END;
                }
                else
                {
                    DescriptionTB.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (!Regex.IsMatch(ShortNameTB.Text, @"^[А-ЯЁA-Z][а-яёa-z]+$"))
                {
                    canAdd = false;
                    message = 10;
                    ShortNameTB.BorderBrush = Brushes.MediumVioletRed;

                    goto END;
                }
                else
                {
                    ShortNameTB.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (!Regex.IsMatch(FullNameTB.Text, @"^[А-ЯЁA-Z][а-яёa-z]+(\s)*[А-ЯЁA-Z]*[а-яёa-z]*$"))
                {
                    canAdd = false;
                    message = 10;
                    FullNameTB.BorderBrush = Brushes.MediumVioletRed;

                    goto END;
                }
                else
                {
                    FullNameTB.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (!Regex.IsMatch(CostTB.Text, @"^([0-9]{0,3}(,[0-9]{3})*(\.[0-9]+)?)"))
                {
                    canAdd = false;
                    message = 11;
                    CostTB.BorderBrush = Brushes.MediumVioletRed;

                    goto END;
                }
                else
                {
                    CostTB.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (!Regex.IsMatch(AmountTB.Text, @"^[1-9]+[0-9]*$"))
                {
                    canAdd = false;
                    message = 11;
                    AmountTB.BorderBrush = Brushes.MediumVioletRed;

                    goto END;
                }
                else
                {
                    AmountTB.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (canAdd)
                {
                    switch (CategoryCB.SelectedIndex)
                    {
                        case 0:
                            index_flower_type = 1; break;
                        case 1:
                            index_flower_type = 2; break;
                        case 2:
                            index_flower_type = 3; break;
                        case 3:
                            index_flower_type = 4; break;
                        case 4:
                            index_flower_type = 5; break;
                        case 5:
                            index_flower_type = 6; break;
                        case 6:
                            index_flower_type = 7; break;
                        default: break;
                    }
                    switch (ColorCB.SelectedIndex)
                    {
                        case 0:
                            index_color_type = 1; break;
                        case 1:
                            index_color_type = 2; break;
                        case 2:
                            index_color_type = 3; break;
                        case 3:
                            index_color_type = 4; break;
                        case 4:
                            index_color_type = 5; break;
                        case 5:
                            index_color_type = 6; break;
                        case 6:
                            index_color_type = 7; break;
                        default: break;
                    }
                    int idproduct = 0;
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        idproduct = uow.ProductsRepository.GetAll().Count() + 1;
                        if (uow.ProductsRepository.GetAll().Any(u=>u.id_product == idproduct)) idproduct++;
                    }
                    Products product = new Products()
                    {
                        id_product = idproduct,
                        name_product = ShortNameTB.Text,
                        fullname_product = FullNameTB.Text,
                        discription_product = DescriptionTB.Text,
                        price_product = int.Parse(CostTB.Text),
                        amount = int.Parse(AmountTB.Text),
                        model_path = MODELSTR,
                        img_path = IMAGESTR,
                        id_flower_type = index_flower_type,
                        id_color_type = index_color_type
                    };
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        uow.ProductsRepository.Add(product);
                        uow.Save();
                    }
                    this.Close();
                }
            END:

                MiniWindow mw = new MiniWindow(message);
                mw.Show();
            }
            catch (System.FormatException) { MessageBox.Show("Данные введены неверно!", "Ошибка!"); }
            catch (System.OverflowException) { MessageBox.Show("Данные введены неверно! Введено слишком большое число для цены!", "Ошибка!"); }
        }
        #endregion

        #endregion
    }
}


