using ClientWPF.Src;
using ClientWPF.ServiceAirlines;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System;

namespace ClientWPF
{
    public partial class UserInformationWindow : Window
    {
        private User _user;
        //AirlinesTicketServiceClient service = new AirlinesTicketServiceClient();

        public UserInformationWindow()
        {
            InitializeComponent();
            
        }

        public UserInformationWindow(User user, double left, double top) :
            this() => (this._user, this.Left, this.Top) = (user, left, top);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtEmail.IsEnabled = txtName.IsEnabled = txtSurname.IsEnabled = false;
            txtName.Text = _user.FirstName;
            txtSurname.Text = _user.LastName;
            txtEmail.Text = _user.Email;
            txtPassword.Text = _user.Password;
            txtCard.Text = _user.Card;

        }
     

        private void EditInformBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPassword.Text != _user.Password || txtCard.Text != _user.Card)
                {
                    _user.Password = txtPassword.Text;
                    _user.Card = txtCard.Text;  
                    Result.Text = new AirlinesTicketServiceClient().UpdateUserInformation(_user);
                    Result.Foreground = Brushes.White;
                }
                else
                {
                    Result.Text = "Введіть нові дані";
                    Result.Foreground = Brushes.Red;
                }

            }
            catch (Exception ex)
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
            catch (Exception ex) { new ExceptionWindow(ex.Message).Show(); }
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                new AirlinesTicketServiceClient().Disconnect(_user);
                this.Close();
            }
            catch (Exception ex) { new ExceptionWindow(ex.Message).Show(); }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
