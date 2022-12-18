using ClientWPF.Src;
using ClientWPF.ServiceAirlines;
using System.Windows;
using System.Windows.Input;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace ClientWPF
{

    public partial class Registration : Window
    {
        //AirlinesTicketServiceClient service = new AirlinesTicketServiceClient();

        public Registration()
        {
            InitializeComponent();
        }

        public Registration(double left, double top) 
            : this() => (this.Left, this.Top) = (left, top);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
            => this.Close();

        private void BackButton_MouseDown(object sender, MouseButtonEventArgs e)
            => this.Open(new Login(this.Left, this.Top));
        

        

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)            
                this.DragMove();           
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            Result.Foreground = Brushes.Red;
            if (!IsNullOrEmpry(txtName, txtName.Text)
                & !IsNullOrEmpry(txtSurname, txtSurname.Text)
                & !IsNullOrEmpry(txtEmail, txtEmail.Text)
                & !IsNullOrEmpry(txtPassword, txtPassword.Password)
                & !IsNullOrEmpry(txtConfirmPassword, txtPassword.Password)
                & !IsNullOrEmpry(txtCard, txtCard.Text))
            {
                if (txtName.Text == "admin")
                {
                    Result.Text = "Неправильне ім'я!";
                    
                    txtName.BorderBrush = Brushes.Red;
                }
                else
                {
                    txtName.BorderBrush = Brushes.Transparent;
                    if (IsEmail(txtEmail, txtEmail.Text))
                    {
                        if (txtPassword.Password == txtConfirmPassword.Password)
                        {
                            if (IsCard(txtCard, txtCard.Text))
                            {
                                try
                                {
                                    Result.Text = new AirlinesTicketServiceClient().Registration(
                                         new User()
                                         {
                                             FirstName = txtName.Text,
                                             LastName = txtSurname.Text,
                                             Email = txtEmail.Text,
                                             Password = txtPassword.Password,
                                             Card = txtCard.Text,
                                             RegistrationDate = DateTime.Now,
                                             Connection = "Offline"
                                         });
                                    if (Result.Text == "Вас зареєстровано")
                                        Result.Foreground = Brushes.White;
                                }
                                catch (Exception ex)
                                {
                                    new ExceptionWindow(ex.Message).Show();
                                }

                            }
                        }
                        else
                        {
                            txtConfirmPassword.BorderBrush = txtPassword.BorderBrush = Brushes.Red;
                            
                            Result.Text = "Паролі не збігаються!";
                        }
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
       
        private bool IsCard(Control control, string card)
        {
            if (new Regex(@"[\d.-]{16}", RegexOptions.IgnoreCase).IsMatch(card) && card.Length == 16)
            {
                Result.Text = "";
                control.BorderBrush = Brushes.Transparent;
                return true;
            }
            else
            {
                Result.Text = "Неправильна карта";
                Result.Foreground = Brushes.Red;
                control.BorderBrush = Brushes.Red;
                return false;
            }

        }
    }
}
