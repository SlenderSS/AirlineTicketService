using ClientWPF.Src;
using ClientWPF.ServiceAirlines;

using System.Windows;

using System.Windows.Input;
using System;
using System.Windows.Media;

namespace ClientWPF
{
   
    public partial class ChoosePlaceWindow : Window
    {
        private readonly Flight _flight;
        private readonly User _user;
        private readonly Flight searchedFlight;
        private AirlinesTicketServiceClient service = new AirlinesTicketServiceClient();
       
        public ChoosePlaceWindow()
        {
            InitializeComponent();      
        }
        public ChoosePlaceWindow(User user,Flight flight,Flight searchedFlight, double left, double top) 
            : this() => (this._user, this._flight,this.searchedFlight ,this.Left, this.Top) = (user,flight ,searchedFlight,left, top);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            FlightNumber.Text = _flight.FlightNumber.ToString();
            StartCity.Text = _flight.StartCity.CityName;
            EndCity.Text = _flight.EndCity.CityName;
            DateFlight.Text = _flight.DateFlight.ToString().Replace(" ", Environment.NewLine);
            Cost.Text = _flight.Cost.ToString();
            PlacesList.ItemsSource = service.GetPlaces(_flight);
           
            
        }
        private void BackButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
           this.Open(new FlightsListWindow(_user,searchedFlight, this.Left, this.Top));
        }

        private void LogoutButton_MouseDown(object sender, MouseButtonEventArgs e)
        {   try
            {
                service.Disconnect(_user);
                this.Open(new Login(this.Left, this.Top));
            }
            catch (Exception ex) { new ExeptionWindow(ex.Message).Show(); }
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            service.Disconnect(_user);
            this.Close();
        }

        private void ReservBtn_Click(object sender, RoutedEventArgs e)
        {
            if(PlacesList.SelectedItem != null && ((Place)PlacesList.SelectedItem).State != "Заброньовано")
            {
                var selectedPlace = (Place)PlacesList.SelectedItem;
                var tuple  = service.ReservePlace(_user, selectedPlace);
                PlacesList.ItemsSource = tuple.Item1;
                Result.Text = tuple.Item2;
                if (Result.Text != "Заброньовано")
                {
                    PlacesList.IsEnabled = false;
                    Result.ToolTip = Brushes.Red;
                }
                else
                    Result.ToolTip = Brushes.White;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void UpdateButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlacesList.ItemsSource = service.GetPlaces(_flight);
        }
    }
}
