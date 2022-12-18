using ClientWPF.Src;
using System;
using ClientWPF.ServiceAirlines;
using System.Windows;

using System.Windows.Input;
using System.Windows.Media;

namespace ClientWPF
{
    
    public partial class EditFlightWindow : Window
    {
        Flight _flight;
        AirlinesTicketServiceClient service = new AirlinesTicketServiceClient();

        public EditFlightWindow()
        {
            InitializeComponent();
        }
        public EditFlightWindow(Flight flight,double left, double top) 
            : this() => (this._flight, this.Left, this.Top) = (flight, left, top);

        private void BackButton_MouseDown(object sender, MouseButtonEventArgs e)
            => this.Open(new AllFlightsWindow(this.Left, this.Top));

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtStartCity.Text = this._flight.StartCity.CityName;
            txtEndCity.Text = this._flight.EndCity.CityName;
            txtNumOfPlaces.Text = this._flight.NumOfPlaces.ToString();
            txtCost.Text = this._flight.Cost.ToString();
            var dateTimeSplit = this._flight.DateFlight.ToString().Split(' ');
            DateFlight.Text = dateTimeSplit[0];
            TimeFlight.Text = dateTimeSplit[1];

        }


        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
            => this.Close();

        private void LogoutButton_MouseDown(object sender, MouseButtonEventArgs e)
            => this.Open(new Login(this.Left, this.Top));

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void EditFlightBtn_Click(object sender, RoutedEventArgs e)
        {

            txtStartCity.IsEnabled = txtEndCity.IsEnabled = txtNumOfPlaces.IsEnabled = false;
            DateTime newDateTimeFlight = DateTime.Parse(string.Join(" ", DateFlight.Text, TimeFlight.Text));

            if(txtCost.Text != this._flight.Cost.ToString()|| newDateTimeFlight != this._flight.DateFlight)
            {
                this._flight.Cost = Convert.ToInt32(txtCost.Text);
                this._flight.DateFlight = newDateTimeFlight;
                Result.Foreground = Brushes.White;
                try
                {
                    Result.Text = service.UpdateFlight(this._flight);
                }
                catch (Exception ex)
                {
                    new ExeptionWindow(ex.Message).Show();
                }
            }

        }

       
    }
}
