using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Mvvm;
using FlowerPot.Models;
using FlowerPot.Unit;
using FlowerPot.Views.Pages;
using FlowerPot.Views.Windows;

namespace FlowerPot.ViewModels
{
    class AuthorizationViewModel
    {
        public string login { get; set; }
        public string password { get; set; }
        public static CurrentUser currentuser { get; set; }

        #region Закрыть окно
        public ICommand close => new DelegateCommand(Close);
        public void Close()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this) { window.Close(); }
            }
        }
        #endregion
        #region Выйти из аккаунта
        public ICommand exit => new DelegateCommand(Exit);
        public void Exit()
        {
            this.Close();
        }
        #endregion
        #region Авторизация
        public ICommand app => new DelegateCommand(App);
        private void App()
        {
            bool IsDone = false;
            bool canauth = true;
            int message = 22012003;

            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (password == String.Empty || password == null || login == null || login == String.Empty)
                    {
                        canauth = false;
                        message = 1;
                        goto END;
                    }

                    string hashPassword = HashManager.GetHash(password);

                    if (uow.UserAuthRepository.GetAll().Any(u => u.login == login && u.password == hashPassword))
                    {
                        int userAuthId = uow.UserAuthRepository.GetAll().Where(u => u.login == login && u.password == hashPassword).FirstOrDefault().id_user;

                        Users user = uow.UserRepository.GetAll().Where(u => u.UserAuth.id_user == userAuthId).FirstOrDefault();
                        currentuser = new CurrentUser()
                        {
                            id_user = (Int32)user.id_user,
                            is_admin = user.is_admin,
                            First_Name = user.First_Name,
                            Last_Name = user.Last_Name,
                            Midle_Name = user.Midle_Name,
                            email = user.email,
                            phone_num = user.phone_num,
                            password = password,
                            login = login,
                            user_img_path = user.user_img_path,
                        };
                    }
                    else
                    {
                        message = 9;
                        goto END;
                    }
                }
                IsDone = true;
                if (IsDone && canauth)
                {
                    MainWindow formApp = new MainWindow();
                    formApp.Show();
                    this.Close();
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
        #region Кнопка ведущая к Регистрации
        public ICommand reg => new DelegateCommand(Reg);
        private void Reg()
        {
            Registration formReg = new Registration();
            formReg.Show();
            this.Close();
        }
        #endregion

    }
}
