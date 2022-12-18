using System.Windows;
using System.Windows.Input;
using ClientWPF.Src;
using ClientWPF.ServiceAirlines;

namespace ClientWPF
{
    public partial class MainUserWindow : Window
    {
        private User _user;
        AirlinesTicketServiceClient service = new AirlinesTicketServiceClient();
        public MainUserWindow()
        {
            InitializeComponent();
        }
        public MainUserWindow(User user, double left, double top) :
            this() => (this._user, this.Left, this.Top) = (user, left, top);

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                service.Disconnect(_user);
                this.Close();
            }
            catch (System.Exception ex)
            {
                new ExceptionWindow(ex.Message).Show();
            }
            
        }

        private void LogoutButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                service.Disconnect(_user);
                this.Open(new Login(this.Left, this.Top));
            }
            catch (System.Exception ex)
            {
                new ExceptionWindow(ex.Message).Show();
            }
            
        }

        private void GetMyReserves_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Open( new GetUserReservation(_user, this.Left, this.Top));                  
        }

        private void GetInform_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Open(new UserInformationWindow(_user, this.Left, this.Top));  
        }

        private void SearchFlights_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Open(new SearchFlights(_user, this.Left, this.Top));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
