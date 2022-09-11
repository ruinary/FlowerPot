using FlowerPot.Models;
using FlowerPot.Unit;
using FlowerPot.ViewModels;
using FlowerPot.Views.Windows;
using Microsoft.Win32;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FlowerPot.Views.Pages
{
    public partial class Account : Page
    {
        public Account()
        {
            InitializeComponent();
            ChangeTheme();

            DataContext = AuthorizationViewModel.currentuser;
        }

        #region Функции инициализации в окне
        private void ChangeTheme()
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(Settings.theme, UriKind.Relative);
            Resources.MergedDictionaries.Add(dict);
        }
        #endregion

        #region Edit Email
        private void Button_Click_EditEMail(object sender, RoutedEventArgs e)
        {
            EditEmail.Visibility = Visibility.Visible;
            CurEmail.Visibility = Visibility.Hidden;
        }
        private void Button_Click_ConfEMail(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                bool check1 = Regex.IsMatch(EditedEmail.Text, @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)");
                bool check2 = uow.UserRepository.GetAll().Any(u => u.email == EditedEmail.Text);
                if (check1 && !check2)
                {
                    string curEmail = EditedEmail.Text;
                    int userAuthId = AuthorizationViewModel.currentuser.id_user;

                    SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
                    connection.Open();
                    string cmd = "UPDATE Users SET email = '" + curEmail + "' WHERE Users.id_user =" + userAuthId;
                    SqlCommand createCommand = new SqlCommand(cmd, connection);
                    createCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                    connection.Close();

                    Users user = uow.UserRepository.GetAll().Where(u => u.id_user == userAuthId).FirstOrDefault();

                    string curPas = AuthorizationViewModel.currentuser.password;
                    string curLog = AuthorizationViewModel.currentuser.login;

                    AuthorizationViewModel.currentuser = new CurrentUser()
                    {
                        id_user = userAuthId,
                        is_admin = user.is_admin,
                        First_Name = user.First_Name,
                        Last_Name = user.Last_Name,
                        Midle_Name = user.Midle_Name,
                        email = curEmail,
                        phone_num = user.phone_num,
                        password = curPas,
                        login = curLog,
                        user_img_path = user.user_img_path,
                    };

                    EditedEmail.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");

                    EditEmail.Visibility = Visibility.Hidden;
                    CurEmail.Visibility = Visibility.Visible;

                    DataContext = AuthorizationViewModel.currentuser;
                }
                else
                {
                    EditedEmail.BorderBrush = Brushes.MediumVioletRed;
                }
               
            }
        }
        #endregion
        #region Edit Photo
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                string IMAGESTR = AuthorizationViewModel.currentuser.user_img_path;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                string filename = openFileDialog1.FileName;
                if (Regex.IsMatch(filename, @"^.*\.(jpg|jfif|jpg|png|){1}$"))
                {
                    if (filename != string.Empty)
                        IMAGESTR = filename;
                    else IMAGESTR = AuthorizationViewModel.currentuser.user_img_path;
                }
                else
                {
                    IMAGESTR = AuthorizationViewModel.currentuser.user_img_path;
                    MiniWindow mw = new MiniWindow(666);
                    mw.Show();
                }

                int userAuthId = AuthorizationViewModel.currentuser.id_user;

                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
                connection.Open();
                string cmd = "UPDATE Users SET user_img_path = '" + IMAGESTR + "' WHERE Users.id_user =" + userAuthId;
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                connection.Close();

                Users user = uow.UserRepository.GetAll().Where(u => u.id_user == userAuthId).FirstOrDefault();

                string curPas = AuthorizationViewModel.currentuser.password;
                string curLog = AuthorizationViewModel.currentuser.login;

                AuthorizationViewModel.currentuser = new CurrentUser()
                {
                    id_user = userAuthId,
                    is_admin = user.is_admin,
                    First_Name = user.First_Name,
                    Last_Name = user.Last_Name,
                    Midle_Name = user.Midle_Name,
                    email = user.email,
                    phone_num = user.phone_num,
                    password = curPas,
                    login = curLog,
                    user_img_path = IMAGESTR,
                };

                DataContext = AuthorizationViewModel.currentuser;
            };

        }
        #endregion
        #region Edit Phone
        private void Button_Click_EditPhone(object sender, RoutedEventArgs e)
        {
            EditPhone.Visibility = Visibility.Visible;
            CurPhone.Visibility = Visibility.Hidden;
        }

        private void Button_Click_ConfPhone(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                bool check1 = Regex.IsMatch(EditedPhone.Text, @"^(\+375|80)(29|44|33)([0-9]){7}$");
                bool check2 = uow.UserRepository.GetAll().Any(u => u.phone_num == EditedPhone.Text);
                if (check1 && !check2)
                {
                    string curPhone = EditedPhone.Text;
                    int userAuthId = AuthorizationViewModel.currentuser.id_user;

                    SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I0CC06B; Initial Catalog=FlowerPot; Integrated Security=True");
                    connection.Open();
                    string cmd = "UPDATE Users SET phone_num = '" + curPhone + "' WHERE Users.id_user =" + userAuthId;
                    SqlCommand createCommand = new SqlCommand(cmd, connection);
                    createCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                    connection.Close();

                    Users user = uow.UserRepository.GetAll().Where(u => u.id_user == userAuthId).FirstOrDefault();

                    string curPas = AuthorizationViewModel.currentuser.password;
                    string curLog = AuthorizationViewModel.currentuser.login;

                    AuthorizationViewModel.currentuser = new CurrentUser()
                    {
                        id_user = userAuthId,
                        is_admin = user.is_admin,
                        First_Name = user.First_Name,
                        Last_Name = user.Last_Name,
                        Midle_Name = user.Midle_Name,
                        email = user.email,
                        phone_num = curPhone,
                        password = curPas,
                        login = curLog,
                        user_img_path = user.user_img_path,
                    };

                    EditedPhone.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");

                    EditPhone.Visibility = Visibility.Hidden;
                    CurPhone.Visibility = Visibility.Visible;

                    CurPhone.DataContext = AuthorizationViewModel.currentuser;
                }
                else
                {
                    EditedPhone.BorderBrush = Brushes.MediumVioletRed;
                }
            }
        }
        #endregion
    }
}
