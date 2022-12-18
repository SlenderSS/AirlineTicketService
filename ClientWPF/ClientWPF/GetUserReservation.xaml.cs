using ClientWPF.Src;
using ClientWPF.ServiceAirlines;
using System.Windows;
using System.Windows.Input;

namespace ClientWPF
{
   
    public partial class GetUserReservation : Window
    {
        private User _user;
        private AirlinesTicketServiceClient service = new AirlinesTicketServiceClient();

        public GetUserReservation()
        {
            InitializeComponent();

        }
        public GetUserReservation(User user, double left, double top) 
            : this() => (this._user,this.Left, this.Top) = (user, left,top);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderList.ItemsSource = service.GetUserReservation(this._user);
            }
            catch (System.Exception ex)
            {
                new ExeptionWindow(ex.Message).Show();
            } 
        }

        private void BackButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Open(new MainUserWindow(_user, this.Left, this.Top));    
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
                new ExeptionWindow(ex.Message).Show();
            }
           
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                service.Disconnect(_user);
                this.Close();
            }
            catch (System.Exception ex)
            {
                new ExeptionWindow(ex.Message).Show();
            }
            
        }

        private void CancelReservBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrderList.SelectedItem != null && ((Order)OrderList.SelectedValue).State != "Куплено")
                    OrderList.ItemsSource = service.CancelReservation((Order)OrderList.SelectedItem);
            }
            catch (System.Exception ex)
            {
                new ExeptionWindow(ex.Message).Show();
            }
              
        }

        private void BuyTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrderList.SelectedItem != null)
                    OrderList.ItemsSource = service.BuyTicket((Order)OrderList.SelectedItem);
            }
            catch (System.Exception ex)
            { 
                new ExeptionWindow(ex.Message).Show();
            }
          
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        
    }
}
