﻿using System;
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

namespace КурсоваяРабота
{
    public partial class ServicesWithoutAuthorization : UserControl
    {
        private UserControl _user;

        public ServicesWithoutAuthorization()
        {
            InitializeComponent();
        }
        public ServicesWithoutAuthorization(UserControl user)
        {
            InitializeComponent();

            if (user != null)
            {
                _user = user;
            }
        }

        //метод для входа в свой аккаунт
        private void SignIn_ButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.ContentControlPage.Content = new Authorization(_user);
        }

        //переходим к регистрации пользователя
        private void Registration_ButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.ContentControlPage.Content = new RegistrationUser();
        }
    }
}
