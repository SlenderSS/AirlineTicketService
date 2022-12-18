using ClientWPF.Src;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using ClientWPF.ServiceAirlines;
using System.Threading.Tasks;

namespace ClientWPF
{
    
    public partial class AllUsersWindow : Window
    {
       // AirlinesTicketServiceClient service = new AirlinesTicketServiceClient();
       
        
        public AllUsersWindow()
        {
            InitializeComponent();
        }
        public AllUsersWindow(double left, double top) 
            : this() => (this.Left, this.Top) = (left, top);
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = new AirlinesTicketServiceClient().GetAllUsers();
                UsersList.ItemsSource = response.Item1.ToList().Where(x => x.FirstName != "admin");
                if (response.Item2 != null)
                    new ExceptionWindow(response.Item2).Show();
            }
            catch (Exception ex)
            {
                new ExceptionWindow(ex.Message).Show();
            }
        }

        private void BackButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Open(new MainAdminWindow(this.Left, this.Top));
        }

        private void LogoutButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Open(new Login(this.Left, this.Top));            
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void DeleteUserBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UsersList.SelectedItem != null)
                {
                    var response = new AirlinesTicketServiceClient().DeleteUser((User)UsersList.SelectedItem);
                    UsersList.ItemsSource = response.Item1.ToList().Where(x => x.FirstName != "admin");
                    if (response.Item2 != null)
                        new ExceptionWindow(response.Item2).Show();
                }
            }
            catch (Exception ex) { new ExceptionWindow(ex.Message).Show(); }
            
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
                var response = new AirlinesTicketServiceClient().GetAllUsers();
                UsersList.ItemsSource = response.Item1.ToList().Where(x => x.FirstName != "admin");
                if (response.Item2 != null)
                    new ExceptionWindow(response.Item2).Show();
            }
            catch (Exception ex) { new ExceptionWindow(ex.Message).Show(); } 
        }
    }
}
