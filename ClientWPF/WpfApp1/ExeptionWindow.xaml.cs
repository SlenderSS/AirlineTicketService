using System.Windows;
using System.Windows.Input;

namespace ClientWPF
{
    public partial class ExceptionWindow : Window
    {
        public ExceptionWindow()
        {
            InitializeComponent();
        }
        public ExceptionWindow(string exeption)
            : this() => (ExeptionTextBlock.Text) = (exeption);

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
            => this.Close();

        private void OkBtn_Click(object sender, RoutedEventArgs e)
             => this.Close();
    }
}
