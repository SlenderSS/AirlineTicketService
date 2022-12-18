using ClientWPF.Src;
using ClientWPF.ServiceAirlines;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace ClientWPF
{

    public partial class SearchFlights : Window
    {
       
        //AirlinesTicketServiceClient service = new AirlinesTicketServiceClient();
        User _user;

       
        public SearchFlights()
        {
            InitializeComponent();
        }
        public SearchFlights(User user, double left, double top)
            : this() => (this._user, this.Left, this.Top) = (user, left, top);


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {   
            try
            {
                var response = new AirlinesTicketServiceClient().GetAllCities();
                StartCity.ItemsSource = EndCity.ItemsSource = response.Item1;
                StartCity.DisplayMemberPath = EndCity.DisplayMemberPath = "CityName";
            }
            catch (Exception ex) { new ExceptionWindow(ex.Message).Show(); }
        }

        private void SearchFligthButton_Click(object sender, RoutedEventArgs e)
        {
            Result.Foreground = Brushes.Red;
            if (!IsNullOrEmpry(DateFlight, Convert.ToString(DateFlight.SelectedDate))
                & !IsNullOrEmpry(StartCity, StartCity.Text)
                & !IsNullOrEmpry(EndCity, EndCity.Text))
            {
                if(StartCity.SelectedItem == EndCity.SelectedItem)
                {
                    Result.Text = "Оберіть різні міста!"; 
                }
                else
                {
                    var dateTimeFlight = DateTime.Parse(string.Join(" ", DateFlight.Text, TimeFlight.Text));

                    if(dateTimeFlight < DateTime.Now)
                    {
                        DateFlight.ToolTip = Brushes.Red;
                        Result.Text = "Введіть коректну дату і час!";                        
                    }                  
                    else
                    {
                        var flight = new Flight()
                        {
                            StartCity = (City)StartCity.SelectedItem,
                            EndCity = (City)EndCity.SelectedItem,
                            DateFlight = dateTimeFlight
                        };
                        this.Open(new FlightsListWindow(this._user, flight, this.Left, this.Top));                       
                    }
                }

            }

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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                new AirlinesTicketServiceClient().Disconnect(_user);
                this.Close();
            }
            catch (Exception ex)
            {
                new ExceptionWindow(ex.Message).Show();
            }         
        }

        private void LogoutButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.Open(new Login(this.Left, this.Top));
                new AirlinesTicketServiceClient().Disconnect(_user);
            }
            catch (Exception ex)
            {
                new ExceptionWindow(ex.Message).Show();
            }            
        }

        private void BackButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Open(new MainUserWindow(this._user, this.Left, this.Top));
        }
    }
}
