using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel.Views.Windows
{
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
        }

        private void SignUpClickableText_OnMouseEnter(object sender, MouseEventArgs e)
            => this.SignUpClickableText.Foreground = Brushes.Coral;

        private void SignUpClickableText_OnMouseLeave(object sender, MouseEventArgs e)
            => this.SignUpClickableText.Foreground = Brushes.Black;
    }
}