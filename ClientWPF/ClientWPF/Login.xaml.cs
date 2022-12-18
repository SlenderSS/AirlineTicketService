using ClientWPF.ServiceAirlines;
using ClientWPF.Src;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace ClientWPF
{
    public partial class Login : Window
    {
           
        AirlinesTicketServiceClient server = new AirlinesTicketServiceClient();
        public Login()
        {
            InitializeComponent();
           
        }
        public Login(double left, double top) : 
            this() => (this.Left, this.Top) = (left, top);


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
            => this.Close();

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)            
           => this.Open(new Registration(this.Left, this.Top));
        

        private void AutorizationBtn_Click(object sender, RoutedEventArgs e)
        {               
            if(!IsNullOrEmpry(txtLogin, txtLogin.Text) 
                & !IsNullOrEmpry(txtPassword, txtPassword.Password))
            {
                if(IsEmail(txtLogin, txtLogin.Text))
                {
                    try
                    {
                        var user = server.Autorization(new User { Email = txtLogin.Text, Password = txtPassword.Password });
                        if (user == null)
                        {
                            Result.Text = "помилка авторизації";
                            Result.Foreground = Brushes.Red;
                        }
                        else
                        {
                            if (user.FirstName == "admin")
                                this.Open(new MainAdminWindow(this.Left, this.Top));
                            else
                                this.Open(new MainUserWindow(user, this.Left, this.Top));
                        }
                    }
                    catch (System.Exception ex)
                    {
                        new ExeptionWindow(ex.Message).Show();
                    }
                   
                }                
            }            
        }

        private bool IsEmail(Control control, string email)
        {
            if (new Regex(@"^[\w.-]+@\w+\.[a-z]+(\.[a-z]+)*$", RegexOptions.IgnoreCase).IsMatch(email))
            {
                Result.Text = "";
                control.BorderBrush = Brushes.Transparent;
                return true;
            }
            else
            {
                Result.Text = "Неправильний логін";
                Result.Foreground = Brushes.Red;
                control.BorderBrush = Brushes.Red;
                return false;
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

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        
    }
}
