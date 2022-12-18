using ClientWPF.Src;
using System.Windows;
using System.Windows.Input;

namespace ClientWPF
{

    public partial class MainAdminWindow : Window
    {
        public MainAdminWindow()
        {
            InitializeComponent();
        }
        public MainAdminWindow(double left, double top)
            : this() => (this.Left, this.Top) = (left, top);
        

        private void GetAllFlightsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Open(new AllFlightsWindow(this.Left, this.Top));
                     
        }

        private void GetAllUsersBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Open(new AllUsersWindow(this.Left, this.Top));
        }

        private void GetAllReservsBtn_Click(object sender, RoutedEventArgs e)
        {
           this.Open(new AllOrdersWindow(this.Left, this.Top));
           
           
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void LogoutButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Open(new Login(this.Left, this.Top));
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
