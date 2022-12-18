using ClientWPF.Src;
using ClientWPF.ServiceAirlines;
using System.Windows;
using System.Windows.Input;


namespace ClientWPF
{
   
    public partial class FlightsListWindow : Window
    {
        private User _user;
        private Flight searchedFlight;
       // AirlinesTicketServiceClient service = new AirlinesTicketServiceClient();
        public FlightsListWindow()
        {
            InitializeComponent();
           
        }

        public FlightsListWindow(User user, Flight searchedFlight, double left, double top) :
            this() => (this._user,this.searchedFlight, this.Left, this.Top) = (user, searchedFlight, left, top);
          
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = new AirlinesTicketServiceClient().GetFlights(searchedFlight);
                FlightsList.ItemsSource = response.Item1;
                if (response.Item2 != null)
                    new ExceptionWindow(response.Item2).Show();
            }
            catch (System.Exception ex)
            {
                new ExceptionWindow(ex.Message).Show();
            }            
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.Close();
                new AirlinesTicketServiceClient().Disconnect(_user);
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
                new AirlinesTicketServiceClient().Disconnect(_user);
                this.Open(new Login(this.Left, this.Top));
            }
            catch (System.Exception ex)
            {
                this.Close();
                new ExceptionWindow(ex.Message).Show();
            }        
        }
   

        private void ReservBtn_Click(object sender, RoutedEventArgs e)
        {   
            
            if(FlightsList.SelectedItem != null)
            {
                try
                {
                    var flight = (Flight)FlightsList.SelectedItem;
                    this.Open(new ChoosePlaceWindow(_user, flight, searchedFlight, this.Left, this.Top));
                }
                catch (System.Exception ex)
                {
                    new ExceptionWindow(ex.Message).Show();
                }                     
            }
        }

        private void BackButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
           this.Open(new MainUserWindow(_user, this.Left, this.Top));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void UpdateButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var response = new AirlinesTicketServiceClient().GetFlights(searchedFlight);
                FlightsList.ItemsSource = response.Item1;
                if (response.Item2 != null)
                    new ExceptionWindow(response.Item2).Show();
            }
            catch (System.Exception ex)
            {
                new ExceptionWindow(ex.Message).Show();
            }
        }
    }
}
