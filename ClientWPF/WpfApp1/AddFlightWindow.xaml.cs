using ClientWPF.ServiceAirlines;
using System;
using ClientWPF.Src;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace ClientWPF
{
    
    public partial class AddFlightWindow : Window
    {
        //AirlinesTicketServiceClient service = new AirlinesTicketServiceClient();
        City[] cities;
        public AddFlightWindow()
        {
            InitializeComponent();
        }

        public AddFlightWindow(double left, double top)
            : this() => (this.Left, this.Top) = (left, top);

        private void AddFlightBtn_Click(object sender, RoutedEventArgs e)
        {
            Result.Foreground = Brushes.Red;
            if (!IsNullOrEmpry(DateFlight, Convert.ToString(DateFlight.SelectedDate))
                & !IsNullOrEmpry(StartCity, StartCity.Text)
                & !IsNullOrEmpry(EndCity, EndCity.Text)
                & !IsNullOrEmpry(DateFlight, DateFlight.Text)
                & !IsNullOrEmpry(TimeFlight, TimeFlight.Text)
                & !IsNullOrEmpry(txtCost, txtCost.Text)
                & !IsNullOrEmpry(txtFlightId, txtFlightId.Text)
                & !IsNullOrEmpry(txtNumOfPlaces, txtNumOfPlaces.Text))
            {
                if (StartCity.SelectedItem == EndCity.SelectedItem)
                {
                    Result.Text = "Оберіть різні міста!";
                }
                else
                {
                    if (DateFlight.SelectedDate < DateTime.Now)
                    {
                        DateFlight.ToolTip = Brushes.Red;
                        Result.Text = "Введіть коректну дату!";

                    }
                    if (DateFlight.SelectedDate == DateTime.Now && TimeFlight.SelectedTime < DateTime.Now)
                    {
                        TimeFlight.ToolTip = Brushes.Red;
                        Result.Text = "Введіть коректний час!";
                    }
                    else
                    {
                        var dateTimeFlight = DateTime.Parse(string.Join(" ", DateFlight.Text, TimeFlight.Text));



                        var flight = new Flight()
                        {
                            StartCity = (City)StartCity.SelectedItem,
                            EndCity = (City)EndCity.SelectedItem,
                            DateFlight = dateTimeFlight,
                            Cost = Convert.ToInt32(txtCost.Text),
                            FlightNumber = Convert.ToInt32(txtFlightId.Text),
                            NumOfPlaces = Convert.ToInt32(txtNumOfPlaces.Text)
                        };
                        Result.Foreground = Brushes.White;
                        try
                        {
                            Result.Text = new AirlinesTicketServiceClient().AddNewFlight(flight);
                        }
                        catch (Exception ex)
                        {
                            new ExceptionWindow(ex.Message).Show();
                        }
                    }
                }

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = new AirlinesTicketServiceClient().GetAllCities();
                cities = response.Item1;
                StartCity.ItemsSource = EndCity.ItemsSource = cities;
                StartCity.DisplayMemberPath = EndCity.DisplayMemberPath = "CityName";
                if (response.Item2 != null)
                    new ExceptionWindow(response.Item2).Show();

            }
            catch (Exception ex)
            {
                new ExceptionWindow(ex.Message).Show();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private bool IsNullOrEmpry(Control control, string content)
        {
            if (content == string.Empty)
            {
                Result.Text = "Заповніть всі поля!";
                Result.Foreground = Brushes.Red;
                control.BorderBrush = Brushes.Red;
                return true;
            }
            else
            {
                Result.Text = "";
                control.BorderBrush = Brushes.Transparent;
                return false;
            }
        }
        private void LogoutButton_MouseDown(object sender, MouseButtonEventArgs e)
            => this.Open(new Login(this.Left, this.Top));

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
            => this.Close();

        private void BackButton_MouseDown(object sender, MouseButtonEventArgs e)
            => this.Open(new AllFlightsWindow(this.Left, this.Top));
    }
}
