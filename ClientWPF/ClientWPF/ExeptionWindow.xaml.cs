using System.Windows;
using System.Windows.Input;

namespace ClientWPF
{
    public partial class ExeptionWindow : Window
    {
        public ExeptionWindow()
        {
            InitializeComponent();
        }
        public ExeptionWindow(string exeption)
            : this() => (ExeptionTextBlock.Text) = (exeption);

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
            => this.Close();

        private void OkBtn_Click(object sender, RoutedEventArgs e)
             => this.Close();
    }
}
