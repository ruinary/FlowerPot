using FlowerPot.Models;
using FlowerPot.Unit;
using FlowerPot.ViewModels;
using FlowerPot.Views.Windows;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace FlowerPot
{

    public partial class Registration : Window
    {
        RegistrationViewModel m = new RegistrationViewModel();
        
        public Registration()
        {
            InitializeComponent();
            ChangeLanguage();
            ChangeTheme();
            DataContext = m;

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
        #endregion
        #region Регистрация
        private void ButtonConfirmReg_Click(object sender, RoutedEventArgs e)
        {
            bool IsDone = false;
            bool canreg = true;
            int message = 22012003;

            try
            {
                if (login.Text == String.Empty || login.Text == null || password.Password == String.Empty || password.Password == null || name.Text == null || name.Text == String.Empty ||
                       lastname.Text == String.Empty || lastname.Text == null || surname.Text == null || surname.Text == String.Empty || mail.Text == null || mail.Text == String.Empty || phonenum.Text == null || phonenum.Text == String.Empty)
                {
                    canreg = false;
                    message = 1;

                    if (login.Text == String.Empty || login.Text == null) login.BorderBrush = Brushes.MediumVioletRed;
                    if (password.Password == String.Empty || password.Password == null) password.BorderBrush = Brushes.MediumVioletRed;
                    if (name.Text == String.Empty || name.Text == null) name.BorderBrush = Brushes.MediumVioletRed;
                    if (lastname.Text == String.Empty || lastname.Text == null) lastname.BorderBrush = Brushes.MediumVioletRed;
                    if (surname.Text == String.Empty || surname.Text == null) surname.BorderBrush = Brushes.MediumVioletRed;
                    if (mail.Text == String.Empty || mail.Text == null) mail.BorderBrush = Brushes.MediumVioletRed;
                    if (phonenum.Text == String.Empty || phonenum.Text == null) phonenum.BorderBrush = Brushes.MediumVioletRed;

                    goto END;
                }
                else
                {
                    if (login.Text != String.Empty || login.Text != null) login.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                    if (password.Password != String.Empty || password.Password != null) password.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                    if (name.Text != String.Empty || name.Text != null) name.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                    if (lastname.Text != String.Empty || lastname.Text == null) lastname.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                    if (surname.Text != String.Empty || surname.Text != null) surname.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                    if (mail.Text != String.Empty || mail.Text != null) mail.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                    if (phonenum.Text != String.Empty || phonenum.Text != null) phonenum.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (password.Password.Length < 8)
                {
                    canreg = false;
                    message = 2;
                    password.BorderBrush = Brushes.MediumVioletRed;

                    goto END;
                }
                else
                {
                    password.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (password.Password != password_copy.Password)
                {
                    canreg = false;
                    message = 3;
                    password.BorderBrush = Brushes.MediumVioletRed;
                    password_copy.BorderBrush = Brushes.MediumVioletRed;

                    goto END;
                }
                else 
                {
                    password.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                    password_copy.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var check = uow.UserAuthRepository.GetAll().Any(u => u.login == login.Text);
                    if (check == true)
                    {
                        canreg = false;
                        message = 4;
                        login.BorderBrush = Brushes.MediumVioletRed;
                       
                        goto END;
                    }
                    else
                    {
                        login.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                    }
                }
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var check = uow.UserRepository.GetAll().Any(u => u.phone_num == phonenum.Text);
                    if (check == true)
                    {
                        canreg = false;
                        message = 5;
                        phonenum.BorderBrush = Brushes.MediumVioletRed;

                        goto END;
                    }
                    else
                    {
                        phonenum.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                    }
                }
                if (!Regex.IsMatch(name.Text, @"^[А-ЯЁA-Z][а-яёa-z]+$")) 
                {
                    canreg = false;
                    message = 6;
                    name.BorderBrush = Brushes.MediumVioletRed;

                    goto END;
                }
                else
                {
                    name.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (!Regex.IsMatch(surname.Text, @"^[А-ЯЁA-Z][а-яёa-z]+$"))
                {
                    canreg = false;
                    message = 6;
                    surname.BorderBrush = Brushes.MediumVioletRed;

                    goto END;
                }
                else
                {
                    surname.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (!Regex.IsMatch(lastname.Text, @"^[А-ЯЁA-Z][а-яёa-z]+$"))
                {
                    canreg = false;
                    message = 6;
                    lastname.BorderBrush = Brushes.MediumVioletRed;

                    goto END;
                }
                else
                {
                    lastname.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                }
                if (!Regex.IsMatch(phonenum.Text, @"^(\+375|80)(29|44|33)([0-9]){7}$"))
                {
                    canreg = false;
                    message = 7;
                    phonenum.BorderBrush = Brushes.MediumVioletRed;

                    goto END;
                }
                else
                {
                    phonenum.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");;
                }
                if (!Regex.IsMatch(mail.Text, @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)"))
                {
                    canreg = false;
                    message = 8;
                    mail.BorderBrush = Brushes.MediumVioletRed;

                    goto END;
                }
                else
                {
                    mail.BorderBrush = Brushes.White;
                }
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var check = uow.UserRepository.GetAll().Any(u => u.email == mail.Text);
                    if (check == true)
                    {
                        canreg = false;
                        message = 0;
                        mail.BorderBrush = Brushes.MediumVioletRed;

                        goto END;
                    }
                    else
                    {
                        mail.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#89FFFFFF");
                    }
                }
                 
                if (canreg)
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        string hashPassword = HashManager.GetHash(password.Password);
                        int newiduser = 1;
                        if (uow.UserAuthRepository.GetAll().Count() != 0) { newiduser = uow.UserAuthRepository.GetAll().Last().id_user + 1; }
                        UserAuth userAuth = new UserAuth() { id_user = newiduser, login = login.Text, password = hashPassword };
                        uow.UserAuthRepository.Add(userAuth);
                        uow.Save();
                        Users user = new Users() 
                        { 
                            id_user = newiduser,
                            is_admin = false, 
                            First_Name = name.Text, 
                            Last_Name = lastname.Text, 
                            Midle_Name = surname.Text, 
                            email = mail.Text, 
                            phone_num = phonenum.Text, 
                            user_img_path = @"D:\git\FP\FlowerPot\picusers\userdefault.png", 
                            UserAuth = userAuth };
                        uow.UserRepository.Add(user);
                        uow.Save();
                    }
                    IsDone = true;
                    if (IsDone)
                    {
                        Authorization formAuth = new Authorization();
                        formAuth.Show();
                        this.Close();
                    }
                }
            END:

                MiniWindow mw = new MiniWindow(message);
                mw.Show();
            }
            catch (SystemException)
            {
                MessageBox.Show("Ошибка!");
            }
        }
        #endregion
    }
}
