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

namespace КурсоваяРабота
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : UserControl
    {

        private MainWindow _windowcontext;
        public Authorization()
        {
            InitializeComponent();
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
    }
}
