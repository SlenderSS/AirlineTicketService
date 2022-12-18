using ClientWPF.Src;
using ClientWPF.ServiceAirlines;
using System.Windows;
using System.Windows.Input;

namespace ClientWPF
{
   
    public partial class GetUserReservation : Window
    {
        private User _user;
       // private AirlinesTicketServiceClient service = new AirlinesTicketServiceClient();

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
                var response = new AirlinesTicketServiceClient().GetUserReservation(this._user);
                OrderList.ItemsSource = response.Item1;
                if (response.Item2 != null)
                    new ExceptionWindow(response.Item2).Show();

            }
            catch (System.Exception ex)
            {
                new ExceptionWindow(ex.Message).Show();
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
                new AirlinesTicketServiceClient().Disconnect(_user);
                this.Open(new Login(this.Left, this.Top));
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
                new AirlinesTicketServiceClient().Disconnect(_user);
                this.Close();
            }
            catch (System.Exception ex)
            {
                new ExceptionWindow(ex.Message).Show();
            }
            
        }

        private void CancelReservBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrderList.SelectedItem != null && ((Order)OrderList.SelectedValue).State != "Куплено")
                {
                    var response = new AirlinesTicketServiceClient().CancelReservation((Order)OrderList.SelectedItem);
                    OrderList.ItemsSource = response.Item1;
                    if (response.Item2 != null)
                        new ExceptionWindow(response.Item2).Show();
                }
            }
            catch (System.Exception ex)
            {
                new ExceptionWindow(ex.Message).Show();
            }
              
        }

        private void BuyTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrderList.SelectedItem != null)
                {
                    var response = new AirlinesTicketServiceClient().BuyTicket((Order)OrderList.SelectedItem);
                    OrderList.ItemsSource = response.Item1;
                    if (response.Item2 != null && response.Item2 != "Квиток куплено")                    
                        new ExceptionWindow(response.Item2).Show();
       
                }
            }
            catch (System.Exception ex)
            { 
                new ExceptionWindow(ex.Message).Show();
            }
          
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        
    }
}
