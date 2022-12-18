using ClientWPF.Src;
using System.Windows;
using ClientWPF.ServiceAirlines;
using System.Windows.Input;

namespace ClientWPF
{
    public partial class AllFlightsWindow : Window
    {
        AirlinesTicketServiceClient service = new AirlinesTicketServiceClient();
       
        public AllFlightsWindow()
        {
            InitializeComponent();
        }

        public AllFlightsWindow(double left, double top)
            : this() => (this.Left, this.Top) = (left, top);

        private void AddFlightBtn_Click(object sender, RoutedEventArgs e)
            => this.Open(new AddFlightWindow(this.Left, this.Top));

        


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FlightsList.ItemsSource = service.GetAllFlights();   
        }

        private void DeleteFlightBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FlightsList.SelectedItem != null)
                    FlightsList.ItemsSource = service.DeleteFlight((Flight)FlightsList.SelectedItem);
            }
            catch (System.Exception ex)
            {
                new ExeptionWindow(ex.Message).Show();
            }
            
        }
        
        private void EditFlightBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FlightsList.SelectedItem != null)
                this.Open(new EditFlightWindow((Flight)FlightsList.SelectedItem, this.Left, this.Top));
        }

        private void UpdateButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                FlightsList.ItemsSource = service.GetAllFlights();
            }
            catch (System.Exception ex)
            {
                new ExeptionWindow(ex.Message).Show();
            }
        }

        private void LogoutButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Open(new Login(this.Left, this.Top));
        }

        private void BackButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
           this.Open(new MainAdminWindow(this.Left, this.Top));            
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

       
    }
}
