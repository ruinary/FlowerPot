using FlowerPot.Models;
using FlowerPot.Unit;
using Microsoft.Win32;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FlowerPot.Views.Windows
{
    public partial class WindowEditProduct : Window
    {
        public static InfoAboutFlowers infoFlower = new InfoAboutFlowers();
        public WindowEditProduct()
        {
            InitializeComponent();
            DataContext = infoFlower;
        }

        #region Функции инициализации в окне
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion
        #region Изменение изображения
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string IMAGESTR = infoFlower.ImageAdress;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                string filename = openFileDialog1.FileName;
                if (Regex.IsMatch(filename, @"^.*\.(jpg|jfif|jpg|png|){1}$"))
                {
                    if (filename != string.Empty)
                        IMAGESTR = filename;
                    else IMAGESTR = infoFlower.ImageAdress;
                }
                else
                {
                    IMAGESTR = infoFlower.ImageAdress;
                    MiniWindow mw = new MiniWindow(666);
                    mw.Show();
                }

                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
                connection.Open();
                string cmd = "UPDATE Products SET img_path = '" + IMAGESTR + "' WHERE Products.id_product =" + infoFlower.SelectedItemId;
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                connection.Close();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    int id = infoFlower.SelectedItemId;
                    Products product = uow.ProductsRepository.GetAll().Where(u => u.id_product == id).FirstOrDefault();

                    infoFlower = new InfoAboutFlowers(id, product.name_product, product.fullname_product, product.discription_product, product.img_path, product.model_path, product.price_product, product.Color.type_of_color, product.Catagory.type_of_flower, product.amount);

                    DataContext = infoFlower;
                }
            }
            catch (SystemException)
            {
                MessageBox.Show("Ошибка!");
            }
        }

        #endregion
        #region Изменение модели
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string MODELSTR = infoFlower.ModelAdress;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            if (Regex.IsMatch(filename, @"^.*\.(obj|){1}$"))
            {
                if (filename != string.Empty)
                    MODELSTR = filename;
                else MODELSTR = infoFlower.ModelAdress;
            }
            else
            {
                MODELSTR = infoFlower.ModelAdress;
                MiniWindow mw = new MiniWindow(666);
                mw.Show();
            }

            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
            connection.Open();
            string cmd = "UPDATE Products SET model_path = '" + MODELSTR + "' WHERE Products.id_product =" + infoFlower.SelectedItemId;
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            connection.Close();
        }
        #endregion
        #region Изменение категории товара
        private void CategoryCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int index_flower_type = 1;
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

            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
            connection.Open();
            string cmd = "UPDATE Products SET id_flower_type = '" + index_flower_type + "' WHERE Products.id_product =" + infoFlower.SelectedItemId;
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            connection.Close();
        }
        #endregion
        #region Изменение цвета товара
        private void ColorCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int index_color_type = 1;
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

            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
            connection.Open();
            string cmd = "UPDATE Products SET id_color_type = '" + index_color_type + "' WHERE Products.id_product =" + infoFlower.SelectedItemId;
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            connection.Close();
        }

        #endregion
        #region Изменение количества на складе
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            editAmount.Visibility = Visibility.Visible;
            curAmount.Visibility = Visibility.Hidden;
        }
        private void Button_Click_ConfAmount(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                bool canEdit = true;
                if (!Regex.IsMatch(editedAmount.Text, @"^[1-9]+[0-9]*$"))
                {
                    canEdit = false;
                    editedAmount.BorderBrush = Brushes.MediumVioletRed;

                    MiniWindow mw = new MiniWindow(11);
                    mw.Show();
                }
                if (canEdit)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
                    connection.Open();
                    string cmd = "UPDATE Products SET amount = '" + editedAmount.Text + "' WHERE Products.id_product =" + infoFlower.SelectedItemId;
                    SqlCommand createCommand = new SqlCommand(cmd, connection);
                    createCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                    connection.Close();

                    editedAmount.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }

                editAmount.Visibility = Visibility.Hidden;
                curAmount.Visibility = Visibility.Visible;

                int id = infoFlower.SelectedItemId;
                Products product = uow.ProductsRepository.GetAll().Where(u => u.id_product == id).FirstOrDefault();

                infoFlower = new InfoAboutFlowers(id, product.name_product, product.fullname_product, product.discription_product, product.img_path, product.model_path, product.price_product, product.Color.type_of_color, product.Catagory.type_of_flower, product.amount);

                DataContext = infoFlower;

            }
        }
        #endregion
        #region Изменение Описания
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            editDescr.Visibility = Visibility.Visible;
            curDescr.Visibility = Visibility.Hidden;
        }

        private void Button_Click_ConfDescr(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (editedDescr.Text.Length <= 200)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
                    connection.Open();
                    string cmd = "UPDATE Products SET discription_product = '" + editedDescr.Text + "' WHERE Products.id_product =" + infoFlower.SelectedItemId;
                    SqlCommand createCommand = new SqlCommand(cmd, connection);
                    createCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                    connection.Close();

                    editedDescr.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");

                    editDescr.Visibility = Visibility.Hidden;
                    curDescr.Visibility = Visibility.Visible;

                    int id = infoFlower.SelectedItemId;
                    Products product = uow.ProductsRepository.GetAll().Where(u => u.id_product == id).FirstOrDefault();

                    infoFlower = new InfoAboutFlowers(id, product.name_product, product.fullname_product, product.discription_product, product.img_path, product.model_path, product.price_product, product.Color.type_of_color, product.Catagory.type_of_flower, product.amount);

                    DataContext = infoFlower;
                }
                else
                {
                    MiniWindow mw = new MiniWindow(12);
                    mw.Show();
                    editedDescr.BorderBrush = Brushes.MediumVioletRed;
                }
            }
        }

        #endregion
        #region Изменение цены
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            editCost.Visibility = Visibility.Visible;
            curCost.Visibility = Visibility.Hidden;
        }

        private void Button_Click_ConfCost(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                bool canEdit = true;
                if (!Regex.IsMatch(editedCost.Text, @"^([0-9]{0,3}(,[0-9]{3})*(\.[0-9]+)?)"))
                {
                    canEdit = false;
                    editedCost.BorderBrush = Brushes.MediumVioletRed;

                    MiniWindow mw = new MiniWindow(11);
                    mw.Show();
                }
                if (canEdit)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
                    connection.Open();
                    string cmd = "UPDATE Products SET price_product = '" + editedCost.Text + "' WHERE Products.id_product =" + infoFlower.SelectedItemId;
                    SqlCommand createCommand = new SqlCommand(cmd, connection);
                    createCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                    connection.Close();

                    editedCost.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");

                    int id = infoFlower.SelectedItemId;
                    Products product = uow.ProductsRepository.GetAll().Where(u => u.id_product == id).FirstOrDefault();

                    infoFlower = new InfoAboutFlowers(id, product.name_product, product.fullname_product, product.discription_product, product.img_path, product.model_path, product.price_product, product.Color.type_of_color, product.Catagory.type_of_flower, product.amount);

                    DataContext = infoFlower;
                }

                editCost.Visibility = Visibility.Hidden;
                curCost.Visibility = Visibility.Visible;
            }
        }

        #endregion
        #region Изменение названия товара 
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            editName.Visibility = Visibility.Visible;
            curName.Visibility = Visibility.Hidden;
        }

        private void Button_Click_ConfName(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                bool canEdit = true;
                if (!Regex.IsMatch(editedName.Text, @"^[А-ЯЁA-Z][а-яёa-z]+$"))
                {
                    canEdit = false;
                    editedName.BorderBrush = Brushes.MediumVioletRed;

                    MiniWindow mw = new MiniWindow(10);
                    mw.Show();
                }
                else
                {
                    editedName.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (uow.ProductsRepository.GetAll().Any(u => u.name_product == editedName.Text))
                {
                    canEdit = false;
                    editedName.BorderBrush = Brushes.MediumVioletRed;

                    MiniWindow mw = new MiniWindow(13);
                    mw.Show();
                }
                else
                {
                    editedName.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (editedName.Text.Length > 20)
                {
                    canEdit = false;
                    editedName.BorderBrush = Brushes.MediumVioletRed;

                    MiniWindow mw = new MiniWindow(12);
                    mw.Show();
                }
                else
                {
                    editedName.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }

                if (canEdit)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
                    connection.Open();
                    string cmd = "UPDATE Products SET name_product = '" + editedName.Text + "' WHERE Products.id_product =" + infoFlower.SelectedItemId;
                    SqlCommand createCommand = new SqlCommand(cmd, connection);
                    createCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                    connection.Close();

                    editedName.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");

                    int id = infoFlower.SelectedItemId;
                    Products product = uow.ProductsRepository.GetAll().Where(u => u.id_product == id).FirstOrDefault();

                    infoFlower = new InfoAboutFlowers(id, editedName.Text, product.fullname_product, product.discription_product, product.img_path, product.model_path, product.price_product, product.Color.type_of_color, product.Catagory.type_of_flower, product.amount);

                    DataContext = infoFlower;
                }

                editName.Visibility = Visibility.Hidden;
                curName.Visibility = Visibility.Visible;
            }
        }

        #endregion
        #region Измение полное название товара
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            editFullName.Visibility = Visibility.Visible;
            curFullName.Visibility = Visibility.Hidden;
        }

        private void Button_Click_ConfFullName(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                bool canEdit = true;
                if (!Regex.IsMatch(editedFullName.Text, @"^[А-ЯЁA-Z][а-яёa-z]+(\s)*[А-ЯЁA-Z]*[а-яёa-z]*$"))
                {
                    canEdit = false;
                    editedFullName.BorderBrush = Brushes.MediumVioletRed;

                    MiniWindow mw = new MiniWindow(10);
                    mw.Show();
                }
                else
                {
                    editedFullName.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (uow.ProductsRepository.GetAll().Any(u => u.fullname_product == editedFullName.Text))
                {
                    canEdit = false;
                    editedFullName.BorderBrush = Brushes.MediumVioletRed;

                    MiniWindow mw = new MiniWindow(13);
                    mw.Show();
                }
                else
                {
                    editedFullName.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (editedFullName.Text.Length > 80)
                {
                    canEdit = false;
                    editedFullName.BorderBrush = Brushes.MediumVioletRed;

                    MiniWindow mw = new MiniWindow(12);
                    mw.Show();
                }
                else
                {
                    editedFullName.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }

                if (canEdit)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
                    connection.Open();
                    string cmd = "UPDATE Products SET fullname_product = '" + editedFullName.Text + "' WHERE Products.id_product =" + infoFlower.SelectedItemId;
                    SqlCommand createCommand = new SqlCommand(cmd, connection);
                    createCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                    connection.Close();

                    editedFullName.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");

                    int id = infoFlower.SelectedItemId;
                    Products product = uow.ProductsRepository.GetAll().Where(u => u.id_product == id).FirstOrDefault();

                    infoFlower = new InfoAboutFlowers(id, product.name_product, editedFullName.Text,  product.discription_product, product.img_path, product.model_path, product.price_product, product.Color.type_of_color, product.Catagory.type_of_flower, product.amount);

                    DataContext = infoFlower;
                }

                editFullName.Visibility = Visibility.Hidden;
                curFullName.Visibility = Visibility.Visible;
            }
        }
        #endregion
    }
}
