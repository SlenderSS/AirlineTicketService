using ClientWPF.Src;
using ClientWPF.ServiceAirlines;
using System.Windows;
using System.Windows.Input;

namespace ClientWPF
{
    public partial class AllOrdersWindow : Window
    {
       // AirlinesTicketServiceClient service = new AirlinesTicketServiceClient();

        public AllOrdersWindow()
        {
            InitializeComponent();
        }
        public AllOrdersWindow(double left, double top)
            : this() => (this.Left, this.Top) = (left,top);
        
        private void BackButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Open(new MainAdminWindow(this.Left, this.Top));
           
        }

        private void LogoutButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Open(new Login(this.Left, this.Top));         
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var responce = new AirlinesTicketServiceClient().GetAllOrders();
                OrdersList.ItemsSource = responce.Item1;
                if (responce.Item2 != null)
                    new ExceptionWindow(responce.Item2).Show();
            }
            catch (System.Exception ex)
            {
                new ExceptionWindow(ex.Message).Show();
            }
     
        }

        private void UpdateButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OrdersList.ItemsSource = new AirlinesTicketServiceClient().GetAllOrders().Item1;
            }
            catch (System.Exception ex)
            {
                new ExceptionWindow(ex.Message).Show();
            }
        }
    }
}
