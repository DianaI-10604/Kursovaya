using System;
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
using КурсоваяРабота.Context;
using КурсоваяРабота.Models;

namespace КурсоваяРабота
{
    public partial class Authorization : UserControl
    {
        //public event EventHandler<UserAuthenticatedEventArgs> UserAuthenticated;

        private UserControl _user;
        public Authorization()
        {
            InitializeComponent();
        }
        
        public Authorization(UserControl user)
        {
            InitializeComponent();

            if (user != null)
            {
                _user = user;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = phone.Text;
            string passwordUser = password.Password; // используйте .Password для пароля

            // Поиск пользователя в базе данных
            using (var db = new PolyclinicContext()) // замените YourDbContext на ваш контекст данных
            {
                var user = db.Users.FirstOrDefault(u => u.Phonenumber == phoneNumber && u.Password == passwordUser);
                if (user != null)
                {
                    //OnUserAuthenticated(new UserAuthenticatedEventArgs(user));
                    // Если пользователь найден, выполните переход на следующее окно или UserControl
                    MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                    mainWindow.ContentControlPage.Content = new MainMenu();
                }
                else
                {
                    MessageBox.Show("Неверные данные для авторизации!");
                }
            }
        }
        //protected virtual void OnUserAuthenticated(UserAuthenticatedEventArgs e)
        //{
        //    UserAuthenticated?.Invoke(this, e);
        //}
    }

    //public class UserAuthenticatedEventArgs : EventArgs
    //{
    //    public User AuthenticatedUser { get; }

    //    public UserAuthenticatedEventArgs(User user)
    //    {
    //        AuthenticatedUser = user;
    //    }
    //}
}
