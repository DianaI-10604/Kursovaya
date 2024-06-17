using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
using System.ComponentModel;
using System.Windows.Media.Animation;

namespace КурсоваяРабота
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Visibility _infoVisibility = Visibility.Collapsed;
        public Visibility InfoVisibility
        {
            get { return _infoVisibility; }
            set
            {
                if (_infoVisibility != value)
                {
                    _infoVisibility = value;
                    OnPropertyChanged(nameof(InfoVisibility));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            //меняем окно
            ServicesWithoutAuthorization mainMenu = new ServicesWithoutAuthorization();
            ContentControlPage.Content = mainMenu;
        }

        private void GoToMainMenu(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            ContentControlPage.Content = mainMenu;
        }

        private void ServiceWithoutAuth(object sender, RoutedEventArgs e)
        {
            ServicesWithoutAuthorization servicesWithoutAuthorization = new ServicesWithoutAuthorization();
            ContentControlPage.Content = servicesWithoutAuthorization;
        }

        //-------------------------------------------------------------------------------------------------------
        //перемещение окна с помощью мыши
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void OpenSideMenu()
        {
            // Создание и запуск анимации открытия бокового меню
            DoubleAnimation animation = new DoubleAnimation(200, TimeSpan.FromSeconds(0.2));
            SideMenu.BeginAnimation(Grid.WidthProperty, animation);
            InfoVisibility = Visibility.Visible;
        }

        private void CloseSideMenu()
        {
            // Создание и запуск анимации закрытия бокового меню
            DoubleAnimation animation = new DoubleAnimation(40, TimeSpan.FromSeconds(0.2));
            SideMenu.BeginAnimation(Grid.WidthProperty, animation);

            InfoVisibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Открытие бокового меню при запуске окна
            OpenSideMenu();
        }

        private void ToggleMenu(object sender, RoutedEventArgs e)
        {
            // Переключение состояния бокового меню (открыто/закрыто)
            if (SideMenu.ActualWidth > 40)
                CloseSideMenu();
            else
                OpenSideMenu();
        }
        //-------------------------------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
