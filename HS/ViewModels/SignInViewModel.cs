using System.Windows;
using System.Windows.Input;
using Hotel.Infrastructure.Commands.Base;
using Hotel.Views.Windows;
using HS.ViewModels;
using HS.ViewModels.Base;

namespace Hotel.ViewModels
{
    public class SignInViewModel : ViewModel
    {
        #region Commands

        #region NewUser

        public ICommand OpenNewSignUpWindowCommand { get; }

        private void OnOpenNewSignUpWindowCommandExecuted(object p)
        {
            SignUpWindow newUserWindow = new SignUpWindow();
            newUserWindow.Owner = Application.Current.MainWindow;
            newUserWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newUserWindow.ShowDialog();
        }

        private bool CanOpenNewSignUpWindowCommandExecute(object p) => true;

        #endregion

        #endregion

        public SignInViewModel(MainViewModel mainViewModel)
        {
            #region CommandsInit

            OpenNewSignUpWindowCommand =
                new RelayCommand(OnOpenNewSignUpWindowCommandExecuted, CanOpenNewSignUpWindowCommandExecute);
            
            #endregion
        }
    }
}